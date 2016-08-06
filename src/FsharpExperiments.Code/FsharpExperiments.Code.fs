namespace FsharpExperiments.Code

module EulerUtils = 
    let isPrime = function
        |num when num < 2L -> false
        |num when num = 2L -> true
        |num -> [2L..int64(sqrt (double num))] |> Seq.filter(fun x -> num % x = 0L) |> Seq.length = 0

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
    
    let solve(number : int64) =
        [2L..(int64(sqrt (double number)))] |> Seq.filter(fun x -> number % x = 0L) |> Seq.filter(fun x -> EulerUtils.isPrime(x)) |> Seq.max

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

    let private generator = Seq.unfold(fun x -> Some(x, x + 1)) 0

    let solve(num : int32) =
        generator |> Seq.filter(fun x -> EulerUtils.isPrime(int64 x)) |> Seq.nth(num - 1)

module Euler8 =
    let private getProduct(numbers : int64 seq) = 
        numbers |> Seq.windowed(13) |> Seq.map(fun nums -> nums |> Seq.fold(fun acc x -> acc * x) 1L) |> Seq.max

    let solve(text: string) =
        text.ToCharArray() |> Array.toSeq |> Seq.map(fun x -> int64(x.ToString())) |> getProduct

module Euler9 = 
    let generator _from _to = 
        seq {
            for a in [_from.._to] do 
                for b in [_from.._to] do 
                    for c in [_from.._to] do
                        if (a + b + c) = _to then yield [a;b;c]
        }
    
    let private isPythagoreanTriplet data =
        match data |> List.sort with
        |[a;b;c] when a*a + b*b = c*c -> true
        |_ -> false

    let solve _from _to =
        generator <| _from <| _to |> Seq.filter isPythagoreanTriplet |> Seq.head |> Seq.fold((*)) 1

module Euler10 = 
    let primeSeq quantity = [3L..2L..quantity] |> Seq.filter(EulerUtils.isPrime)
        
    let solve quantity = (primeSeq quantity |> Seq.sum) + 2L

module Euler12 = 
    let private triangulerNumberGenerator() = Seq.unfold(fun (x, y) -> Some(x, ([1L..y] |> Seq.sum, y + 1L))) (1L, 2L)

    let private countFactors num = 
        ([1L..(num / 2L + 1L)] |> Seq.filter(fun x -> num % x = 0L) |> Seq.length) + 1

    let solve divisorQuantity =
        triangulerNumberGenerator() |> Seq.filter(fun x -> countFactors x > divisorQuantity) |> Seq.head
