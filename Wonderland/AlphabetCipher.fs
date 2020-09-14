namespace Wonderland

module AlphabetCipher =

    type Message = string
    type Keyword = string


    let private alphabet = [| 'a' .. 'z' |]
    let private alphabetLength = Array.length alphabet


    let private indexIn (alphabet: char []) (c: char) = (int c) - (int (Array.head alphabet))

    let private indexInAlphabet = indexIn alphabet


    let private lookupInAlphabet (buildIndexOffset) (keyChar: char) (messageChar: char) =
        alphabet.[buildIndexOffset (indexInAlphabet keyChar) (indexInAlphabet messageChar) % alphabetLength]

    let private substituteChar =
        lookupInAlphabet (fun indexKeyChar indexMessageChar -> indexKeyChar + indexMessageChar)

    let private decodeChar =
        lookupInAlphabet (fun indexKeyChar indexMessageChar -> indexMessageChar - indexKeyChar + alphabetLength)


    let private applyByIndex (f: char -> char -> char) (key: Keyword) (index: int) = f key.[index % key.Length]

    let private apply (f: char -> char -> char) (key: Keyword) (message: Message) =
        message
        |> Seq.mapi (fun i c -> applyByIndex f key i c)
        |> System.String.Concat


    let encode (key: Keyword) (message: Message): Message = apply substituteChar key message

    let decode (key: Keyword) (cipher: Message): Message = apply decodeChar key cipher

    let decipher (cipher: Message) (message: Message): Keyword = "decypherme"
