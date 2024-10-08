open System
open task11
open task20


[<EntryPoint>]
let main (argv: string array) =

    printfn "Задача 11"
    printfn "Максимальное произведение 4х чисел в одном направлении (map) = %d" (task11Loop grid)
    printfn "Максимальное произведение 4х чисел в одном направлении (recursion) = %d" (task11Rec grid)
    printfn "Максимальное произведение 4х чисел в одном направлении (красиво) = %d" (task11BeautifullSolution grid)

    printfn "Задача 20"
    printfn "Сумма цифр 100! (module) = %d" (task20ModuleSolution 100)
    printfn "Сумма цифр 100! (recursion) = %d" (task20RecursionSolution 100)
    printfn "Сумма цифр 100! (sequence) = %d" (task20SequenceSolution 100)

    0
