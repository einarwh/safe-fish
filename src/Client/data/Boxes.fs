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