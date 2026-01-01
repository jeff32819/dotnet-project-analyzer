using static System.Text.RegularExpressions.Regex;

namespace DotnetProjectAnalyzerDll.RunItems;

public class BlazorEnhancedNavigation : IRunItem
{
    public BlazorEnhancedNavigation(string projectPath)
    {
        Path = $@"{projectPath.TrimEnd('\\')}\Components\App.razor";
        ReCheck();
    }

    public string Title => "Blazor Enhanced Navigation";
    public bool IsFound { get; private set; }
    public string Path { get; }
    private static string Pattern => @"<script\s+src=""@Assets\[""_framework/blazor\.web\.js""\]""></script>";

    public void ReCheck()
    {
        var contents = File.ReadAllText(Path);
        IsFound = IsMatch(contents, Pattern);
    }

    public void MakeChange()
    {
        var contents = File.ReadAllText(Path);
        var cleaned = Replace(contents, Pattern, "");
        File.WriteAllText(Path, cleaned);
        ReCheck();
    }
}