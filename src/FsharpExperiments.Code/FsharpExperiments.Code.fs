namespace FsharpExperiments.Code

module Euler1 = 
    let solve (start, quantity) = 
        [start..quantity] |> List.filter(fun x -> x % 5 = 0 || x % 3 = 0) |> List.sum

module Euler7 =
    let private isPrime(num : int) =
        match num with
        |num when num < 2 -> false
        |num when num = 2 -> true
        |num -> [2..int(sqrt (double num))] |> Seq.filter(fun x -> num % x = 0) |> Seq.length = 0

    let private generator = Seq.unfold(fun x -> Some(x, x + 1)) 0

    let solve(num : int32) =
        generator |> Seq.filter(isPrime) |> Seq.nth(num - 1)

module Euler8 =
    let private getProduct(numbers : int64 seq) = 
        numbers |> Seq.windowed(13) |> Seq.map(fun nums -> nums |> Seq.fold(fun acc x -> acc * x) 1L) |> Seq.max

    let solve(text: string) =
        text.ToCharArray() |> Array.toSeq |> Seq.map(fun x -> int64(x.ToString())) |> getProduct
