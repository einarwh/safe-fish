module Client.Above

open Data.Vectors
open Data.Letters
open Data.Boxes
open Data.Pictures
open Transforms

type Model = Picture * Picture

let init() : Model = 
  let pf = createPicture fLetter
  let pn = createPicture nLetter
  pf, pn

let transform ((pf, pn) : Model) : Transforms.Model =
  let bounds = (300, 300)
  let box = { a = { x = 50.; y = 50. }
              b = { x = 200.; y = 0. }
              c = { x = 0.; y = 200. } }
  let shapes = box |> (aboveRatio 1 4 pf pn)
  let b1, b2 = splitVertically 0.2 box
  (bounds, [ b1; b2 ], shapes)
