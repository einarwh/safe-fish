module Client.Menu

open Elmish
open Fable.Helpers.React
open Client.Style
open Client.Pages

type Model = {
    Next : Page option
}

type Msg =
    | Logout

let init() = { Next = None }, Cmd.none

let update (msg:Msg) model : Model*Cmd<Msg> = 
    match msg with
    | Logout ->
        model, Cmd.none

let view (model:Model) dispatch =
    div [ centerStyle "row" ] [
          yield viewLink Page.Home "Home"
          if model.Next.IsSome then 
              yield viewLink model.Next.Value "Next"
        ]