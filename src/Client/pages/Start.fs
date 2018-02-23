module Client.Start

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

let transform { letter = letter; figure = figure } : Transforms.Model = 
  let bounds = (300, 300)
  let box = { a = { x = 80.; y = 50. }
              b = { x = 100.; y = 20. }
              c = { x = 20.; y = 150. } }
  let shapes = box |> figure
  (bounds, [ box ], shapes)
