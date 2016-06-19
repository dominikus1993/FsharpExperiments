namespace FsharpExperiments.Code.NinetyNine
    module Problem1 = 
        let solve(list) = list |> List.rev |> List.head
    
    module Problem2 = 
        let solve(list) = list |> List.rev |> List.tail |> List.head

    module Problem3 =
        let solve<'a>(list : 'a list, elementIndex : int) = 
            List.nth list (elementIndex - 1)