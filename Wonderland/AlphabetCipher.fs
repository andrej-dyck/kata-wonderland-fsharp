namespace Wonderland

module AlphabetCipher =

    type Message = string
    type Keyword = string


    let private alphabet = [| 'a' .. 'z' |]


    let private indexIn (alphabet: char []) (c: char) = (int c) - (int (Array.head alphabet))

    let private indexInAlphabet = indexIn alphabet


    let private lookupInAlphabet (op: int -> int -> int) (keyChar: char) (messageChar: char) =
        let alphabetSize = Array.length alphabet
        let indexKeyChar = indexInAlphabet keyChar
        let indexMessageChar = indexInAlphabet messageChar

        alphabet.[(alphabetSize + (op indexMessageChar indexKeyChar)) % alphabetSize]

    let private substituteChar = lookupInAlphabet (+)

    let private decodeChar = lookupInAlphabet (-)


    let private applyByIndex (f: char -> char -> char) (key: Keyword) (index: int) = f key.[index % key.Length]

    let private apply (f: char -> char -> char) (key: Keyword) (message: Message) =
        message
        |> Seq.mapi (fun i c -> applyByIndex f key i c)
        |> System.String.Concat


    let encode (key: Keyword) (message: Message): Message = apply substituteChar key message

    let decode (key: Keyword) (cipher: Message): Message = apply decodeChar key cipher

    let decipher (cipher: Message) (message: Message): Keyword = "decypherme"
