namespace FsharpExperiments.Tests
open Xunit
open FsUnit.Xunit
open FsharpExperiments.Code
open System.IO

module `` Euler solution tests `` = 

    [<Fact>]
    let ``Euler 1 test``() =
        Euler1.solve(1,1001) |>  should equal 234168

    [<Fact>]
    let ``Euler 2 test``() =
        Euler2.solve(4000000) |>  should equal 4613732
    
    [<Fact>]
    let ``Euler 3 test``() =
        Euler3.solve(13195L) |>  should equal 29L
        Euler3.solve(600851475143L) |>  should equal 6857L
    
    [<Fact>]
    let ``Euler 4 test``() =
        Euler4.solve(10, 99) |>  should equal 9009
        Euler4.solve(100, 999) |>  should equal 906609

    [<Fact>]
    let ``Euler 5 test``() =
        Euler5.solve(1, 10) |>  should equal 2520
        Euler5.solve(1, 20) |>  should equal 18044195

    [<Fact>]
    let ``Euler 6 test``() =
        Euler6.solve(1, 10) |>  should equal 2640
        Euler6.solve(1, 100) |>  should equal 25164150

    [<Fact>]
    let ``Euler7 test``() =
        Euler7.solve(10001) |> should equal 104743

    [<Fact>]
    let  ``Euler8 test``() =
        let numbers =  "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450"
        numbers |> Euler8.solve |> should equal 23514624000L
    
    [<Fact>]
    let ``Euler9 test``() = 
        Euler9.solve 1 1000 |> should equal 31875000

    [<Fact>]
    let ``Euler10 test``() = 
        Euler10.solve 10L |> should equal 17L
        //Euler10.solve 2000000L |> should equal 142913828922L
    
    [<Fact>]
    let ``Euler12 test``() = 
        Euler12.solve 5 |> should equal 28L
        //Euler12.solve 5 |> should equal 5537376230L

    [<Fact>]
    let ``Euler13 test``() =
        let num = File.ReadAllLines("euler13.txt")
        Euler13.solve num |> should equal "5373762303"

    [<Fact>]
    let ``Euler14 test``() =
        let (n, l) = Euler14.solve [1..999999]
        n |> should equal 910107

    [<Fact>]
    let ``Euler15 test``() =
        Euler15.solve 2I 2I |> should equal 6I
        Euler15.solve 20I 20I |> should equal 137846528820I

    [<Fact>]
    let ``Euler16 test``() =
        Euler16.solve 15 |> should equal 26
        Euler16.solve 1000 |> should equal 1366

    [<Fact>]
    let ``Euler20 test``() =
        Euler20.solve 10I |> should equal 27
        Euler20.solve 100I |> should equal 648

