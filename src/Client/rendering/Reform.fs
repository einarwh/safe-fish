module Client.Reform

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Data.Vectors
open Data.Shapes
open Data.Styling
open Data.Boxes
open Data.Lenses
open Data.Shades

type Bounds = (int * int)

type Model = (Bounds * StyleColor * (Shape * Style) list)

let mapper ({ a = a; b = b; c = c } : Box)
           { x = x; y = y } =
   a + b * x + c * y

let mapShape m = function 
  | Polygon { points = pts } ->
    Polygon { points = pts |> List.map m }
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

let mapBezier m = function 
| { controlPoint1 = cp1
    controlPoint2 = cp2
    endPoint = ep } ->
  { controlPoint1 = m cp1
    controlPoint2 = m cp2
    endPoint = m ep }

let isInnerEye name = 
  name = "eye-inner" || name = "egg-eye-inner"

let isOuterEye name = 
  name = "eye-outer" || name = "egg-eye-outer"

let getColor name = function 
  | Blackish -> 
    if name = "primary" then StyleColor.Black  
    else if isOuterEye name then StyleColor.White 
    else if isInnerEye name then StyleColor.Black 
    else StyleColor.White 
  | Greyish -> 
    if name = "primary" then StyleColor.Grey 
    else if isOuterEye name then StyleColor.White 
    else if isInnerEye name then StyleColor.Grey 
    else StyleColor.White 
  | Whiteish -> 
    if name = "primary" then StyleColor.White  
    else if isOuterEye name then StyleColor.White  
    else if isInnerEye name then StyleColor.Black 
    else StyleColor.Black

let getEyeLiner sw hue =  
  { strokeColor = getColor "secondary" hue 
    strokeWidth = sw }
    
let getPathStyle name sw hue = 
  let stroke = if isOuterEye name then Some <| getEyeLiner sw hue else None
  let fill = Some { fillColor = getColor name hue }
  { stroke = stroke; fill = fill }

let getDefaultColor name hue = 
  if name = "secondary" then 
    match hue with 
    | Blackish -> StyleColor.White
    | Greyish -> StyleColor.White
    | Whiteish -> StyleColor.Black
  else
    match hue with 
    | Blackish -> StyleColor.Black
    | Greyish -> StyleColor.Grey
    | Whiteish -> StyleColor.White

let getDefaultStyle name hue sw = 
  let stroke = 
    { strokeWidth = sw 
      strokeColor = getDefaultColor name hue }
  { stroke = Some stroke; fill = None }

let mapNamedShape (box : Box, hue : Hue) (name, shape) : (Shape * Style) = 
  let m = mapper box
  let sw = getStrokeWidth box
  match shape with
  | Polygon { points = pts } ->
    Polygon { points = pts |> List.map m }, getDefaultStyle name hue sw
  | Curve { point1 = v1
            point2 = v2 
            point3 = v3 
            point4 = v4 } ->
    Curve { point1 = m v1
            point2 = m v2 
            point3 = m v3 
            point4 = m v4 }, getDefaultStyle name hue sw
  | Path (start, beziers) ->
    let style = getPathStyle name sw hue
    Path (m start, beziers |> List.map (mapBezier m)), style
  | Line { lineStart = v1
           lineEnd = v2 } ->
    Line { lineStart = m v1 
           lineEnd = m v2 }, getDefaultStyle name hue sw
  | _ -> failwith "unmatched shape in mapNamedShape"

let createLensPicture (shapes : (string * Shape) list) : Picture = 
   fun lens ->
     shapes |> List.map (mapNamedShape lens)

let mirrorVector height { x = x; y = y } =
  { x = x; y = height - y }
  
let mirrorShape mirror = function 
    | Line { lineStart = lineStart 
             lineEnd = lineEnd } ->
      Line { lineStart = mirror lineStart 
             lineEnd = mirror lineEnd }
    | Polygon { points = pts } ->
      Polygon { points = pts |> List.map mirror }
    | Curve { point1 = v1
              point2 = v2 
              point3 = v3 
              point4 = v4 } ->
      Curve { point1 = mirror v1
              point2 = mirror v2 
              point3 = mirror v3 
              point4 = mirror v4 }
    | Path (start, beziers) ->        
      Path (mirror start, beziers |> List.map (mapBezier mirror))
    | x -> x

