namespace FsharpExperiments.Tests
open Xunit
open FsUnit.Xunit
open FsharpExperiments.Code.NinetyNine

module `` NinetyNine problems solution tests`` = 
    [<Fact>]
    let ``1 test``() =
        First.solve([1; 2; 3; 4]) |> should equal 4
        First.solve(['x';'y';'z']) |> should equal 'z'

    [<Fact>]
    let ``Problem2 test``() =
        Problem2.solve([1; 2; 3; 4]) |> should equal 3
        Problem2.solve(['x'..'z']) |> should equal 'y'