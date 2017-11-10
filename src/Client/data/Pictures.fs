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
