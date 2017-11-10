module Client.Xttile

open Data.Vectors
open Data.Fishier
open Data.Boxes
open Data.Lenses
open Data.Shades
open Data.Styling
open Reform

type Model = Picture

let init() : Model = 
  createLensPicture fishShapes

let transform p : Reform.Model = 
  let bounds = (550, 250)
  let box = { a = { x = 50.; y = 50. }
              b = { x = 450.; y = 0. }
              c = { x = 0.; y = 150. } }  
  let lens = (box, Whiteish)
  let shapes = lens |> blank
  (bounds, Grey, shapes)
