using Azure;
using Azure.AI.Inference;

namespace GenAIStarter
{
    /// <summary>
    /// Basic Example - Simple Q&A interaction with AI
    /// Converted from sample-basic.js
    /// Run with: dotnet run --project BasicExample.csproj
    /// </summary>
    public class BasicExample
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("=== Basic Example - Simple Q&A ===\n");

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

                Console.WriteLine("Asking: What is the capital of France?\n");

                // Create the request
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

                // Get response
                var response = await client.CompleteAsync(requestOptions);
                Console.WriteLine("Assistant: " + response.Value.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
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