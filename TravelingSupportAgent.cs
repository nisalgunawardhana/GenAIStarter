// /*
//  * Assessment Task: Multi-turn Traveling Support Agent Chatbot
//  * 
//  * Showcase your achievement on LinkedIn, GitHub, or your portfolio to impress future employers and peers!
//  * 
//  * You are required to build a multi-turn chatbot that provides traveling support assistance using the GPT-4o model 
//  * via GitHub's AI inference API. Your chatbot should maintain conversation context, offer meaningful travel help, 
//  * and support various travel scenarios and destinations.
//  * 
//  * What to Do:
//  * 
//  * 1. Environment Setup
//  *    - Load environment variables from .env file
//  *    - Use your GitHub token from API_TOKEN environment variable
//  *    - Ensure your .env is listed in .gitignore
//  * 
//  * 2. API Initialization  
//  *    - Use the Azure.AI.Inference package (already included)
//  *    - Configure the API client to use your GitHub token and the GitHub models endpoint
//  * 
//  * 3. Conversation Logic
//  *    - Implement a loop that lets the user and bot exchange messages
//  *    - Store the conversation history so the chatbot remembers previous messages
//  *    - Allow the user to exit the chat gracefully (e.g., by typing 'exit')
//  * 
//  * 4. Traveling Support Features
//  *    - Help users plan trips and itineraries
//  *    - Provide destination recommendations and travel tips
//  *    - Assist with booking guidance (flights, hotels, activities)
//  *    - Offer cultural information and local customs advice
//  *    - Help with travel documentation and visa requirements
//  *    - Provide weather information and packing suggestions
//  *    - Handle travel emergencies and problem-solving
//  *    - Support multiple destinations and travel styles (budget, luxury, adventure, etc.)
//  * 
//  * 5. Error Handling
//  *    - Handle API errors and invalid inputs gracefully
//  *    - Provide helpful error messages to users
//  * 
//  * Example Interactions:
//  * 
//  * User: "I want to plan a 7-day trip to Japan in spring"
//  * Agent: "That sounds wonderful! Spring is cherry blossom season in Japan. I can help you plan an amazing 7-day itinerary. 
//  *         What's your budget range and what type of experiences interest you most - cultural sites, food, nature, or modern attractions?"
//  * 
//  * User: "I'm having trouble with my flight booking, it got cancelled"
//  * Agent: "I'm sorry to hear about your cancelled flight. Let me help you with the next steps. First, contact your airline 
//  *         for rebooking options. Are you traveling soon? I can also suggest alternative flights and help you understand your rights."
//  * 
//  * Where to Implement:
//  * - Complete the implementation in this file (TravelingSupportAgent.cs)
//  * - Follow the existing patterns from other examples in this project
//  * - Use the same project structure and dependencies
//  * 
//  * Running Your Solution:
//  * dotnet run --project TravelingSupportAgent.csproj
//  * 
//  * Complete the assessment as described below to earn your certificate and badge!
//  * 
//  * Once you have finished implementing your multi-turn traveling support agent chatbot and submitted your pull request, 
//  * you will be eligible to receive an official certificate and badge.
//  * 
//  * How to claim your certificate and badge:
//  * 1. Complete all steps in the "Assessment Task" section above
//  * 2. Test your implementation thoroughly
//  * 3. Submit your solution following the submission guidelines
//  * 4. After your submission is reviewed and approved, you will receive your personalized certificate and badge via email
//  * 
//  * Submission Guidelines:
//  * 1. Ensure your code follows the existing project patterns
//  * 2. Test your implementation with various travel scenarios
//  * 3. Make sure error handling works properly
//  * 4. Document any additional features you've implemented
//  * 5. Create a pull request with your completed solution
//  * 
//  * Tips for Success:
//  * - Study the existing examples (MultiTurnChat.cs, CodingAssistant.cs) for patterns
//  * - Focus on creating a helpful and knowledgeable travel assistant
//  * - Consider edge cases and error scenarios
//  * - Make the conversation feel natural and engaging
//  * - Test with various travel-related queries
//  * 
//  * Good luck with your implementation!
//  */

// using Azure;
// using Azure.AI.Inference;

// namespace GenAIStarter
// {
//     /// <summary>
//     /// Traveling Support Agent - Multi-turn travel assistance chatbot
//     /// Assessment Task: Implement a comprehensive travel support agent
//     /// Run with: dotnet run --project TravelingSupportAgent.csproj
//     /// </summary>
//     public class TravelingSupportAgent
//     {
//         public static void Main(string[] args)
//         {
//             // TODO: Implement the traveling support agent here
//             // Follow the assessment requirements above
            
//             Console.WriteLine("=== Traveling Support Agent Assessment ===");
//             Console.WriteLine("Welcome to your Travel Assistant implementation task!");
//             Console.WriteLine("\nPlease implement the traveling support agent according to the assessment requirements.");
//             Console.WriteLine("Check the comments above for detailed instructions.");
//             Console.WriteLine("\nFeatures to implement:");
//             Console.WriteLine("- Multi-turn conversation with memory");
//             Console.WriteLine("- Travel planning and itinerary assistance");
//             Console.WriteLine("- Destination recommendations");
//             Console.WriteLine("- Booking guidance and support");
//             Console.WriteLine("- Cultural information and tips");
//             Console.WriteLine("- Travel documentation help");
//             Console.WriteLine("- Emergency assistance");
//             Console.WriteLine("- Weather and packing advice");
//             Console.WriteLine("\nType 'exit' to quit when implemented.");
            
//             // IMPLEMENTATION AREA - Add your code below this line
//             // =====================================================
            
