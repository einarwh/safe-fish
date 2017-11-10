module Client.Pages

open Elmish.Browser.UrlParser

[<RequireQualifiedAccess>]
type Page = 
    | Home
    | Keynote
    | Henderson
    | Sicp
    | Abstraction
    | Safe
    | Start
    | Turn
    | Flip
    | Toss
    | Above
    | Beside
    | Quartet
    | Nonet
    | Over
    | Ttile
    | Utile
    | Side
    | Corner
    | Limit
    | Hue
    | Xttile
    | Xutile
    | Xside
    | Xcorner
    | Xlimit

let toHash =
    function
    | Page.Home -> "#home"
    | Page.Henderson -> "#henderson"
    | Page.Keynote -> "#keynote"
    | Page.Sicp -> "#sicp"
    | Page.Abstraction -> "#abstraction"
    | Page.Safe -> "#safe"
    | Page.Start -> "#picture"
    | Page.Turn -> "#turn"
    | Page.Flip -> "#flip"
    | Page.Toss -> "#toss"
    | Page.Above -> "#above"
    | Page.Beside -> "#beside"
    | Page.Quartet -> "#quartet"
    | Page.Nonet -> "#nonet"
    | Page.Over -> "#over"
    | Page.Ttile -> "#ttile"
    | Page.Utile -> "#utile"
    | Page.Side -> "#side"
    | Page.Corner -> "#corner"
    | Page.Limit -> "#limit"
    | Page.Hue -> "#hue"
    | Page.Xttile -> "#xttile"
    | Page.Xutile -> "#xutile"
    | Page.Xside -> "#xside"
    | Page.Xcorner -> "#xcorner"
    | Page.Xlimit -> "#xlimit"

/// The URL is turned into a Result.
let pageParser : Parser<Page -> Page,_> =
    oneOf
        [ map Page.Home (s "home")
          map Page.Henderson (s "henderson")
          map Page.Keynote (s "keynote")
          map Page.Sicp (s "sicp")
          map Page.Abstraction (s "abstraction")
          map Page.Safe (s "safe")
          map Page.Start (s "picture")
          map Page.Turn (s "turn")
          map Page.Flip (s "flip")
          map Page.Toss (s "toss") 
          map Page.Above (s "above") 
          map Page.Beside (s "beside") 
          map Page.Quartet (s "quartet") 
          map Page.Nonet (s "nonet") 
          map Page.Over (s "over") 
          map Page.Ttile (s "ttile") 
          map Page.Utile (s "utile") 
          map Page.Side (s "side") 
          map Page.Corner (s "corner") 
          map Page.Limit (s "limit") 
          map Page.Hue (s "hue") 
          map Page.Xttile (s "xttile") 
          map Page.Xutile (s "xutile") 
          map Page.Xside (s "xside") 
          map Page.Xcorner (s "xcorner") 
          map Page.Xlimit (s "xlimit") 
        ]

let urlParser location = parseHash pageParser location