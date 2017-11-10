module Data.Vectors

type Vector = 
  { x : float
    y : float }

  static member (+) ({ x = x1; y = y1 }, { x = x2; y = y2 }) = 
      { x = x1 + x2; y = y1 + y2 } 

  static member (~-) { x = x1; y = y1 } = 
      { x = -x1; y = -y1 }

  static member (-) (v1 : Vector, v2 : Vector) =
      v1 + (-v2)

  static member (*) (f, { x = x; y = y }) = 
      { x = f * x; y = f * y }     

  static member (*) (v : Vector, f : float) = f * v

  static member (/) (v : Vector, f : float) = v * (1. / f)