//             // Step 1: Load environment variables from .env file
//             // Hint: Look at other examples for the LoadEnvFile() method
            
//             // Step 2: Get API configuration
//             // var token = Environment.GetEnvironmentVariable("API_TOKEN");
//             // var endpointUrl = Environment.GetEnvironmentVariable("API_ENDPOINT");
            
//             // Step 3: Validate environment variables and show helpful errors
            
//             // Step 4: Initialize the Azure AI client
//             // var endpoint = new Uri(endpointUrl);
//             // var client = new ChatCompletionsClient(endpoint, new AzureKeyCredential(token));
//             // var model = "gpt-4o";
            
//             // Step 5: Create specialized system message for travel assistance
//             // var messages = new List<ChatRequestMessage>
//             // {
//             //     new ChatRequestSystemMessage(@"You are an expert travel support agent...")
//             // };
            
//             // Step 6: Implement the conversation loop
//             // while (true)
//             // {
//             //     // Get user input
//             //     // Add user message to conversation history
//             //     // Send request to AI model
//             //     // Display response
//             //     // Add assistant response to conversation history
//             //     // Handle exit condition
//             // }
            
//             // Step 7: Add error handling with try-catch blocks
            
//             Console.WriteLine("\n⚠️  Assessment not yet implemented!");
//             Console.WriteLine("Please complete the implementation according to the requirements above.");
//             Console.WriteLine("\nPress any key to exit...");
//             Console.ReadKey();
//         }
        
//         // TODO: Add helper methods as needed
//         // Example: LoadEnvFile(), DisplayWelcomeMessage(), etc.
        
//         // Helper method suggestion - implement this:
//         // private static void LoadEnvFile()
//         // {
//         //     // Load environment variables from .env file
//         //     // Look at other examples for reference
//         // }
//     }
// }

using Azure;
using Azure.AI.Inference;
using System.Text;

namespace GenAIStarter
{
    /// <summary>
    /// Traveling Support Agent - Multi-turn travel assistance chatbot
    /// Implementation for the Assessment Task described in the assignment.
    /// Run with: dotnet run --project TravelingSupportAgent.csproj
    /// </summary>
    public class TravelingSupportAgent
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("=== Traveling Support Agent ===");
            Console.WriteLine("Your AI-powered travel companion. Type 'exit' to quit.\n");

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
                var endpoint = new Uri(endpointUrl);
                var client = new ChatCompletionsClient(endpoint, new AzureKeyCredential(token));
                var model = "gpt-4o";

                // System message defines the agent role and capabilities
                var messages = new List<ChatRequestMessage>
                {
                    new ChatRequestSystemMessage(@"You are an expert multi-turn travel support agent.
You help users plan trips and itineraries, recommend destinations, provide travel tips,
explain booking steps for flights/hotels/activities, offer cultural information and customs,
help with travel documentation and visa guidance (explain steps, required docs),
provide packing suggestions based on weather, advise on travel emergencies and problem-solving,
and support multiple travel styles (budget, luxury, adventure).

When answering:
- Ask clarifying questions when necessary (budget, travel dates, traveler type).
- Offer concrete suggestions and clear steps the user can take.
- Provide short sample itineraries when asked and a day-by-day breakdown for multi-day trips.
- When giving booking guidance, explain what to check (refund policy, change fees, ID requirements).
- If the user asks for live data (flight status, visa requirements for a specific nationality, current weather),
  say you can provide general guidance and offer to fetch up-to-date info if the program integrates an external API.")
                };

                Console.WriteLine("Ready. Ask me about trip planning, booking help, destinations, or type 'exit' to finish.\n");

                while (true)
                {
                    Console.Write("You: ");
                    var input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input) || input.Trim().ToLower() == "exit")
                    {
                        Console.WriteLine("Safe travels! 🌍");
                        break;
                    }

                    // Add user input to conversation history
                    messages.Add(new ChatRequestUserMessage(input));

                    // Build request with full conversation history
                    var requestOptions = new ChatCompletionsOptions { Model = model, Temperature = 0.7f, MaxTokens = 1500 };
                    foreach (var msg in messages)
                        requestOptions.Messages.Add(msg);

                    try
                    {
                        var response = await client.CompleteAsync(requestOptions);
                        var reply = response.Value.Content ?? "";

                        // Print assistant reply nicely
                        Console.WriteLine($"\nTravel Agent: {CleanAssistantOutput(reply)}\n");

                        // Add assistant reply to conversation history
                        messages.Add(new ChatRequestAssistantMessage(reply));
                    }
                    catch (RequestFailedException ex)
                    {
                        Console.Error.WriteLine($"API Error: {ex.Message}");
                        if (ex.Status == 401)
                        {
                            Console.Error.WriteLine("Authentication failed. Please check your API token and endpoint.");
                        }
                        Console.WriteLine("I'll continue running — please try again or type 'exit' to quit.");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Unexpected error: {ex.Message}");
                        Console.WriteLine("Please try again or type 'exit' to quit.");
                    }

                    Console.WriteLine(new string('-', 60));
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error initializing client: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        // Utility: simple markdown/format cleaner for console output
        private static string CleanAssistantOutput(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            var sb = new StringBuilder(text);
            sb.Replace("**", "");
            sb.Replace("__", "");
            sb.Replace("`", "");
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Load environment variables from .env file
        /// </summary>
        private static void LoadEnvFile()
        {
            try
            {
                var envFilePath = ".env";
                if (File.Exists(envFilePath))
                {
                    var lines = File.ReadAllLines(envFilePath);
                    foreach (var line in lines)
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