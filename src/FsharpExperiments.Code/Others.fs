namespace FsharpExperiments.Code.Others

module PList =
    let pmap func list =
        list |> List.map(fun x -> async { return func x }) |> Async.Parallel |> Async.RunSynchronously |> Array.toList