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
