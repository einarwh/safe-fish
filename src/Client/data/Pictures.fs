module Data.Pictures

open Data.Shapes
open Data.Styling
open Data.Boxes

type Rendering = (Shape * Style) list

type Picture = Box -> Rendering 

let blank : Picture = fun _ -> []
