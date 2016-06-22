namespace FsharpExperiments.Code.NinetyNine
    module Problem1 = 
        let solve(list) = list |> List.rev |> List.head
    
    module Problem2 = 
        let solve(list) = list |> List.rev |> List.tail |> List.head

    module Problem3 =
        let solve<'a>(list : 'a list, elementIndex : int) = 
            List.nth list (elementIndex - 1)

    module Problem4 =
        let solve<'a>(list : 'a list) = 
            let rec length (collection, acc) =
                match collection with
                | [] -> acc
                | head :: tail -> length(tail, acc + 1)
            length(list, 0)

    module Problem5 =
        let solve<'a>(list : 'a list) =
            list |> List.rev

    module Problem6 =
        let solve<'a when 'a : equality>(list : 'a list) =
           list = (list |> List.rev)