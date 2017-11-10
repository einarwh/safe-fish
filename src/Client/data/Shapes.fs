module Data.Shapes

open Data.Vectors

type PolygonShape = 
  { points : Vector list }

type PolylineShape = 
  { pts : Vector list }

type CurveShape = 
  { point1 : Vector
    point2 : Vector
    point3 : Vector
    point4 : Vector }

type BezierShape = 
  { controlPoint1 : Vector
    controlPoint2 : Vector
    endPoint : Vector }

type LineShape = 
  { lineStart : Vector 
    lineEnd : Vector}

type Shape =
  | Polygon of PolygonShape
  | Polyline of PolylineShape
  | Curve of CurveShape
  | Path of Vector * BezierShape list
  | Line of LineShape

