module Client.Pict

open Data.Vectors
open Data.Letters
open Data.Boxes
open Data.Pictures
open Transforms

type Model = Picture

let init() : Model = 
  createPicture [ fShape ]
  
let transform p : Transforms.Model = 
  let bounds = (300, 300)
  let box = { a = { x = 50.; y = 50. }
              b = { x = 120.; y = 100. }
              c = { x = 150.; y = 200. } }
  let shapes = p box
  (bounds, [ box ], shapes)
