module Tests

open Xunit
open task11
open task20

[<Fact>]
let ``task20RecursionSolution should find sum of 100!`` () =
    let result = task20RecursionSolution 100
    Assert.Equal(648, result)

[<Fact>]
let ``task20SequenceSolution should find sum of 100!`` () =
    let result = task20SequenceSolution 100
    Assert.Equal(648, result)

[<Fact>]
let ``task20ModuleSolution should find sum of 300!`` () =
    let result = task20ModuleSolution 200
    Assert.Equal(1404, result)

[<Fact>]
let ``task11Loop should find maximum prod of 4 numbers in the same direction`` () =
    let result = task11Loop grid
    Assert.Equal(70600674, result)

[<Fact>]
let ``task11Rec should find maximum prod of 4 numbers in the same direction`` () =
    let result = task11Rec grid
    Assert.Equal(70600674, result)

[<Fact>]
let ``task11BeautifullSolution should find maximum prod of 4 numbers in the same direction`` () =
    let result = task11BeautifullSolution grid
    Assert.Equal(51267216, result)
