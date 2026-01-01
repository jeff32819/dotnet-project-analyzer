namespace DotnetProjectAnalyzerDll.RunItems
{
    public interface IRunItem
    {
        bool ChangeNeedsDone { get; }
        string Title { get; }
        void MakeChange()
        {

        }
        void ReCheck()
        {

        }
    }
}
