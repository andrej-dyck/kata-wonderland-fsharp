## card-game-war

_Ported from [@gigasquid](https://twitter.com/gigasquid)'s
[*wonderland-clojure-katas*](https://github.com/gigasquid/wonderland-clojure-katas)_

This kata is a version of the classic card game [War](http://en.wikipedia.org/wiki/War_%28card_game%29).


The rules of this card game are quite simple.

- There are two players.
- The cards are all dealt equally to each player.
- Each round, player 1 lays a card down face up at the same time that
  player 2 lays a card down face up.  Whoever has the highest value
  card, wins both round and takes both cards.
- The winning cards are added to the bottom of the winners deck.
- Aces are high.
- If both cards are of equal value, then the winner is decided upon by
  the highest suit.  The suits ranks in order of ascending value are
  spades, clubs, diamonds, and hearts.
- The player that runs out of cards loses.
