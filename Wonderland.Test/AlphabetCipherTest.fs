namespace Wonderland

open Xunit
open FsUnit.Xunit

open AlphabetCipher

module AlphabetCipherTest =

    [<Theory>]
    [<InlineData("vigilance", "meetmeontuesdayeveningatseven", "hmkbxebpxpmyllyrxiiqtoltfgzzv")>]
    [<InlineData("scones", "meetmebythetree", "egsgqwtahuiljgs")>]
    let ``encoding a message uses the key to look up secret chars in the substitution chart`` (key: Keyword,
                                                                                               message: Message,
                                                                                               expectedEncoding: Message) =
        let encodedMessage = encode key message

        encodedMessage |> should equal expectedEncoding


    [<Theory>]
    [<InlineData("vigilance", "hmkbxebpxpmyllyrxiiqtoltfgzzv", "meetmeontuesdayeveningatseven")>]
    [<InlineData("scones", "egsgqwtahuiljgs", "meetmebythetree")>]
    let ``decoding a message uses the key to look up original chars in the substitution chart`` (key: Keyword,
                                                                                                 message: Message,
                                                                                                 expectedEncoding: Message) =
        let decodedMessage = decode key message

        decodedMessage |> should equal expectedEncoding


    [<Theory>]
    [<InlineData("opkyfipmfmwcvqoklyhxywgeecpvhelzg", "thequickbrownfoxjumpsoveralazydog", "vigilance")>]
    [<InlineData("hcqxqqtqljmlzhwiivgbsapaiwcenmyu", "packmyboxwithfivedozenliquorjugs", "scones")>]
    let ``decyphering is done by using the cipher and message`` (cipher: Keyword,
                                                                 message: Message,
                                                                 expectedMessage: Message) =
        let decipheredMessage = decipher cipher message

        decipheredMessage |> should equal expectedMessage
