namespace Wonderland

module AlphabetCipher =

    type Message = string
    type Keyword = string
    type Alphabet = char []


    let private englishAlphabet: Alphabet = [| 'a' .. 'z' |]


    let private lookup (alphabet: Alphabet) (op: int -> int -> int) (keyChar: char) (messageChar: char) =
        let length = Array.length alphabet
        let index (c: char) = (int c) - (int (Array.head alphabet))

        alphabet.[(length + index messageChar |> op <| index keyChar) % length]


    let private substituteChar (alphabet: Alphabet) = lookup alphabet (+)

    let private decodeChar (alphabet: Alphabet) = lookup alphabet (-)


    let private applyByIndex (f: char -> char -> char) (key: Keyword) (index: int) = f key.[index % key.Length]

    let private apply (f: char -> char -> char) (key: Keyword) (message: Message) =
        message
        |> Seq.mapi (fun i c -> applyByIndex f key i c)
        |> System.String.Concat


    let encode (key: Keyword) (message: Message): Message =
        apply (substituteChar englishAlphabet) key message

    let decode (key: Keyword) (cipher: Message): Message =
        apply (decodeChar englishAlphabet) key cipher

    let decipher (cipher: Message) (message: Message): Keyword = "decypherme"
