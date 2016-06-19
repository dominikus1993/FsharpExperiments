namespace FsharpExperiments.Tests
open Xunit
open FsUnit.Xunit
open FsharpExperiments.Code.NinetyNine
open System
module `` NinetyNine problems solution tests`` = 
    [<Fact>]
    let `` Problem 1``() =
        Problem1.solve([1; 2; 3; 4]) |> should equal 4
        Problem1.solve(['x';'y';'z']) |> should equal 'z'

    [<Fact>]
    let ``Problem 2``() =
        Problem2.solve([1; 2; 3; 4]) |> should equal 3
        Problem2.solve(['x'..'z']) |> should equal 'y'

    [<Fact>]
    let `` Problem3``() =
        Problem3.solve([1; 2; 3], 2) |> should equal 2
        Problem3.solve<char>(("fsharp".ToCharArray() |> Array.toList), 5) |> should equal 'r'