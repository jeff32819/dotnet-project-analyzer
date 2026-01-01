using static System.Text.RegularExpressions.Regex;

namespace DotnetProjectAnalyzerDll.RunItems;

public class BlazorEnhancedNavigation : IRunItem
{
    public BlazorEnhancedNavigation(string projectPath)
    {
        Path = $@"{projectPath.TrimEnd('\\')}\Components\App.razor";
        var contents = File.ReadAllText(Path);
        IsFound = IsMatch(contents, Pattern);
    }


    public bool IsFound { get; }
    public string Path { get; }
    public string Pattern => @"<script\s+src=""@Assets\[""_framework/blazor\.web\.js""\]""></script>";

    public void MakeChange()
    {
        var contents = File.ReadAllText(Path);
        var cleaned = Replace(contents, Pattern, "");
        File.WriteAllText(Path, cleaned);
    }
}