namespace DotnetProjectAnalyzerDll.RunItems
{
    public interface IRunItem
    {
        string Title { get; }
        string ProjectPath { get; }
        bool IsFound { get; }
        bool SuccessLogic { get; }
        Code.SuccessWhen SuccessWhen { get; }
        void MakeChange()
        {

        }
        void ReCheck()
        {

        }
    }
}
