module Data.Boxes

open Data.Vectors

type Box = { a : Vector; b : Vector; c : Vector}

let turnBox { a = a; b = b; c = c } = 
  { a = a + b; b = c; c = -b }

let flipBox { a = a; b = b; c = c } = 
  { a = a + b; b = -b; c = c }

// (a + (b + c) / 2, (b + c) / 2, (c − b) / 2)
let tossBox { a = a; b = b; c = c } = 
  { a = a + (b + c) / 2.
    b = (b + c) / 2.
    c = (c - b) / 2. }

let moveVertically f { a = a; b = b; c = c } = 
  { a = a + f * c; b = b; c = c }

let scaleVertically f { a = a; b = b; c = c } = 
  { a = a; b = b; c = c * f } 

let moveHorizontally f { a = a; b = b; c = c } = 
  { a = a + f * b; b = b; c = c }

let scaleHorizontally f { a = a; b = b; c = c } = 
  { a = a; b = b * f; c = c } 

let splitVertically f box = 
  let top = box |> moveVertically (1. - f) |> scaleVertically f
  let bot = box |> scaleVertically (1. - f)
  (top, bot)

let splitHorizontally f box = 
  let left = box |> scaleHorizontally f
  let right = box |> moveHorizontally f |> scaleHorizontally (1. - f)
  (left, right)