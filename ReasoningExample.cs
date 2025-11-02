using Azure;
using Azure.AI.Inference;
using System.Text;

namespace GenAIStarter
{
    /// <summary>
    /// Reasoning Example - Complex problem solving scenarios
    /// Converted from sample-reasoning.js
    /// Run with: dotnet run --project ReasoningExample.csproj
    /// </summary>
    public class ReasoningExample
    {
        private static readonly (string Name, string Prompt)[] Scenarios = new[]
        {
            ("Mathematical Reasoning", 
                "A train travels 60 miles per hour for 2 hours, then 80 miles per hour for 1.5 hours. What is the average speed for the entire trip?"),
            
            ("Logic Puzzle", 
                "Three people are wearing hats that are either red or blue. Each person can see the other two hats but not their own. They are told that at least one of them is wearing a red hat. If they are asked in turn if they know the color of their own hat, what logical reasoning can they use to figure it out?"),
            
            ("Complex Problem Solving", 
                "You are organizing a conference with three sessions and four speakers. Each speaker can only attend two sessions, and no session can have more than two speakers. How would you assign the speakers to sessions?"),
            
            ("Ethical Reasoning", 
                "You see a runaway trolley heading towards five people tied up on the tracks. You can pull a lever to divert the trolley onto another track, where it will hit one person. What should you do, and why?")
        };

        public static async Task Main(string[] args)
        {
            Console.WriteLine("=== Reasoning Examples ===");
            Console.WriteLine("Test AI's ability to solve complex problems\n");

            // Load environment variables from .env file
            LoadEnvFile();

            // Get API configuration from .env file
            var token = Environment.GetEnvironmentVariable("API_TOKEN");
            var endpointUrl = Environment.GetEnvironmentVariable("API_ENDPOINT");
            
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.Error.WriteLine("Error: API_TOKEN not found!");
                Console.WriteLine("Please create a .env file with your API configuration:");
                Console.WriteLine("1. Copy .env.example to .env");
                Console.WriteLine("2. Add your API token and endpoint to the .env file");
                return;
            }

            if (string.IsNullOrWhiteSpace(endpointUrl))
            {
                Console.Error.WriteLine("Error: API_ENDPOINT not found!");
                Console.WriteLine("Please add API_ENDPOINT to your .env file");
                return;
            }

            try
            {
                // Initialize the client
                var endpoint = new Uri(endpointUrl);
                var client = new ChatCompletionsClient(endpoint, new AzureKeyCredential(token));
                var model = "gpt-4o";

                while (true)
                {
                    // Show menu
                    Console.WriteLine("Choose a reasoning scenario:");
                    for (int i = 0; i < Scenarios.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Scenarios[i].Name}");
                    }
                    Console.WriteLine($"{Scenarios.Length + 1}. Exit");
                    Console.Write("\nEnter your choice: ");

                    var choice = Console.ReadLine();
                    
                    if (choice == $"{Scenarios.Length + 1}" || choice?.ToLower() == "exit")
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }

                    if (int.TryParse(choice, out int index) && index >= 1 && index <= Scenarios.Length)
                    {
                        var scenario = Scenarios[index - 1];
                        await RunScenario(client, model, scenario);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        private static async Task RunScenario(ChatCompletionsClient client, string model, (string Name, string Prompt) scenario)
        {
            Console.Clear();
            Console.WriteLine($"=== {scenario.Name} ===\n");
            Console.WriteLine($"Problem: {scenario.Prompt}\n");
            Console.WriteLine("AI is thinking...\n");

            var requestOptions = new ChatCompletionsOptions
            {
                Model = model,
                Messages =
                {
                    new ChatRequestUserMessage(scenario.Prompt)
                },
                Temperature = 0.7f,
                MaxTokens = 2000
            };

            var response = await client.CompleteAsync(requestOptions);
            Console.WriteLine("AI Response:");
            Console.WriteLine(CleanMarkdownFormatting(response.Value.Content));
            
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
        }

        // Utility method to clean markdown formatting for better console output
        private static string CleanMarkdownFormatting(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            var sb = new StringBuilder(text);
            
            // Remove bold markdown
            sb.Replace("**", "");
            sb.Replace("__", "");
            
            // Remove italic markdown  
            sb.Replace("*", "");
            sb.Replace("_", "");
            
            // Remove inline code
            sb.Replace("`", "");
            
            // Remove headers
            sb.Replace("### ", "");
            sb.Replace("## ", "");
            sb.Replace("# ", "");
            
            // Clean up bullet points
            sb.Replace("- ", "• ");
            
            return sb.ToString().Trim();
        }

        private static void LoadEnvFile()
        {
            try
            {
                if (File.Exists(".env"))
                {
                    foreach (var line in File.ReadAllLines(".env"))
                    {
                        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                            continue;

                        var parts = line.Split('=', 2);
                        if (parts.Length == 2)
                        {
                            Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not load .env file: {ex.Message}");
            }
        }
    }
}