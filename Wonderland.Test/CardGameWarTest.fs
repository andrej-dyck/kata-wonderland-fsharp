namespace Wonderland

open Xunit
open FsUnit.Xunit

module CardGameWarTest =

    open CardGameWar

    let TODO = ()

    [<Fact>]
    let ``the highest rank wins the cards in the round`` () = shouldFail (fun () -> TODO)

    [<Fact>]
    let ``queens are higher rank than jacks`` () = shouldFail (fun () -> TODO)

    [<Fact>]
    let ``kings are higher rank than queens`` () = shouldFail (fun () -> TODO)

    [<Fact>]
    let ``aces are higher rank than kings`` () = shouldFail (fun () -> TODO)

    [<Fact>]
    let ``if the ranks are equal, clubs beat spades`` () = shouldFail (fun () -> TODO)

    [<Fact>]
    let ``if the ranks are equal, diamonds beat clubs`` () = shouldFail (fun () -> TODO)

    [<Fact>]
    let ``if the ranks are equal, hearts beat diamonds`` () = shouldFail (fun () -> TODO)

    [<Fact>]
    let ``the player loses when they run out of cards`` () = shouldFail (fun () -> TODO)
