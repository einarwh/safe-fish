module Client.Transforms

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Data.Vectors
open Data.Shapes
open Data.Styling
open Data.Boxes
open Data.Pictures

type Bounds = (int * int)

type Model = (Bounds * Box list * (Shape * Style) list)

let mapper { a = a; b = b; c = c } 
           { x = x; y = y } =
   a + b * x + c * y

let mapShape m = function 
  | Polygon { points = pts } ->
    Polygon { points = pts |> List.map m }
  | Polyline { pts = pts } ->
    Polyline { pts = pts |> List.map m }
  | Curve { point1 = v1
            point2 = v2 
            point3 = v3 
            point4 = v4 } ->
    Curve { point1 = m v1
            point2 = m v2 
            point3 = m v3 
            point4 = m v4 }
  | x -> x

let size { x = x; y = y } = 
  sqrt(x * x + y * y)

let getStrokeWidth { a = _; b = b; c = c } =
  let s = min (size b) (size c)
  s / 80.
                         
let getStyle box = 
  let sw = getStrokeWidth box
  { stroke = Some { strokeWidth = sw
                    strokeColor = StyleColor.Black } 
    fill = None }

let createPicture (shapes : Shape list) : Picture = 
   fun box ->
     let m = mapper box
     let style = getStyle box
     shapes |> List.map (mapShape m) |> List.map (fun s -> s, style)

let toAxisLine { lineStart = { x = x1; y = y1 } 
                 lineEnd = { x = x2; y = y2 } } = 
   line 
     [ SVGAttr.Stroke "black"
       SVGAttr.StrokeWidth "1.5"
       X1 x1
       Y1 y1
       X2 x2
       Y2 y2 ] []


let toArrow color { lineStart = { x = x1; y = y1 } 
                    lineEnd = { x = x2; y = y2 } } = 
   line 
     [ SVGAttr.Stroke color
       SVGAttr.StrokeWidth "1.5"
       X1 x1
       Y1 y1
       X2 x2
       Y2 y2 ] []

let toDottedLine { lineStart = { x = x1; y = y1 } 
                   lineEnd = { x = x2; y = y2 } } =
   line 
     [ SVGAttr.Stroke "grey"
       SVGAttr.StrokeDasharray "2"
       SVGAttr.StrokeWidth "1"
       X1 x1
       Y1 y1
       X2 x2
       Y2 y2 ] []

let mirrorVector height { x = x; y = y } =
  { x = x; y = height - y }
  
let mirrorShape mirror = function 
    | Line { lineStart = lineStart 
             lineEnd = lineEnd } ->
      Line { lineStart = mirror lineStart 
             lineEnd = mirror lineEnd }
    | Polygon { points = pts } ->
      Polygon { points = pts |> List.map mirror }
    | Polyline { pts = pts } ->
      Polyline { pts = pts |> List.map mirror }
    | Curve { point1 = v1
              point2 = v2 
              point3 = v3 
              point4 = v4 } ->
      Curve { point1 = mirror v1
              point2 = mirror v2 
              point3 = mirror v3 
              point4 = mirror v4 }
    | x -> x


let getStrokeWidthFromStyle = function 
  | Some strokeStyle ->
    1.
  | None -> 1.

let toSvgElement (style : Style) = function 
    | Line { lineStart = { x = x1; y = y1 } 
             lineEnd = { x = x2; y = y2 } } ->
      let lineElement = 
        line 
          [ SVGAttr.Stroke "green"
            X1 x1
            Y1 y1
            X2 x2
            Y2 y2 ] []
      lineElement
    | Polygon { points = pts } ->
      let pt { x = x; y = y } = sprintf "%f,%f" x y
      let s = pts |> List.map pt |> List.fold (fun acc it -> if acc = "" then it else acc + " " + it) ""
      let polygonElement = 
        polygon 
          [ SVGAttr.Stroke "black"
            SVGAttr.Fill "none"
            Points s ] []
      polygonElement
    | Polyline { pts = pts } ->
      let pt { x = x; y = y } = sprintf "%f,%f" x y
      let s = pts |> List.map pt |> List.fold (fun acc it -> if acc = "" then it else acc + " " + it) ""
      let polylineElement = 
        polyline 
          [ SVGAttr.Stroke "black"
            SVGAttr.Fill "none"
            Points s ] []
      polylineElement
    | Curve { point1 = { x = x1; y = y1 }
              point2 = { x = x2; y = y2 } 
              point3 = { x = x3; y = y3 } 
              point4 = { x = x4; y = y4 } } ->
      let d = sprintf "M%f %f C %f %f, %f %f, %f %f" x1 y1 x2 y2 x3 y3 x4 y4
      let strokeWidth = getStrokeWidthFromStyle style.stroke
      let curveElement =
        path 
          [ SVGAttr.Stroke "black"
            SVGAttr.Fill "none"
            SVGAttr.StrokeWidth strokeWidth
            SVGAttr.StrokeLinecap "butt"
            SVGAttr.D d ] []
      curveElement
    | _ -> failwith "unmatched shape in toSvgElement"


let toAxis length = 
   let dotPositions = [0 .. 25 .. length]
   
   let dashes = 
     let fn n =
       let x = float n 
       { lineStart = { x = x; y = 0. }
         lineEnd = { x = x; y = 3. } }
     dotPositions |> List.map fn
   let ln = 
     { lineStart = { x = 0.; y = 0. }
       lineEnd = { x = float length; y = 0. } }
   ln :: dashes

let mirrorLine mv { lineStart = ls; lineEnd = le } = 
  { lineStart = mv ls; lineEnd = mv le }

let toXAxis mv svgWidth = 
  toAxis svgWidth 
  |> List.map (mirrorLine mv >> toAxisLine)

let swap { x = x; y = y } = { x = y; y = x }

let toYAxis mv svgHeight = 
  toAxis svgHeight 
  |> List.map (fun { lineStart = s; lineEnd = e } -> 
                   { lineStart = swap s; lineEnd = swap e })
  |> List.map (mirrorLine mv >> toAxisLine)


let boxLines mv box = 
    let a = box.a
    let b = box.b
    let c = box.c
    let aarrow = toArrow "red" { lineStart = mv { x = 0.; y = 0. }
                                 lineEnd = mv a }
    let barrow = toArrow "pink" { lineStart = mv a
                                  lineEnd = mv (a + b) }
    let carrow = toArrow "purple" { lineStart = mv a
                                    lineEnd = mv (a + c) }
    let bdotted = toDottedLine { lineStart = mv (a + c) 
                                 lineEnd = mv (a + c + b) }
    let cdotted = toDottedLine { lineStart = mv (a + b)
                                 lineEnd = mv (a + b + c) }
    let arrows = aarrow :: barrow :: carrow :: bdotted :: [ cdotted ]
    arrows

let view ((bounds, boxes, shapes) : Model) = 
    let (svgWidth, svgHeight) = bounds
    let mv = (mirrorVector <| float svgHeight)
    let fn (shape, style) = 
      (mirrorShape mv >> toSvgElement style) shape      
    let svgElements = shapes |> List.map fn
    
    let xAxis = toXAxis mv svgWidth
    let yAxis = toYAxis mv svgHeight

    let arrows = boxes |> List.collect (boxLines mv)
    let elements =
      if boxes |> List.isEmpty then arrows @ svgElements
      else xAxis @ yAxis @ arrows @ svgElements
    svg [ HTMLAttr.Width svgWidth
          HTMLAttr.Height svgHeight ] 
        elements
