namespace FsharpExperiments.Code

module Euler1 = 
    let solve (start, quantity) = 
        [start..quantity] |> List.filter(fun x -> x % 5 = 0 || x % 3 = 0) |> List.sum

module Euler8 =
    let private getProduct(numbers : int64 seq) = 
        numbers |> Seq.windowed(13) |> Seq.map(fun nums -> nums |> Seq.fold(fun acc x -> acc * x) 1L) |> Seq.max

    let solve(text: string) =
        text.ToCharArray() |> Array.toSeq |> Seq.map(fun x -> int64(x.ToString())) |> getProduct
