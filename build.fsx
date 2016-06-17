// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake

// Directories
let buildDir  = "./build/"
let deployDir = "./deploy/"


// Filesets
let appReferences  =
    !! "/**/*.csproj"
      ++ "/**/*.fsproj"

// version info
let version = "0.1"  // or retrieve from CI server

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; deployDir]
)

Target "Default" (fun _ ->
    trace "End of building"
)

Target "Build" (fun _ ->
    // compile all projects below src/app/
    MSBuildDebug buildDir "Build" appReferences
        |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    !!(buildDir + "/*.Tests.dll") |> Fake.Testing.XUnit2.xUnit2(fun x -> {x with HtmlOutputPath = Some (buildDir @@ "xunit_test_raport.html"); ToolPath="./packages/xunit.runner.console/tools/xunit.console.exe"; Parallel = Fake.Testing.XUnit2.ParallelMode.All})
)

Target "Deploy" (fun _ ->
    !! (buildDir + "/**/*.*")
        -- "*.zip"
        |> Zip buildDir (deployDir + "ApplicationName." + version + ".zip")
)

// Build order
"Clean"
  ==> "Build"
  ==> "Test"
  ==> "Deploy"
  ==> "Default"

// start build
RunTargetOrDefault "Default"