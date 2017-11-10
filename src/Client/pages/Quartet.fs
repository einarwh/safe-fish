module Client.Quartet

open Data.Vectors
open Data.Letters
open Data.Figures
open Data.Boxes
open Data.Pictures
open Transforms
open Fable.Helpers.React

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
  let ne = figure |> turns 2 |> flip
  let sw = figure |> turns 2
  let se = figure |> flip
  let q = quartet nw ne sw se
  let qq = quartet q blank blank q
  let pattern p = quartet p p p p
  let shapes = box |> (qq |> pattern |> pattern |> pattern)
  (bounds, [], shapes)
  
