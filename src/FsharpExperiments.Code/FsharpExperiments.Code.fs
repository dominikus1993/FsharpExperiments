namespace FsharpExperiments.Code

module Euler1 = 
    let solve (start, quantity) = 
        [start..quantity] |> List.filter(fun x -> x % 5 = 0 || x % 3 = 0) |> List.sum

module Euler2 = 
    let private fibSeqGenerator() =  Seq.unfold(fun (x, y) -> Some(x, (y, x + y))) (0,1)

    let solve(quantity : int) =
        fibSeqGenerator() |>  Seq.takeWhile(fun x -> x < quantity) |> Seq.filter(fun x -> x % 2 = 0) |> Seq.sum

module Euler3 =
    let private findFactor(number : int64) = 
        [2L..int64(sqrt (double number))] |> Seq.filter(fun x -> number % x = 0L)

    let private isPrime = function
        |num when num < 2L -> false
        |num when num = 2L -> true
        |num -> [2L..int64(sqrt (double num))] |> Seq.filter(fun x -> num % x = 0L) |> Seq.length = 0
    
    let solve(number : int64) =
        [2L..(int64(sqrt (double number)))] |> Seq.filter(fun x -> number % x = 0L) |> Seq.filter(fun x -> isPrime(x)) |> Seq.max

module Euler4 =
    let private isPalindrom chars1 chars2 =
        chars1 = chars2
    let solve(_from:int, _to : int) =
        seq { for x in _from.._to do for y in _from.._to do yield x * y } |> Seq.filter(fun x -> isPalindrom <| x.ToString().ToCharArray() <| (x.ToString().ToCharArray() |> Array.rev )) |> Seq.max

module Euler5 =
    let rec gcd num1 num2 =
        if num1 <> num2 then
            if num1 > num2 then
                gcd (num1 - num2) (num2)
            else
                gcd (num1) (num2 - num1)
        else
            num1
      
    let lcm num1 num2 =
        (num1 * num2) / gcd num1 num2
    
    let solve(_from, _to) =
        [_from.._to] |> List.reduce(fun acc x -> lcm x acc)

module Euler6 =
    let private  sumSquare nums = nums |> List.sumBy(fun x -> x * x)
    let private squareSum nums = (float (nums |> List.sum)) ** 2.0

    let solve(_from, _to) =
        let nums = [_from.._to]
        (int (squareSum nums)) - sumSquare nums

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
