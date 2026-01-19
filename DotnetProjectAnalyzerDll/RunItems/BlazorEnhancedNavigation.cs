using static System.Text.RegularExpressions.Regex;

namespace DotnetProjectAnalyzerDll.RunItems;

public class BlazorEnhancedNavigation : BaseClass, IRunItem
{
    public BlazorEnhancedNavigation(Code.SuccessWhen successWhen, string projectPath) : base(successWhen, projectPath)
    {
        ReCheck();
    }
    public string Title => "Blazor Enhanced Navigation";
    public string Path => $@"{ProjectPath.TrimEnd('\\')}\Components\App.razor";
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