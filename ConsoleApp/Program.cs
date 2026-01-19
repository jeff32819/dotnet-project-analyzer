using ConsoleApp;
using DotnetProjectAnalyzerDll;

const string projectPath = @"V:\GitHub\Jeff32819\CruiseVacay\BlazorDotNet9";

Code.SuccessWhenConfig config = new()
{
    BlazorEnhancedNavigation = Code.SuccessWhen.NotFound,
    WeatherPageDefaultPage = Code.SuccessWhen.NotFound
};
while (Runner.Process(config, projectPath));

Console.WriteLine();
Console.WriteLine();