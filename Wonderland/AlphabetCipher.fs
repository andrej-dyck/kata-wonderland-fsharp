namespace Wonderland

module AlphabetCipher =

    type Message = string
    type Keyword = string


    let private alphabet = [| 'a' .. 'z' |]
    let private alphabetLength = Array.length alphabet

    let private indexOf (alphabet: char []) (c: char) =
        let intValueOfFirstChar = int (Array.head alphabet)

        (int c) - intValueOfFirstChar

    let private indexInAlphabet = indexOf alphabet

    let private substituteChar (keyChar: char) (messageChar: char) =
        let indexMessageChar = indexInAlphabet messageChar
        let indexKeyChar = indexInAlphabet keyChar

        alphabet.[(indexKeyChar + indexMessageChar) % alphabetLength]

    let private applyByIndex (f: char -> char -> char) (key: Keyword) (index: int) = f key.[index % key.Length]


    let encode (key: Keyword) (message: Message): Message =
        message
        |> Seq.mapi (fun i c -> applyByIndex substituteChar key i c)
        |> System.String.Concat

    let decode (key: Keyword) (message: Message): Message = "decodeme"

    let decipher (cipher: Message) (message: Message): Keyword = "decypherme"
