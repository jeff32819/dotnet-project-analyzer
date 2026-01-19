namespace DotnetProjectAnalyzerDll.RunItems
{
    internal class WeatherPageDefaultPage : BaseClass, IRunItem
    {
        public WeatherPageDefaultPage(Code.SuccessWhen successWhen, string projectPath) :base(successWhen, projectPath)
        {
            ReCheck();
        }
        public string Title => "Weather Page Default (delete page)";
        public string Path=> $@"{ProjectPath.TrimEnd('\\')}\Components\Pages\Weather.razor";
        public void ReCheck()
        {
            if (!File.Exists(Path))
            {
                IsFound = false;
                return;
            }
            var contents = File.ReadAllText(Path);
            // check for text, just in case i created page with same name;
            IsFound = contents.Contains("This component demonstrates showing data");
        }

        public void MakeChange()
        {
            File.Delete(Path);
            ReCheck();
        }
    }
}
