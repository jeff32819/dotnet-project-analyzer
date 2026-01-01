namespace DotnetProjectAnalyzerDll.RunItems
{
    internal class WeatherPageDefaultPage : IRunItem
    {
        public WeatherPageDefaultPage(string projectPath)
        {
            Path = $@"{projectPath.TrimEnd('\\')}\Components\Pages\Weather.razor";
            ReCheck();
        }

        public string Title => "Weather Page Default (delete page)";
        public bool ChangeNeedsDone { get; private set; }
        public string Path { get; }

        public void ReCheck()
        {
            if (!File.Exists(Path))
            {
                ChangeNeedsDone = false;
                return;
            }
            var contents = File.ReadAllText(Path);
            // check for text, just in case i created page with same name;
            ChangeNeedsDone = contents.Contains("This component demonstrates showing data");
        }

        public void MakeChange()
        {
            File.Delete(Path);
            ReCheck();
        }
    }
}
