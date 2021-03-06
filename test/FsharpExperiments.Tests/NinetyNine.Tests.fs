namespace FsharpExperiments.Tests
open Xunit
open FsUnit.Xunit
open FsharpExperiments.Code.NinetyNine
open System
open Swensen.Unquote
open FsCheck
open Problem7

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
    
    [<Fact>]
    let `` Problem 4``() =
        Problem4.solve([1; 2; 3]) |> should equal 3
        Problem4.solve<char>(("fsharp".ToCharArray() |> Array.toList)) |> should equal 6
    
    [<Fact>]
    let `` Problem 5``() =
        //Unquote Test
        test <@ ( Problem5.solve([1; 2; 3]) ) = [3;2;1] @>
        test <@ ( Problem5.solve(["x"; "y"; "z"]) ) = ["z"; "y"; "x";] @>
        //FsCheck randomize test
        let testRes(xs:list<int>) = ( Problem5.solve(xs)) = (xs |> List.rev)
        Check.QuickThrowOnFailure testRes

    [<Fact>]
    let `` Problem 6``() =
        //Unquote Test
        test <@ ( Problem6.solve([1; 2; 3]) ) = false @>
        test <@ ( Problem6.solve([1;2;4;8;16;8;4;2;1]) ) = true@>
        //FsCheck randomize test
    
    [<Fact>]
    let `` Problem 7``() =
        //Unquote Test
        test <@ ( Problem7.solve<int>(List [Elem 1; List [Elem 2; List [Elem 3; Elem 4]; Elem 5]]) ) = [1;2;3;4;5] @>
        test <@ (Problem7.solve<int>(Elem 1)) = [1] @>
        test <@ (Problem7.solve<int>(List[])) = [] @>
        //FsCheck randomize test

    [<Fact>]
    let `` Problem 8``() =
        //Unquote Test
        test <@ ( Problem8.solve([1;1;1;2;3;3;4;4;4;4;4;5;5;5;5;5])) = [1;2;3;4;5] @>
        test <@ (Problem8.solve([1])) = [1] @>
        test <@ (Problem8.solve([])) = [] @>
        test <@ (Problem8.solve(["a";"a";"b";"b";"a";"a"])) = ["a";"b";"a"] @>
        //FsCheck randomize test

    [<Fact>]
    let `` Problem 9``() =
        //Unquote Test
        test <@ ( Problem9.solve<char>(['a'; 'a'; 'a'; 'a'; 'b'; 'c'; 'c'; 'a'; 'a'; 'd'; 'e'; 'e'; 'e'; 'e'])) = [['a'; 'a'; 'a'; 'a']; ['b']; ['c'; 'c']; ['a'; 'a']; ['d'];['e'; 'e'; 'e'; 'e']] @>
        test <@ ( Problem9.solve<int>([1;1;1;2;2;2])) = [[1;1;1];[2;2;2]] @>
        //FsCheck randomize test

    [<Fact>]
    let `` Problem 10``() =
        //Unquote Test
        test <@ Problem10.solve("aaaabccaadeeee") = [(4,'a');(1,'b');(2,'c');(2,'a');(1,'d');(4,'e')] @>
        //FsCheck randomize test