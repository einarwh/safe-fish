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
  let bounds = (440, 440)
  let box = { a = { x = 30.; y = 40. }
              b = { x = 380.; y = 0. }
              c = { x = 0.; y = 380. } }
  let shapes = box |> blank
  (bounds, [], shapes)
