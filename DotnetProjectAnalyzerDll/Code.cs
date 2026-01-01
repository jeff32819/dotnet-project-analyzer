using DotnetProjectAnalyzerDll.RunItems;

namespace DotnetProjectAnalyzerDll
{
    public class Code
    {
        public static List<IRunItem> RunItems(string projectPath)
        {
            return new List<IRunItem>
            {
                new BlazorEnhancedNavigation(projectPath)
            };
        }
        
    }
}
