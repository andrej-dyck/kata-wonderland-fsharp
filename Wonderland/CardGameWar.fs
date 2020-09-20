namespace Wonderland

module CardGameWar =

    type Suit =
        | Spade
        | Club
        | Diamond
        | Heart

    type Rank =
        | Value of int
        | Jack
        | Queen
        | King
        | Ace

    type Card = Suit * Rank

    let winningCard (card1: Card) (card2: Card): Card =
        if card1 = card2 then failwith "someone is ceating"
        elif card1 > card2 then card1
        else card2


    let playGame (hand1: Card list, hand2: Card list) = failwith "not implemented: game winner"

(*
    let suits = [ Spade; Club; Diamond; Heart ]
    let heads = [ Jack; Queen; King; Ace ]
    let ranks =
        [   for v in 2 .. 10 -> Value v
            for head in heads -> head
        ]
    let deck = seq {
        for suit in suits do
            for rank in ranks -> suit,rank }
*)
