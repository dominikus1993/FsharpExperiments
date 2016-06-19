namespace FsharpExperiments.Code.NinetyNine
    module Problem1 = 
        let solve(list) = list |> List.rev |> List.head
    
    module Problem2 = 
        let solve(list) = list |> List.rev |> List.tail |> List.head

    module Problem3 =
        let solve(list, elementIndex) = 
            list |> List.nth elementIndex