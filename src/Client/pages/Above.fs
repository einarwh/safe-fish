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
  let shapes = box |> (above pf (above (turn pf) (turns 2 pf)) |> turn) 
  let b1, b2 = splitVertically 0.5 box 
  let b3, b4 = splitVertically 0.5 b2
  (bounds, [ box ], shapes)
