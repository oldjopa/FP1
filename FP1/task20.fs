module task20

// Решение через map fold и конвеер
let task20ModuleSolution n =
    let factorial (n: int) =
        let bigN = bigint n
        [ 1I .. bigN ] |> List.fold (*) 1I

    let sumOfDigits n =
        n.ToString() |> Seq.map (fun c -> int (string c)) |> Seq.sum

    factorial n |> sumOfDigits


// Решение черех рекурсию и хвостовую рекурсию
let task20RecursionSolution n =
    let rec factorial n =
        let rec loop acc i =
            if i = 0 then acc else loop (acc * bigint i) (i - 1)

        loop 1I n

    let rec sumOfDigits (n: bigint) : int =
        if n < 10I then
            int n
        else
            int (n % 10I) + sumOfDigits (n / bigint 10)

    factorial n |> sumOfDigits
