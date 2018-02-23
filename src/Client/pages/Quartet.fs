module Client.Quartet

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
  let bounds = (400, 400)
  let box = { a = { x = 50.; y = 50. }
              b = { x = 300.; y = 0. }
              c = { x = 0.; y = 300. } }
  let nw = figure 
  let ne = figure |> flip |> turns 2  
  let sw = figure |> turns 2
  let se = figure |> flip 
  let pattern p = quartet blank p p blank 
  let qq p = quartet p p p p 
  let shapes = box |> (quartet nw ne sw se |> pattern |> times 2 qq)
  (bounds, [], shapes)
  
