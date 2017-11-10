module Data.Lenses

open Data.Boxes

type Hue = Blackish | Greyish | Whiteish

type Lens = Box * Hue

(*
let turnLens (box, hue : Hue) = (turnBox box, hue)

let flipLens (box, hue : Hue) = (flipBox box, hue)
 
let tossLens (box, hue : Hue) = (tossBox box, hue)

let scaleLensHorizontally s (box, hue : Hue) = 
    (scaleHorizontally s box, hue)

let scaleLensVertically s (box, hue : Hue) =  
    (scaleVertically s box, hue)

let moveLensHorizontally offset (box, hue : Hue) = 
    (moveHorizontally offset box, hue)
  
let moveLensVertically offset (box, hue : Hue) = 
    (moveVertically offset box, hue)

let splitLensHorizontally f (box, hue : Hue) =
    let box1, box2 = splitHorizontally f box
    (box1, hue), (box2, hue)

let splitLensVertically f (box, hue) = 
    let box1, box2 = splitVertically f box
    (box1, hue), (box2, hue)

let rehueLens (box : Box, hue : Hue) = 
  let change = function 
  | Whiteish -> Blackish
  | Greyish -> Whiteish
  | Blackish -> Greyish
  (box, change hue)
  *)