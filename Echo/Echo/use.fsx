open System.IO

let readAFile ()=
    use reader = new StreamReader(
                    __SOURCE_DIRECTORY__ + "\\text.txt")
    reader.ReadToEnd()

readAFile()
