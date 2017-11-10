module Data.Letters

open Data.Vectors
open Data.Shapes

let fShape = 
  let pts = [ 
    { x = 0.30; y = 0.20 } 
    { x = 0.40; y = 0.20 }
    { x = 0.40; y = 0.45 }
    { x = 0.60; y = 0.45 }
    { x = 0.60; y = 0.55 }
    { x = 0.40; y = 0.55 }
    { x = 0.40; y = 0.70 }
    { x = 0.70; y = 0.70 }
    { x = 0.70; y = 0.80 }
    { x = 0.30; y = 0.80 } ]
  Polygon { points = pts }

let fLetter = [ fShape ]

let hShape = 
  let pt01 =  { x = 0.30; y = 0.20 } 
  let pt02 =  { x = 0.40; y = 0.20 } 
  let pt03 =  { x = 0.40; y = 0.45 } 
  let pt04 =  { x = 0.60; y = 0.45 } 
  let pt05 =  { x = 0.60; y = 0.20 } 
  let pt06 =  { x = 0.70; y = 0.20 } 
  let pt07 =  { x = 0.70; y = 0.80 } 
  let pt08 =  { x = 0.60; y = 0.80 } 
  let pt09 =  { x = 0.60; y = 0.55 } 
  let pt10 =  { x = 0.40; y = 0.55 } 
  let pt11 =  { x = 0.40; y = 0.80 } 
  let pt12 =  { x = 0.30; y = 0.80 } 
  let pts = [ pt01; pt02; pt03; pt04; pt05; pt06; pt07; pt08; pt09; pt10; pt11; pt12 ]
  Polygon { points = pts }

let hLetter = [ hShape ]

let eShape = 
  let pt01 =  { x = 0.30; y = 0.20 } 
  let pt02 =  { x = 0.70; y = 0.20 } 
  let pt03 =  { x = 0.70; y = 0.30 } 
  let pt04 =  { x = 0.40; y = 0.30 } 
  let pt05 =  { x = 0.40; y = 0.45 } 
  let pt06 =  { x = 0.60; y = 0.45 } 
  let pt07 =  { x = 0.60; y = 0.55 } 
  let pt08 =  { x = 0.40; y = 0.55 } 
  let pt09 =  { x = 0.40; y = 0.70 } 
  let pt10 =  { x = 0.70; y = 0.70 } 
  let pt11 =  { x = 0.70; y = 0.80 } 
  let pt12 =  { x = 0.30; y = 0.80 } 
  let pts = [ pt01; pt02; pt03; pt04; pt05; pt06; pt07; pt08; pt09; pt10; pt11; pt12 ]
  Polygon { points = pts }

let eLetter = [ eShape ]

let nShape = 
  let pt01 =  { x = 0.30; y = 0.20 } 
  let pt02 =  { x = 0.40; y = 0.20 } 
  let pt03 =  { x = 0.40; y = 0.60 } 
  let pt04 =  { x = 0.60; y = 0.20 } 
  let pt05 =  { x = 0.70; y = 0.20 } 
  let pt06 =  { x = 0.70; y = 0.80 } 
  let pt07 =  { x = 0.60; y = 0.80 } 
  let pt08 =  { x = 0.60; y = 0.40 } 
  let pt09 =  { x = 0.40; y = 0.80 } 
  let pt10 =  { x = 0.30; y = 0.80 } 
  let pts = [ pt01; pt02; pt03; pt04; pt05; pt06; pt07; pt08; pt09; pt10 ]
  Polygon { points = pts }

let nLetter = [ nShape ]

let dShape1 = 
  let pt01 =  { x = 0.30; y = 0.20 } 
  let pt02 =  { x = 0.55; y = 0.20 } 
  let pt03 =  { x = 0.70; y = 0.35 } 
  let pt04 =  { x = 0.70; y = 0.65 } 
  let pt05 =  { x = 0.55; y = 0.80 } 
  let pt06 =  { x = 0.30; y = 0.80 } 
  let pts = [ pt01; pt02; pt03; pt04; pt05; pt06 ]
  Polygon { points = pts }

