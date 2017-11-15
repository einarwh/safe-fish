module Client.Over

open Data.Vectors
open Data.Fishy
open Data.Boxes
open Data.Pictures
open Transforms

type Model = Picture

let init() : Model = 
  createPicture hendersonFishShapes 
  
let transform (p : Model) : Transforms.Model =
  let bounds = (300, 300)
  let box = { a = { x = 50.; y = 50. }
              b = { x = 200.; y = 0. }
              c = { x = 0.; y = 200. } }
  let shapes = box |> over p (turns 2 p) 
  (bounds, [], shapes)
