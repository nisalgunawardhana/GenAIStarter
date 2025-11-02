using Azure;
using Azure.AI.Inference;
using System.Text;

internal class Program
{
    private static ChatCompletionsClient? client;
    private static string model = "gpt-4o";

    private static async Task Main(string[] args)
    {
        // Initialize the client
        var token = Environment.GetEnvironmentVariable("API_TOKEN");
        var endpointUrl = Environment.GetEnvironmentVariable("API_ENDPOINT");
        
        if (string.IsNullOrWhiteSpace(token))
        {
            Console.Error.WriteLine("Set the API_TOKEN environment variable with a valid API token.");
            return;
        }

        if (string.IsNullOrWhiteSpace(endpointUrl))
        {
            Console.Error.WriteLine("Set the API_ENDPOINT environment variable with a valid API endpoint.");
            return;
        }

        var endpoint = new Uri(endpointUrl);
        client = new ChatCompletionsClient(endpoint, new AzureKeyCredential(token));

        // Show menu and run examples
        await ShowMenuAndRun();
    }

    private static async Task ShowMenuAndRun()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GenAI Starter - .NET Examples ===");
            Console.WriteLine("Choose an example to run:");
            Console.WriteLine("1. Basic Example - Simple Q&A");
            Console.WriteLine("2. Multi-turn Chat - Interactive conversation");
            Console.WriteLine("3. Coding Assistant - Multi-turn coding help");
            Console.WriteLine("4. Reasoning Example - Complex problem solving");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter your choice (1-5): ");

            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        await RunBasicExample();
                        break;
                    case "2":
                        await RunMultiTurnChat();
                        break;
                    case "3":
                        await RunCodingAssistant();
                        break;
                    case "4":
                        await RunReasoningExample();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            if (choice != "5")
            {
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
    }

    // Example 1: Basic single Q&A (converted from sample-basic.js)
    private static async Task RunBasicExample()
    {
        Console.Clear();
        Console.WriteLine("=== Basic Example ===");
        Console.WriteLine("Asking: What is the capital of France?\n");

        var requestOptions = new ChatCompletionsOptions
        {
            Model = model,
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage("What is the capital of France?")
            },
            Temperature = 1.0f,
            MaxTokens = 1000
        };

        var response = await client!.CompleteAsync(requestOptions);
        Console.WriteLine("Assistant: " + response.Value.Content);
    }

    // Example 2: Multi-turn conversation (converted from sample-multiturn.js)
    private static async Task RunMultiTurnChat()
    {
        Console.Clear();
        Console.WriteLine("=== Multi-turn Chat ===");
        Console.WriteLine("Type 'exit' to return to menu\n");

        var messages = new List<ChatRequestMessage>
        {
            new ChatRequestSystemMessage("You are a helpful assistant.")
        };

        while (true)
        {
            Console.Write("You: ");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Trim().ToLower() == "exit")
                break;

            messages.Add(new ChatRequestUserMessage(input));

            var requestOptions = new ChatCompletionsOptions { Model = model };
            foreach (var msg in messages)
                requestOptions.Messages.Add(msg);

            var response = await client!.CompleteAsync(requestOptions);
            var reply = response.Value.Content;
            
            Console.WriteLine($"Assistant: {reply}\n");
            messages.Add(new ChatRequestAssistantMessage(reply));
        }
    }

    // Example 3: Coding Assistant (converted from assessment.js)
    private static async Task RunCodingAssistant()
    {
        Console.Clear();
        Console.WriteLine("=== Coding Assistant ===");
        Console.WriteLine("Ask me anything about programming! Type 'exit' to return to menu\n");

        var messages = new List<ChatRequestMessage>
        {
            new ChatRequestSystemMessage("You are an expert coding assistant. Help users with programming questions, provide code examples, debug issues, and explain programming concepts clearly. Support multiple programming languages and provide best practices.")
        };

        while (true)
        {
            Console.Write("You: ");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Trim().ToLower() == "exit")
                break;

            messages.Add(new ChatRequestUserMessage(input));

            var requestOptions = new ChatCompletionsOptions { Model = model };
            foreach (var msg in messages)
                requestOptions.Messages.Add(msg);

            var response = await client!.CompleteAsync(requestOptions);
            var reply = response.Value.Content;
            
            Console.WriteLine($"\nCoding Assistant: {reply}\n");
            Console.WriteLine(new string('-', 50));
            messages.Add(new ChatRequestAssistantMessage(reply));
        }
    }

    // Example 4: Complex Reasoning (converted from sample-reasoning.js)
    private static async Task RunReasoningExample()
    {
        Console.Clear();
        Console.WriteLine("=== Reasoning Examples ===");

        var scenarios = new[]
        {
            new { Name = "Mathematical Reasoning", Prompt = "A train travels 60 miles per hour for 2 hours, then 80 miles per hour for 1.5 hours. What is the average speed for the entire trip?" },
            new { Name = "Logic Puzzle", Prompt = "Three people are wearing hats that are either red or blue. Each person can see the other two hats but not their own. They are told that at least one of them is wearing a red hat. If they are asked in turn if they know the color of their own hat, what logical reasoning can they use to figure it out?" },
            new { Name = "Complex Problem Solving", Prompt = "You are organizing a conference with three sessions and four speakers. Each speaker can only attend two sessions, and no session can have more than two speakers. How would you assign the speakers to sessions?" },
            new { Name = "Ethical Reasoning", Prompt = "You see a runaway trolley heading towards five people tied up on the tracks. You can pull a lever to divert the trolley onto another track, where it will hit one person. What should you do, and why?" }
        };

        Console.WriteLine("Choose a reasoning scenario:");
        for (int i = 0; i < scenarios.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {scenarios[i].Name}");
        }
        Console.Write("\nEnter your choice (1-4): ");

        var choice = Console.ReadLine();
        if (int.TryParse(choice, out int index) && index >= 1 && index <= scenarios.Length)
        {
            var scenario = scenarios[index - 1];
            Console.WriteLine($"\n=== {scenario.Name} ===");
            Console.WriteLine($"Problem: {scenario.Prompt}\n");
            Console.WriteLine("Thinking...\n");

            var requestOptions = new ChatCompletionsOptions
            {
                Model = model,
                Messages =
                {
                    new ChatRequestUserMessage(scenario.Prompt)
                }
            };

            var response = await client!.CompleteAsync(requestOptions);
            Console.WriteLine("AI Response:");
            Console.WriteLine(CleanMarkdownFormatting(response.Value.Content));
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    // Utility method to clean markdown formatting
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
        
        return sb.ToString().Trim();
    }
}