using DotnetProjectAnalyzerDll.RunItems;

namespace DotnetProjectAnalyzerDll;

public class Code
{
    public enum SuccessWhen
    {
        Found,
        NotFound
    }

    public static List<IRunItem> RunItems(SuccessWhenConfig config, string projectPath)
    {
        return
        [
            new BlazorEnhancedNavigation(config.BlazorEnhancedNavigation, projectPath),
            new WeatherPageDefaultPage(config.WeatherPageDefaultPage, projectPath)
        ];
    }

    public class SuccessWhenConfig
    {
        public SuccessWhen BlazorEnhancedNavigation { get; set; }
        public SuccessWhen WeatherPageDefaultPage { get; set; }
    }
}