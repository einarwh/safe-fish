module Client.Side

open Data.Vectors
open Data.Fishy
open Data.Boxes
open Data.Pictures
open Transforms

type Model = Picture

let init() : Model = 
  createPicture hendersonFishShapes 
  
let transform (p : Model) : Transforms.Model =
  let bounds = (400, 400)
  let box = { a = { x = 50.; y = 50. }
              b = { x = 300.; y = 0. }
              c = { x = 0.; y = 300. } }
  let shapes = box |> blank
  (bounds, [], shapes)
