module Client.Toss

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
  let box = { a = { x = 75.; y = 50. }
              b = { x = 150.; y = 0. }
              c = { x = 0.; y = 150. } }
  let shapes = box |> figure
  (bounds, [ box ], shapes)
  