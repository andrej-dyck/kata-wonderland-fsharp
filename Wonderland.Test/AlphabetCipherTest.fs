module Wonderland.Test

open Xunit
open FsUnit.Xunit

[<Fact>]
let Test1 () =
    1 |> should equal 1
