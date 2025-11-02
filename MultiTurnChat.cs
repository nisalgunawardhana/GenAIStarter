using Azure;
using Azure.AI.Inference;

namespace GenAIStarter
{
    /// <summary>
    /// Multi-turn Chat Example - Interactive conversation with memory
    /// Converted from sample-multiturn.js
    /// Run with: dotnet run --project MultiTurnChat.csproj
    /// </summary>
    public class MultiTurnChat
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("=== Multi-turn Chat Example ===");
            Console.WriteLine("Type 'exit' to quit\n");

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

                // Initialize conversation with system message
                var messages = new List<ChatRequestMessage>
                {
                    new ChatRequestSystemMessage("You are a helpful assistant.")
                };

                Console.WriteLine("Chat started! Ask me anything...\n");

                // Conversation loop
                while (true)
                {
                    Console.Write("You: ");
                    var input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input) || input.Trim().ToLower() == "exit")
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }

                    // Add user message to conversation history
                    messages.Add(new ChatRequestUserMessage(input));

                    // Create request with full conversation history
                    var requestOptions = new ChatCompletionsOptions { Model = model };
                    foreach (var msg in messages)
                        requestOptions.Messages.Add(msg);

                    // Get AI response
                    var response = await client.CompleteAsync(requestOptions);
                    var reply = response.Value.Content;
                    
                    Console.WriteLine($"Assistant: {reply}\n");
                    
                    // Add assistant response to conversation history
                    messages.Add(new ChatRequestAssistantMessage(reply));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
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