module Client.App

open Fable.Core
open Fable.Core.JsInterop

open Fable.Import
open Elmish
open Elmish.React
open Fable.Import.Browser
open Elmish.Browser.Navigation
open Elmish.HMR
open Client.Pages
open Client.Transforms

JsInterop.importSideEffects "whatwg-fetch"
JsInterop.importSideEffects "babel-polyfill"

// Model

type SubModel =
    | NoSubModel
    | TransformModel of Transforms.Model
    | StartModel of Start.Model
    | TurnModel of Turn.Model
    | FlipModel of Flip.Model
    | TossModel of Toss.Model
    | AboveModel of Above.Model
    | BesideModel of Beside.Model
    | QuartetModel of Quartet.Model
    | NonetModel of Nonet.Model
    | OverModel of Over.Model
    | TtileModel of Ttile.Model
    | UtileModel of Utile.Model
    | SideModel of Side.Model
    | CornerModel of Corner.Model
    | LimitModel of Limit.Model
    | HueModel of Hue.Model
    | XttileModel of Xttile.Model
    | XutileModel of Xutile.Model
    | XsideModel of Xttile.Model
    | XcornerModel of Xttile.Model
    | XlimitModel of Xttile.Model

type Model =
  { Page : Page
    Prev : Page option
    Next : Page option
    Menu : Menu.Model
    SubModel : SubModel }

let urlUpdate (result:Page option) model =
    match result with
    | None ->
        Browser.console.error("Error parsing url: " + Browser.window.location.href)
        ( model, Navigation.modifyUrl (toHash model.Page) )

    | Some (Page.Home as page) ->
        { model with
            Page = page
            Prev = None
            Next = Some Page.Henderson }, Cmd.none

    | Some (Page.Henderson as page) ->
        { model with
            Page = page
            Prev = Some Page.Home
            Next = Some Page.Keynote }, Cmd.none

    | Some (Page.Keynote as page) ->
        { model with
            Page = page
            Prev = Some Page.Henderson
            Next = Some Page.Sicp }, Cmd.none

    | Some (Page.Sicp as page) ->
        { model with
            Page = page
            Prev = Some Page.Keynote
            Next = Some Page.Safe }, Cmd.none

    | Some (Page.Safe as page) ->
        { model with
            Page = page
            Prev = Some Page.Sicp
            Next = Some Page.Abstraction }, Cmd.none

    | Some (Page.Abstraction as page) ->
        { model with
            Page = page
            Prev = Some Page.Safe
            Next = Some Page.Start }, Cmd.none

    | Some (Page.Start as page) ->
        let m = Start.init()
        { model with 
            Page = page
            Prev = Some Page.Abstraction
            Next = Some Page.Turn
            SubModel = StartModel m }, Cmd.none

    | Some (Page.Turn as page) ->
        let m = Turn.init()
        { model with 
            Page = page
            Prev = Some Page.Start
            Next = Some Page.Flip
            SubModel = TurnModel m }, Cmd.none

    | Some (Page.Flip as page) ->
        let m = Flip.init()
        { model with 
            Page = page
            Prev = Some Page.Turn
            Next = Some Page.Toss
            SubModel = FlipModel m }, Cmd.none

    | Some (Page.Toss as page) ->
        let m = Toss.init()
        { model with 
            Page = page
            Prev = Some Page.Flip
            Next = Some Page.Above
            SubModel = TossModel m }, []

    | Some (Page.Above as page) ->
        let m = Above.init()
        { model with 
            Page = page
            Prev = Some Page.Toss
            Next = Some Page.Beside
            SubModel = AboveModel m }, []

    | Some (Page.Beside as page) ->
        let m = Beside.init()
        { model with 
            Page = page
            Prev = Some Page.Above
            Next = Some Page.Quartet
            SubModel = BesideModel m }, []

    | Some (Page.Quartet as page) ->
        let m = Quartet.init()
        { model with 
            Page = page
            Prev = Some Page.Beside
            Next = Some Page.Nonet
            SubModel = QuartetModel m }, []

    | Some (Page.Nonet as page) ->
        let m = Nonet.init()
        { model with 
            Page = page
            Prev = Some Page.Quartet
            Next = Some Page.Over
            SubModel = NonetModel m }, []

    | Some (Page.Over as page) ->
        let m = Over.init()
        { model with 
            Page = page
            Prev = Some Page.Nonet
            Next = Some Page.Ttile
            SubModel = OverModel m }, []

    | Some (Page.Ttile as page) ->
        let m = Ttile.init()
        { model with 
            Page = page
            Prev = Some Page.Over
            Next = Some Page.Utile
            SubModel = TtileModel m }, []

    | Some (Page.Utile as page) ->
        let m = Utile.init()
        { model with 
            Page = page
            Prev = Some Page.Ttile
            Next = Some Page.Side
            SubModel = UtileModel m }, []

    | Some (Page.Side as page) ->
        let m = Side.init()
        { model with 
            Page = page
            Prev = Some Page.Utile
            Next = Some Page.Corner
            SubModel = SideModel m }, []

    | Some (Page.Corner as page) ->
        let m = Corner.init()
        { model with 
            Page = page
            Prev = Some Page.Side
            Next = Some Page.Limit
            SubModel = CornerModel m }, []

    | Some (Page.Limit as page) ->
        let m = Limit.init()
        { model with 
            Page = page
            Prev = Some Page.Corner
            Next = Some Page.Hue
            SubModel = LimitModel m }, []

    | Some (Page.Hue as page) ->
        let m = Hue.init()
        { model with 
            Page = page
            Prev = Some Page.Limit
            Next = Some Page.Xlimit
            SubModel = HueModel m }, []

    | Some (Page.Xttile as page) ->
        let m = Xttile.init()
        { model with 
            Page = page
            Prev = Some Page.Hue
            Next = Some Page.Xutile
            SubModel = XttileModel m }, []

    | Some (Page.Xutile as page) ->
        let m = Xutile.init()
        { model with 
            Page = page
            Prev = Some Page.Xttile
            Next = Some Page.Xside
            SubModel = XutileModel m }, []

    | Some (Page.Xside as page) ->
        let m = Xside.init()
        { model with 
            Page = page
            Prev = Some Page.Xutile
            Next = Some Page.Xcorner
            SubModel = XsideModel m }, []

    | Some (Page.Xcorner as page) ->
        let m = Xcorner.init()
        { model with 
            Page = page
            Prev = Some Page.Xside
            Next = Some Page.Xlimit
            SubModel = XcornerModel m }, []

    | Some (Page.Xlimit as page) ->
        let m = Xlimit.init()
        { model with 
            Page = page
            Prev = Some Page.Hue
            Next = None
            SubModel = XlimitModel m }, []

