module Data.Pictures

open Data.Shapes
open Data.Styling
open Data.Boxes

type Rendering = (Shape * Style) list

type Picture = Box -> Rendering 

let blank : Picture = fun _ -> []

let rec times n fn = 
  if n = 0 then id 
  else fn >> times (n - 1) fn 

let turn (p : Picture) : Picture = 
  turnBox >> p 

let turns n = times n turn 

let flip p = flipBox >> p 

let toss p = tossBox >> p 

let aboveRatio (m : int) (n : int) (p1 : Picture) (p2 : Picture) = 
  fun box ->
    let f = float m / float (m + n) 
    let b1, b2 = splitVertically f box 
    p1 b1 @ p2 b2 

let above = aboveRatio 1 1

let besideRatio (m : int) (n : int) (p1 : Picture) (p2 : Picture) = 
  fun box ->
    let f = float m / float (m + n) 
    let b1, b2 = splitHorizontally f box 
    p1 b1 @ p2 b2 

let beside = besideRatio 1 1

let quartet nw ne sw se = 
  above (beside nw ne)
        (beside sw se)

let rec row = function 
  | [] -> blank 
  | p :: ps ->
    besideRatio 1 (List.length ps) p (row ps)

let rec column = function 
  | [] -> blank 
  | p :: ps ->
    aboveRatio 1 (List.length ps) p (column ps)


let nonet nw nm ne mw mm me sw sm se = 
  [ [nw; nm; ne]
    [mw; mm; me]
    [sw; sm; se] ]
  |> List.map row 
  |> column 

let over ps = 
  fun box -> List.collect (fun p -> p box) ps 

let ttile fish = 
  let fishN = fish |> toss |> flip 
  let fishE = fishN |> turns 3
  over [ fish; fishN; fishE ]

let utile fish = 
  let fishN = fish |> toss |> flip 
  let fishW = turn fishN
  let fishS = turn fishW
  let fishE = turn fishS
  over [ fishN; fishW; fishS; fishE ]

let rec side n fish = 
  let s = if n = 1 then blank else side (n - 1) fish 
  let t = ttile fish 
  quartet s s (turn t) t

let rec corner n fish = 
  let c, s = 
    if n = 1 then blank, blank 
    else corner (n - 1) fish, side (n - 1) fish 
  quartet c s (turn s) (utile fish)

let squareLimit n fish = 
  let c = corner n fish 
  let s = side n fish 
  let nw = c 
  let nm = s 
  let ne = c |> turns 3
  let mw = s |> turn 
  let mm = utile fish 
  let me = s |> turns 3
  let sw = c |> turn 
  let sm = s |> turns 2
  let se = c |> turns 2
  nonet nw nm ne mw mm me sw sm se






