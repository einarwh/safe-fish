module Client.Turn

open Data.Vectors
open Data.Letters
open Data.Figures
open Data.Boxes
open Data.Pictures
open Transforms

type Model = 
  { letter : Picture
    figure : Picture }

let init() : Model = 
  { letter = createPicture fLetter
    figure = createPicture george }

let transform { letter = letter; figure = figure } 
  : Transforms.Model = 
  let bounds = (300, 300)
  let box = { a = { x = 50.; y = 50. }
              b = { x = 200.; y = 0. }
              c = { x = 0.; y = 200. } }
  // let double n = n + n
  // double 10 
  // 10 |> double 
  let shapes = box |> turns 4 letter
  (bounds, [ times 4 turnBox box ], shapes)
