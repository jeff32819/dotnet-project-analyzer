using static System.Text.RegularExpressions.Regex;

namespace DotnetProjectAnalyzerDll;

public class BlazorWebJsTag
{
    /// <summary>
    /// Blazor SSR uses enhanced navigation - removing this tag will turn if off.
    /// </summary>
    /// <param name="projectPath"></param>
    /// <returns></returns>
    public static ReturnValue Analyze(string projectPath)
    {
        var path = $@"{projectPath.TrimEnd('\\')}\Components\App.razor";
        var content = File.ReadAllText(path);
        const string pattern = @"<script\s+src=""@Assets\[""_framework/blazor\.web\.js""\]""></script>";
        var found = IsMatch(content, pattern);
        var cleaned = Replace(content, pattern, "");

        return new ReturnValue
        {
            Found = found,
            TextAfterRemoval = cleaned
        };
    }


    public class ReturnValue
    {
        public bool Found { get; set; }
        public string TextAfterRemoval { get; set; } =string.Empty;
    }
}