let dShape2 = 
  let pt01 =  { x = 0.40; y = 0.30 } 
  let pt02 =  { x = 0.52; y = 0.30 } 
  let pt03 =  { x = 0.60; y = 0.38 } 
  let pt04 =  { x = 0.60; y = 0.62 } 
  let pt05 =  { x = 0.52; y = 0.70 } 
  let pt06 =  { x = 0.40; y = 0.70 } 
  let pts = [ pt01; pt02; pt03; pt04; pt05; pt06 ]
  Polygon { points = pts }

let dLetter = [ dShape1; dShape2 ]

let rShape1 = 
  let pt01 =  { x = 0.30; y = 0.20 } 
  let pt02 =  { x = 0.40; y = 0.20 } 
  let pt03 =  { x = 0.40; y = 0.45 } 
  let pt03a = { x = 0.45; y = 0.45 } 
  let pt04 =  { x = 0.60; y = 0.20 } 
  let pt05 =  { x = 0.70; y = 0.20 } 
  let pt06 =  { x = 0.55; y = 0.45 } 
  let pt07 =  { x = 0.70; y = 0.45 } 
  let pt08 =  { x = 0.70; y = 0.80 } 
  let pt09 =  { x = 0.30; y = 0.80 } 
  let pts = [ pt01; pt02; pt03; pt03a; pt04; pt05; pt06; pt07; pt08; pt09 ]
  Polygon { points = pts }

let rShape2 = 
  let pt05 =  { x = 0.40; y = 0.55 } 
  let pt06 =  { x = 0.60; y = 0.55 } 
  let pt07 =  { x = 0.60; y = 0.70 } 
  let pt08 =  { x = 0.40; y = 0.70 } 
  let pts = [ pt05; pt06; pt07; pt08 ]
  Polygon { points = pts }

let rLetter = [ rShape1; rShape2 ]

let sShape = 
  let pt01 =  { x = 0.30; y = 0.20 } 
  let pt02 =  { x = 0.70; y = 0.20 } 
  let pt03 =  { x = 0.70; y = 0.55 } 
  let pt04 =  { x = 0.40; y = 0.55 } 
  let pt05 =  { x = 0.40; y = 0.70 } 
  let pt06 =  { x = 0.70; y = 0.70 } 
  let pt07 =  { x = 0.70; y = 0.80 } 
  let pt08 =  { x = 0.30; y = 0.80 } 
  let pt09 =  { x = 0.30; y = 0.45 } 
  let pt10 =  { x = 0.60; y = 0.45 } 
  let pt11 =  { x = 0.60; y = 0.30 } 
  let pt12 =  { x = 0.30; y = 0.30 } 
  let pts = [ pt01; pt02; pt03; pt04; pt05; pt06; pt07; pt08; pt09; pt10; pt11; pt12 ]
  Polygon { points = pts }

let sLetter = [ sShape ]

let oShape1 = 
  let pt01 =  { x = 0.30; y = 0.20 } 
  let pt02 =  { x = 0.70; y = 0.20 } 
  let pt03 =  { x = 0.70; y = 0.80 } 
  let pt04 =  { x = 0.30; y = 0.80 } 
  let pts = [ pt01; pt02; pt03; pt04 ]
  Polygon { points = pts }

let oShape2 = 
  let pt05 =  { x = 0.40; y = 0.30 } 
  let pt06 =  { x = 0.60; y = 0.30 } 
  let pt07 =  { x = 0.60; y = 0.70 } 
  let pt08 =  { x = 0.40; y = 0.70 } 
  let pts = [ pt05; pt06; pt07; pt08 ]
  Polygon { points = pts }

let oLetter = [ oShape1; oShape2 ]
