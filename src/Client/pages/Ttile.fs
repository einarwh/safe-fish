module Client.Ttile

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
  let box = { a = { x = 75.; y = 75. }
              b = { x = 250.; y = 0. }
              c = { x = 0.; y = 250. } }
  let shapes1 = box |> p
  (bounds, [], shapes1)
