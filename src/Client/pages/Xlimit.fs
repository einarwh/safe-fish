module Client.Xlimit

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
  let bounds = (460, 460)
  let box = { a = { x = 30.; y = 40. }
              b = { x = 400.; y = 0. }
              c = { x = 0.; y = 400. } }   
  let lens = (box, Greyish)           
  let shapes = lens |> blank
  (bounds, White, shapes)