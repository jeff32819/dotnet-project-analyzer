namespace DotnetProjectAnalyzerDll.RunItems
{
    public interface IRunItem
    {
        bool IsFound { get; }
        void MakeChange()
        {

        }
    }
}