let init result =
    let menu,menuCmd = Menu.init()
    let m =
        { Page = Page.Home
          Next = Some Page.Henderson
          Prev = None
          Menu = menu
          SubModel = NoSubModel }

    let m,cmd = urlUpdate result m
    m,Cmd.batch[cmd; menuCmd]

let update _ model = model, Cmd.none

// VIEW

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Client.Style

let heading text = p [ ClassName "heading" ] [ str text ]
let subheading text = p [ ClassName "subheading" ] [ str text]

let spacing = div [ Style [ Padding "12px" ] ] []

let matchfail text = [ p [] [ str <| sprintf "pattern match fail %s" text ] ]

/// Constructs the view for a page given the model and dispatcher.
let viewPage model dispatch =
    match model.Page with
    | Page.Home ->
        [ heading "Functional geometry"
          heading "Picture combinators & recursive fish"
          heading "Einar W. Høst"
          p [] []
          img [ Src "images/escher-square-limit.png" ]  ]

    | Page.Henderson ->
        [ heading "Peter Henderson"
          heading "Functional geometry (1982, 2002)"
          p [] []
          img [ Src "images/henderson.png" ]  ]

    | Page.Keynote ->
        [ heading "Inspiration for this talk"
          p [] []
          img [ Src "images/why-fp.png" ]  ]

    | Page.Sicp ->
        [ heading "SICP videos"
          p [] []
          img [ Src "images/sicp-3A.png" ]  ]

    | Page.Abstraction ->
        [ heading "abstraction"
          p [] []
          img [ Src "images/abstraction.jpg" ]  ]

    | Page.Safe ->
        [ heading "F# inside"
          p [] []
          img [ Src "images/safe-logo.png" ]  ]

    | Page.Start ->
        match model.SubModel with
        | StartModel m -> 
            [ heading "picture"
              subheading "type Picture = Box -> Rendering"
              spacing
              Transforms.view <| Start.transform m ]
        | _ -> matchfail "picture"

    | Page.Turn ->
        match model.SubModel with
        | TurnModel m -> 
            [ heading "turn"
              subheading "(a’, b’, c’) = (a + b, c, -b)"
              spacing             
              Transforms.view <| Turn.transform m ]
        | _ -> matchfail "turn"

    | Page.Flip ->
        match model.SubModel with
        | FlipModel m -> 
            [ heading "flip"
              subheading "(a’, b’, c’) = (a + b, -b, c)"
              spacing
              Transforms.view <| Flip.transform m ]
        | _ -> matchfail "flip"

    | Page.Toss ->
        match model.SubModel with
        | TossModel m ->
            [ heading "toss"
              subheading "(a’, b’, c’) = (a + (b + c) / 2, (b + c) / 2, (c − b) / 2)"
              spacing
              Transforms.view <| Toss.transform m ]
        | _ -> matchfail "toss"

    | Page.Above ->
        match model.SubModel with
        | AboveModel m ->
            [ heading "above" 
              subheading "put first picture above second picture"
              spacing
              Transforms.view <| Above.transform m ]
        | _ -> matchfail "above"

    | Page.Beside ->
        match model.SubModel with
        | BesideModel m ->
            [ heading "beside"
              subheading "put first picture to the left of second picture" 
              spacing
              Transforms.view <| Beside.transform m ]
        | _ -> matchfail "beside"

    | Page.Quartet ->
        match model.SubModel with
        | QuartetModel m ->
            [ heading "quartet" 
              subheading "create a quartet of four pictures" 
              spacing
              Transforms.view <| Quartet.transform m ]
        | _ -> matchfail "quartet"

    | Page.Nonet ->
        match model.SubModel with
        | NonetModel m ->
            [ heading "nonet"
              subheading "create a nonet of nine pictures"
              spacing
              Transforms.view <| Nonet.transform m ]
        | _ -> matchfail "nonet"

    | Page.Over ->
        match model.SubModel with
        | OverModel m ->
            [ heading "over"
              subheading "overlay two pictures inside the same box"
              spacing
              Transforms.view <| Over.transform m ]
        | _ -> matchfail "over"

    | Page.Ttile ->
        match model.SubModel with
        | TtileModel m ->
            [ heading "ttile"
              subheading "create the t-tile in square limit"
              spacing
              Transforms.view <| Ttile.transform m ]
        | _ -> matchfail "ttile"

    | Page.Utile ->
        match model.SubModel with
        | UtileModel m ->
            [ heading "utile"
              subheading "create the u-tile in square limit" 
              spacing
              Transforms.view <| Utile.transform m ]
        | _ -> matchfail "utile"

    | Page.Side ->
        match model.SubModel with
        | SideModel m ->
            [ heading "side"
              spacing
              Transforms.view <| Side.transform m ]
        | _ -> matchfail "side"

    | Page.Corner ->
        match model.SubModel with
        | CornerModel m ->
            [ heading "corner"
              spacing
              Transforms.view <| Corner.transform m ]
        | _ -> matchfail "corner"

    | Page.Limit ->
        match model.SubModel with
        | LimitModel m ->
            [ heading "square limit"
              subheading "Henderson's replica of square limit" 
              Transforms.view <| Limit.transform m ]
        | _ -> matchfail "square limit"

    | Page.Hue ->
        match model.SubModel with
        | HueModel m ->
            [ heading "hue"
              spacing
              Reform.view <| Hue.transform m 
            ]
        | _ -> matchfail "hue"

    | Page.Xttile ->
        match model.SubModel with
        | XttileModel m ->
            [ heading "ttile" 
              spacing
              Reform.view <| Xttile.transform m 
            ]
        | _ -> matchfail "xttile"

    | Page.Xutile ->
        match model.SubModel with
        | XutileModel m ->
            [ heading "utile"
              spacing
              Reform.view <| Xutile.transform m 
            ]
        | _ -> matchfail "xutile"

    | Page.Xside ->
        match model.SubModel with
        | XsideModel m ->
            [ heading "side"
              spacing
              Reform.view <| Xside.transform m 
            ]
        | _ -> matchfail "xside"

    | Page.Xcorner ->
        match model.SubModel with
        | XcornerModel m ->
            [ heading "corner"
              spacing
              Reform.view <| Xcorner.transform m 
            ]
        | _ -> matchfail "xcorner pattern match fail"

    | Page.Xlimit ->
        match model.SubModel with
        | XlimitModel m ->
            [ heading "square limit"
              Reform.view <| Xlimit.transform m 
            ]
        | _ -> matchfail "xlimit"

/// Constructs the view for the application given the model.
let view model dispatch =
  let next =  
    let link = 
      match model.Next with 
      | Some pg -> viewLink pg "=>"
      | None -> 
        str ""
    span [ Style [ Float "right"] ] 
         [ link  ]
  let prev =  
    let link = 
      match model.Prev with 
      | Some pg -> viewLink pg "<="
      | None -> 
        str ""
    span [ Style [ Float "left"] ] 
         [ link ]
  div []
    [ // Menu.view model.Menu (MenuMsg >> dispatch)
      div [ Style [ BackgroundColor "black"
                    Color "white"
                    Padding "4px" ] ] 
          [ span [ Style [ Float "right"] ] 
                 [ str "@einarwh" ]
            span [] [ str "Functional geometry" ] ]
      div [ centerStyle "column" ] (viewPage model dispatch)
      div [ Style [ BackgroundColor "black"
                    Color "white"
                    Padding "4px"
                    Position "fixed"
                    Bottom "0px"
                    ZIndex 100.
                    Width "100%" ] ]
          [ next; prev ] ]

open Elmish.React
open Elmish.Debug

// App
Program.mkProgram init update view
|> Program.toNavigable Pages.urlParser urlUpdate
#if DEBUG
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
