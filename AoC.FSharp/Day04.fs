namespace AoC.FSharp

module Day04 =
    let solve (s: string) = 
        let words = s.Split(' ') |> List.ofArray
        let d = List.distinct words
        d.Length = words.Length

    let solve2 (s: string) =
        let sortChars (s: string) =
            let chars = Seq.map(fun c -> c) s
            Seq.sort chars |> Seq.toArray |> System.String

        let words = s.Split(' ') |> List.ofArray
        let sortedWords = List.map (fun w -> sortChars w) words
        let distinct = Seq.distinct sortedWords |> List.ofSeq
        distinct.Length = sortedWords.Length