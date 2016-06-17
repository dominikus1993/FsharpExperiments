namespace FsharpExperiments.Tests
open Xunit
open FsUnit.Xunit
module `` Sentiment Analyzer Tests `` = 

    [<Fact>]
    let ``truth``() =
        2 |> should equal 2
