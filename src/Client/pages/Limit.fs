module Client.Limit

open Data.Vectors
open Data.Fishy
open Data.Boxes
open Data.Pictures
open Transforms

type Model = Picture

let init() : Model = 
  createPicture hendersonFishShapes 

let transform (p : Model) : Transforms.Model =
  let bounds = (450, 450)
  let box = { a = { x = 10.; y = 10. }
              b = { x = 430.; y = 0. }
              c = { x = 0.; y = 430. } }
  let shapes' = box |> squareLimit 3 p
  (bounds, [], shapes')
