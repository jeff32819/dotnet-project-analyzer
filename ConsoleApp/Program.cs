

var arr = DotnetProjectAnalyzerDll.Code.RunItems("t:\\");
foreach (var runItem in arr)
{
    Console.WriteLine(runItem.IsFound);
    runItem.MakeChange();
}

Console.WriteLine();
Console.WriteLine();