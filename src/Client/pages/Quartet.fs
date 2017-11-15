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
  let p = letter
  let nw = p 
  let ne = p |> turns 2 |> flip
  let sw = p |> turns 2 
  let se = p |> flip
  let q = quartet nw ne sw se 
  let qq = quartet q blank blank q 
  let quartet1 p = quartet p p p p 
  let shapes = box |> times 3 quartet1 qq
  (bounds, [], shapes)
  
