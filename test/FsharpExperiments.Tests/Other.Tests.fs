namespace FsharpExperiments.Tests
open Xunit
open FsUnit.Xunit
open FsharpExperiments.Code.Others
open System.IO

module `` Parallel list functions test `` = 
    [<Fact>]
    let ``Parallel map test``() =
        [1;2;3;4] |> PList.pmap (fun x -> x * 2) |> should equal [2;4;6;8]
    [<Fact>]
    let ``filter test``() =
        [1;2;3;4] |> PList.filter(fun x -> x % 2 = 0) |> should equal [2;4]