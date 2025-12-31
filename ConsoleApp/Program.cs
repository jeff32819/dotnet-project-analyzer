var rv =  DotnetProjectAnalyzerDll.BlazorWebJsTag.Analyze("t:\\");
Console.WriteLine(rv.Found);
Console.WriteLine(rv.TextAfterRemoval);
Console.WriteLine();