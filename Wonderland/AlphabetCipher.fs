namespace Wonderland

module AlphabetCipher =

    type Message = string
    type Keyword = string
    type Cipher = string
    type Alphabet = char []


    let private englishAlphabet: Alphabet = [| 'a' .. 'z' |]


    let private lookup (alphabet: Alphabet) (op: int -> int -> int) (keyChar: char) (messageChar: char) =
        let length = alphabet.Length
        let index (c: char) = (int c) - (int (Array.head alphabet))

        alphabet.[(length + index messageChar |> op <| index keyChar) % length]


    let private substituteChar (alphabet: Alphabet) = lookup alphabet (+)

    let private decodeChar (alphabet: Alphabet) = lookup alphabet (-)

    let private repeat (s: string) =
        Seq.initInfinite (fun i -> s.[i % s.Length])


    let private apply (f: char -> char -> char) (key: Keyword) (message: Message) =
        message
        |> Seq.map2 f (repeat key)
        |> System.String.Concat


    let encode (key: Keyword) (message: Message): Cipher =
        apply (substituteChar englishAlphabet) key message

    let decode (key: Keyword) (cipher: Cipher): Message =
        apply (decodeChar englishAlphabet) key cipher

    let decipher (cipher: Cipher) (message: Message): Keyword = "decypherme"
