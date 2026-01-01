namespace DotnetProjectAnalyzerDll.RunItems
{
    public interface IRunItem
    {
        bool IsFound { get; }
        string Title { get; }
        void MakeChange()
        {

        }
        void ReCheck()
        {

        }
    }
}
