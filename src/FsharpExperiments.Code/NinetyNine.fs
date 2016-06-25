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

    module Problem7 =
        type 'a NastedList = List of 'a NastedList list | Elem of 'a
        
        let solve<'a>(nastedList : 'a NastedList) =
            let rec matcher(list, acc) =
                match list with
                |Elem e -> acc @ [e]
                |List l -> 
                    l |> List.fold(fun acc x -> matcher(x, acc)) acc

            matcher(nastedList, [])

    module Problem8 =
        let rec private compress(list, acc) =
            match list with
            |[] -> acc |> List.rev
            |head :: tail when (acc |> List.length) = 0 -> 
                compress(tail, [head])
            |head :: tail when head <> (acc |> List.head)-> 
                compress(tail, head :: acc)
            |head :: tail -> 
                compress(tail, acc)

        let solve(list) = 
            compress(list, [])

    module Problem9 =
        let rec private pack(x, acc) =
            match acc with
            |(head_of_head :: head) :: tail when x = head_of_head ->
                 (x :: head_of_head :: head) :: tail
            |col -> [x] :: col

        let solve<'a when 'a : equality>(collection : 'a list) : 'a list list =
            collection |> List.fold(fun acc x -> pack(x, acc)) [] |> List.rev