let getStrokeWidthFromStyle = function 
  | Some strokeStyle ->
    strokeStyle.strokeWidth
  | None -> 1.

let getStrokeColorFromStyle = function 
  | Some strokeStyle ->
    strokeStyle.strokeColor
  | None ->
    StyleColor.Black

let getStrokeColorName = function 
  | StyleColor.Black -> "black"
  | StyleColor.White -> "white"
  | StyleColor.Grey -> "grey"

let getStrokePen { strokeWidth = sw; strokeColor = sc } = 
  let color = 
    match sc with 
    | Black -> "black" 
    | Grey -> "grey"
    | White -> "white"
  (color, sw)

let getFillBrush { fillColor = fc } = 
  match fc with 
  | Black -> "black" 
  | Grey -> "grey"
  | White -> "white"
  
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
    | Curve { point1 = { x = x1; y = y1 }
              point2 = { x = x2; y = y2 } 
              point3 = { x = x3; y = y3 } 
              point4 = { x = x4; y = y4 } } ->
      let d = sprintf "M%f %f C %f %f, %f %f, %f %f" x1 y1 x2 y2 x3 y3 x4 y4
      let strokeWidth = getStrokeWidthFromStyle style.stroke
      let (strokeColor, sw) = 
        match style.stroke with 
        | Some stroke -> getStrokePen stroke
        | None -> ("none", strokeWidth)
      let fillColor = 
        match style.fill with 
        | Some fill -> getFillBrush fill
        | None -> "none"
      let curveElement =
        path 
          [ SVGAttr.Stroke strokeColor
            SVGAttr.Fill fillColor
            SVGAttr.StrokeWidth sw
            SVGAttr.StrokeLinecap "butt"
            SVGAttr.D d ] []
      curveElement
    | Path ({ x = x; y = y }, beziers) ->
      let nextShape { controlPoint1 = { x = x1; y = y1 }
                      controlPoint2 = { x = x2; y = y2 }
                      endPoint      = { x = x3; y = y3 } } =
        sprintf "C %f %f, %f %f, %f %f" x1 y1 x2 y2 x3 y3 
      let startStr = sprintf "M%f %f" x y
      let nextStrs = beziers |> List.map nextShape 
      let strs = nextStrs @ [ "Z" ]
      let d = startStr :: strs |> String.concat " "
      let strokeWidth = getStrokeWidthFromStyle style.stroke
      //let strokeColor = getStrokeColorFromStyle style.stroke
      //let colorName = getStrokeColorName strokeColor
      let (strokeColor, sw) = 
        match style.stroke with 
        | Some stroke -> getStrokePen stroke
        | None -> ("none", strokeWidth)
      let fillColor = 
        match style.fill with 
        | Some fill -> getFillBrush fill
        | None -> "none"
      let pathElement =
        path 
          [ SVGAttr.Stroke strokeColor
            SVGAttr.Fill fillColor
            SVGAttr.StrokeWidth sw
            SVGAttr.StrokeLinecap "butt"
            SVGAttr.D d ] []
      pathElement
    | _ -> failwith "unmatched shape in toSvgElement"

let getBackgroundColor = function 
  | Grey -> "#CCCCCC"
  | Black -> "black"
  | White -> "white"       

let view ((bounds, background, shapes) : Model) = 
    let (svgWidth, svgHeight) = bounds
    let mv = (mirrorVector <| float svgHeight)
    let fn (shape, style) = 
      (mirrorShape mv >> toSvgElement style) shape      
    let svgElements = shapes |> List.map fn
    svg [ Style [ BackgroundColor (getBackgroundColor background) ]
          HTMLAttr.Width svgWidth 
          HTMLAttr.Height svgHeight 
        ]     
        svgElements
