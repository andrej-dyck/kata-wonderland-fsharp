namespace Wonderland

module Seq =

    let rec cycle (xs: seq<'a>): seq<'a> =
        seq {
            yield! xs
            yield! cycle xs
        }
