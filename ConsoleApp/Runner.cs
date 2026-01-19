using static DotnetProjectAnalyzerDll.Code;

namespace ConsoleApp;

internal static class Runner
{
    public static bool Process(SuccessWhenConfig config, string projectPath)
    {
        var choiceIndex = 0;
        var arr = RunItems(config, projectPath);
        Console.WriteLine();
        Console.WriteLine("*** LIST OF ITEMS ****************************");
        foreach (var runItem in arr)
        {
            choiceIndex++;
            runItem.ReCheck();

            Console.Write($"{choiceIndex}) {runItem.Title}: ");
            Console.ForegroundColor = runItem.SuccessLogic ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(runItem.SuccessWhen);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" - {(runItem.SuccessWhen == SuccessWhen.Found ? "Success If Found" : "Success If Not Found")}");
            Console.ResetColor();

            Console.WriteLine(); // complete line
        }

        Console.WriteLine();
        Console.WriteLine("Choose Option Above:");
        var input = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine();
        if (int.TryParse(input, out var choice))
        {
            Console.WriteLine($"You entered the number: {choice}");

            if (choice > 0 && choice <= arr.Count)
            {
                var selectedItem = arr[choice - 1];

                if (!selectedItem.SuccessLogic)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Item does not need done, choose another");
                    Console.ResetColor();
                    return true;
                }

                Console.WriteLine($"Selected: {selectedItem.Title}");
                Console.WriteLine("Do you want to continue? (y/n)");
                Console.WriteLine();

                var confirmY = Console.ReadKey(true);

                if (confirmY.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("You pressed Y, Processing..");
                    selectedItem.MakeChange();
                }
                else
                {
                    Console.WriteLine("Action canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }
        else
        {
            // Handle the error
            Console.WriteLine("That wasn't a valid number.");
        }

        return true;
    }
}