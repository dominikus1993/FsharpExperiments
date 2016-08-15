namespace FsharpExperiments.Code.Others

module PList =
    let rec map func = function
        | [] -> []
        | head :: tail -> 
            func(head) :: (map func tail)

    let pmap func list =
        list |> List.map(fun x -> async { return func x }) |> Async.Parallel |> Async.RunSynchronously |> Array.toList
    
    let filter func list =
        let rec tailFilter l acc = 
            match l with
            |[] -> acc |> List.rev
            |head :: tail -> 
                if func(head) then tailFilter tail (head :: acc) else tailFilter tail acc
        tailFilter list []