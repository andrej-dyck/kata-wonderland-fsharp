namespace Wonderland

open Xunit
open FsUnit.Xunit

module CardGameWarTest =

    open CardGameWar

    (* winning card *)

    type cardsWinningByRank() as this =
        inherit TheoryData<Card, Card, Card>() do
            this.Add((Club, Value 2), (Club, Value 3), (Club, Value 3))
            this.Add((Club, Value 3), (Club, Value 2), (Club, Value 3))
            this.Add((Club, Value 2), (Club, Value 10), (Club, Value 10))
            this.Add((Club, Value 10), (Club, Value 2), (Club, Value 10))
            this.Add((Club, Value 9), (Club, Value 10), (Club, Value 10))
            this.Add((Club, Value 10), (Club, Value 9), (Club, Value 10))

    [<Theory; ClassData(typeof<cardsWinningByRank>)>]
    let ``the highest rank wins the cards in the round`` (card1: Card, card2: Card, expectedWinningCard: Card) =
        winningCard card1 card2
        |> should equal expectedWinningCard

    type allSuits() as this =
        inherit TheoryData<Suit>() do
            this.Add(Spade)
            this.Add(Club)
            this.Add(Diamond)
            this.Add(Heart)

    [<Theory; ClassData(typeof<allSuits>)>]
    let ``queens are higher rank than jacks`` (suit: Suit) =
        winningCard (suit, Queen) (suit, Jack)
        |> should equal (suit, Queen)

    [<Theory; ClassData(typeof<allSuits>)>]
    let ``kings are higher rank than queens`` (suit: Suit) =
        winningCard (suit, King) (suit, Queen)
        |> should equal (suit, King)

    [<Theory; ClassData(typeof<allSuits>)>]
    let ``aces are higher rank than kings`` (suit: Suit) =
        winningCard (suit, Ace) (suit, King)
        |> should equal (suit, Ace)

    type someRank() as this =
        inherit TheoryData<Rank>() do
            this.Add(Value 2)
            this.Add(Value 10)
            this.Add(Jack)
            this.Add(Queen)
            this.Add(King)
            this.Add(Ace)

    [<Theory; ClassData(typeof<someRank>)>]
    let ``if the ranks are equal, clubs beat spades`` (rank: Rank) =
        winningCard (Club, rank) (Spade, rank)
        |> should equal (Club, rank)

    [<Theory; ClassData(typeof<someRank>)>]
    let ``if the ranks are equal, diamonds beat clubs`` (rank: Rank) =
        winningCard (Diamond, rank) (Club, rank)
        |> should equal (Diamond, rank)

    [<Theory; ClassData(typeof<someRank>)>]
    let ``if the ranks are equal, hearts beat diamonds`` (rank: Rank) =
        winningCard (Heart, rank) (Diamond, rank)
        |> should equal (Heart, rank)

    [<Fact>]
    let ``there can be no to equal cards`` () =
        shouldFail (fun () -> winningCard (Club, Value 2) (Club, Value 2) |> ignore)

    (* winner of card game *)

    [<Fact>]
    let ``player 1 wins when player 2 runs out of cards`` () =
        winnerOfGame [ (Club, Value 2) ] []
        |> should equal Player1

    [<Fact>]
    let ``player 2 wins when player 1 runs out of cards`` () =
        winnerOfGame [] [ (Club, Value 2) ]
        |> should equal Player2

    [<Fact>]
    let ``player 1 wins their top cards always win against player 2 top cards`` () =
        winnerOfGame [ (Club, Value 3) ] [ (Club, Value 2) ]
        |> should equal Player1

    [<Fact>]
    let ``player 2 wins their top cards always win against player 1 top cards`` () =
        winnerOfGame [ (Club, Value 2) ] [ (Club, Value 3) ]
        |> should equal Player2

    [<Fact>]
    let ``player 1 wins when at some point they have better cards then player 2`` () =
        winnerOfGame [ (Club, Value 2); (Heart, Ace) ] [ (Club, Value 3); (Club, Value 4) ]
        |> should equal Player1

    [<Fact>]
    let ``player 2 wins when at some point they have better cards then player 1`` () =
        winnerOfGame [ (Club, Value 3); (Club, Value 4) ] [ (Club, Value 2); (Heart, Ace) ]
        |> should equal Player2

    [<Fact>]
    let ``there is no game to be played when both players are handed no cards`` () =
        shouldFail (fun () -> winnerOfGame [] [] |> ignore)
