module Data.Pictures

open Data.Shapes
open Data.Styling
open Data.Boxes

type Rendering = (Shape * Style) list

type Picture = Box -> Rendering 

let blank : Picture = fun _ -> []

let turn p = turnBox >> p

let rec times n fn = 
  if n = 0 then id
  else fn >> times (n - 1) fn

let turns n = times n turn

let flip p = flipBox >> p

let toss p = tossBox >> p

let aboveRatio m n (p1 : Picture) (p2 : Picture) = 
  fun box ->
    let factor = (float m) / (float (m + n))
    let b1, b2 = splitVertically factor box
    p1 b1 @ p2 b2

let above = aboveRatio 1 1

let besideRatio m n (p1 : Picture) (p2 : Picture) = 
  fun box ->
    let factor = (float m) / (float (m + n))
    let b1, b2 = splitHorizontally factor box
    p1 b1 @ p2 b2

let beside = besideRatio 1 1

let quartet nw ne sw se = 
  (above (beside nw ne)
         (beside sw se))

let rec row = function
  | [] -> blank
  | [p] -> p
  | p::ps -> besideRatio 1 (List.length ps) p (row ps)

let rec column = function
  | [] -> blank
  | [p] -> p
  | p::ps -> aboveRatio 1 (List.length ps) p (column ps)

let nonet nw nm ne mw mm me sw sm se =
  [ [nw;nm;ne]; [mw;mm;me]; [sw;sm;se] ]
  |> List.map row
  |> column

let over p1 p2 = 
  fun box -> 
    p1 box @ p2 box

let ttile fish = 
  let fishN = fish |> toss |> flip
  let fishE = fishN |> turns 3
  over fish (over fishN fishE)

let utile fish = 
  let fishN = fish |> toss |> flip
  let fishW = turn fishN
  let fishS = turn fishW
  let fishE = turn fishS
  over (over fishN fishS) 
       (over fishE fishW)

