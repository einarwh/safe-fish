module Client.Xcorner

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
  let bounds = (500, 250)
  let box = { a = { x = 50.; y = 50. }
              b = { x = 400.; y = 0. }
              c = { x = 0.; y = 200. } }   
  (bounds, Grey, [])