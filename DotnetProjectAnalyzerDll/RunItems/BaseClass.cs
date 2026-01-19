namespace DotnetProjectAnalyzerDll.RunItems;

public class BaseClass
{
    public BaseClass(Code.SuccessWhen successWhen, string projectPath)
    {
        SuccessWhen = successWhen;
        ProjectPath = projectPath;
    }
    public string ProjectPath { get; set; }
    public Code.SuccessWhen SuccessWhen { get; }
    public bool IsFound { get; set; }
    public bool SuccessLogic => (IsFound && SuccessWhen == Code.SuccessWhen.Found) || (!IsFound && SuccessWhen == Code.SuccessWhen.NotFound);
}