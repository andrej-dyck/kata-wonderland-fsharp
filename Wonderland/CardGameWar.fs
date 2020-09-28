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


    type Winner =
        | Player1
        | Player2
        | Draw

    let private card1IsWinning card1 card2 = winningCard card1 card2 = card1

    let private addToBottom hand card1 card2 = hand @ [ card1; card2 ]

    let rec winnerOfGame (hand1: Card list) (hand2: Card list) =
        match hand1, hand2 with
        | [], [] -> failwith "there is no game to be played"
        | _, [] -> Player1
        | [], _ -> Player2
        | c1 :: h1, c2 :: h2 when card1IsWinning c1 c2 -> winnerOfGame (addToBottom h1 c2 c1) h2
        | c1 :: h1, c2 :: h2 (* otherwise card2 wins *) -> winnerOfGame h1 (addToBottom h2 c1 c2)

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
