module Client.Nonet

open Data.Vectors
open Data.Letters
open Data.Boxes
open Data.Pictures
open Transforms

type Model = 
  {
    nw : Picture
    nm : Picture
    ne : Picture
    mw : Picture
    mm : Picture
    me : Picture
    sw : Picture
    sm : Picture
    se : Picture    
  }

let init() : Model = 
  let p = createPicture
  { 
    nw = p hLetter
    nm = p eLetter
    ne = p nLetter
    mw = p dLetter
    mm = p eLetter
    me = p rLetter
    sw = p sLetter
    sm = p oLetter
    se = p nLetter
  }

let transform { nw = nw; nm = nm; ne = ne; 
                mw = mw; mm = mm; me = me; 
                sw = sw; sm = sm; se = se } : Transforms.Model =
  let bounds = (400, 400)
  let box = { a = { x = 40.; y = 60. }
              b = { x = 320.; y = 0. }
              c = { x = 0.; y = 320. } }
  let h = nonet nw nm ne mw mm me sw sm se
  let fiver p = nonet p blank p blank p blank p blank p
  let shapes = box |> (h |> fiver |> fiver)
  (bounds, [], shapes)
