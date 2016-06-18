namespace FsharpExperiments.Tests
open Xunit
open FsUnit.Xunit
open FsharpExperiments.Code

module `` Sentiment Analyzer Tests `` = 

    [<Fact>]
    let ``Euler 1 test``() =
        Euler1.solve(1,1001) |>  should equal 234168
