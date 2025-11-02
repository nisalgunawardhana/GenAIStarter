/*
 * Assessment Task: Multi-turn Traveling Support Agent Chatbot
 * 
 * Showcase your achievement on LinkedIn, GitHub, or your portfolio to impress future employers and peers!
 * 
 * You are required to build a multi-turn chatbot that provides traveling support assistance using the GPT-4o model 
 * via GitHub's AI inference API. Your chatbot should maintain conversation context, offer meaningful travel help, 
 * and support various travel scenarios and destinations.
 * 
 * What to Do:
 * 
 * 1. Environment Setup
 *    - Load environment variables from .env file
 *    - Use your GitHub token from API_TOKEN environment variable
 *    - Ensure your .env is listed in .gitignore
 * 
 * 2. API Initialization  
 *    - Use the Azure.AI.Inference package (already included)
 *    - Configure the API client to use your GitHub token and the GitHub models endpoint
 * 
 * 3. Conversation Logic
 *    - Implement a loop that lets the user and bot exchange messages
 *    - Store the conversation history so the chatbot remembers previous messages
 *    - Allow the user to exit the chat gracefully (e.g., by typing 'exit')
 * 
 * 4. Traveling Support Features
 *    - Help users plan trips and itineraries
 *    - Provide destination recommendations and travel tips
 *    - Assist with booking guidance (flights, hotels, activities)
 *    - Offer cultural information and local customs advice
 *    - Help with travel documentation and visa requirements
 *    - Provide weather information and packing suggestions
 *    - Handle travel emergencies and problem-solving
 *    - Support multiple destinations and travel styles (budget, luxury, adventure, etc.)
 * 
 * 5. Error Handling
 *    - Handle API errors and invalid inputs gracefully
 *    - Provide helpful error messages to users
 * 
 * Example Interactions:
 * 
 * User: "I want to plan a 7-day trip to Japan in spring"
 * Agent: "That sounds wonderful! Spring is cherry blossom season in Japan. I can help you plan an amazing 7-day itinerary. 
 *         What's your budget range and what type of experiences interest you most - cultural sites, food, nature, or modern attractions?"
 * 
 * User: "I'm having trouble with my flight booking, it got cancelled"
 * Agent: "I'm sorry to hear about your cancelled flight. Let me help you with the next steps. First, contact your airline 
 *         for rebooking options. Are you traveling soon? I can also suggest alternative flights and help you understand your rights."
 * 
 * Where to Implement:
 * - Complete the implementation in this file (TravelingSupportAgent.cs)
 * - Follow the existing patterns from other examples in this project
 * - Use the same project structure and dependencies
 * 
 * Running Your Solution:
 * dotnet run --project TravelingSupportAgent.csproj
 * 
 * Complete the assessment as described below to earn your certificate and badge!
 * 
 * Once you have finished implementing your multi-turn traveling support agent chatbot and submitted your pull request, 
 * you will be eligible to receive an official certificate and badge.
 * 
 * How to claim your certificate and badge:
 * 1. Complete all steps in the "Assessment Task" section above
 * 2. Test your implementation thoroughly
 * 3. Submit your solution following the submission guidelines
 * 4. After your submission is reviewed and approved, you will receive your personalized certificate and badge via email
 * 
 * Submission Guidelines:
 * 1. Ensure your code follows the existing project patterns
 * 2. Test your implementation with various travel scenarios
 * 3. Make sure error handling works properly
 * 4. Document any additional features you've implemented
 * 5. Create a pull request with your completed solution
 * 
 * Tips for Success:
 * - Study the existing examples (MultiTurnChat.cs, CodingAssistant.cs) for patterns
 * - Focus on creating a helpful and knowledgeable travel assistant
 * - Consider edge cases and error scenarios
 * - Make the conversation feel natural and engaging
 * - Test with various travel-related queries
 * 
 * Good luck with your implementation!
 */

using Azure;
using Azure.AI.Inference;

namespace GenAIStarter
{
    /// <summary>
    /// Traveling Support Agent - Multi-turn travel assistance chatbot
    /// Assessment Task: Implement a comprehensive travel support agent
    /// Run with: dotnet run --project TravelingSupportAgent.csproj
    /// </summary>
    public class TravelingSupportAgent
    {
        public static void Main(string[] args)
        {
            // TODO: Implement the traveling support agent here
            // Follow the assessment requirements above
            
            Console.WriteLine("=== Traveling Support Agent Assessment ===");
            Console.WriteLine("Welcome to your Travel Assistant implementation task!");
            Console.WriteLine("\nPlease implement the traveling support agent according to the assessment requirements.");
            Console.WriteLine("Check the comments above for detailed instructions.");
            Console.WriteLine("\nFeatures to implement:");
            Console.WriteLine("- Multi-turn conversation with memory");
            Console.WriteLine("- Travel planning and itinerary assistance");
            Console.WriteLine("- Destination recommendations");
            Console.WriteLine("- Booking guidance and support");
            Console.WriteLine("- Cultural information and tips");
            Console.WriteLine("- Travel documentation help");
            Console.WriteLine("- Emergency assistance");
            Console.WriteLine("- Weather and packing advice");
            Console.WriteLine("\nType 'exit' to quit when implemented.");
            
            // IMPLEMENTATION AREA - Add your code below this line
            // =====================================================
            
            // Step 1: Load environment variables from .env file
            // Hint: Look at other examples for the LoadEnvFile() method
            
            // Step 2: Get API configuration
            // var token = Environment.GetEnvironmentVariable("API_TOKEN");
            // var endpointUrl = Environment.GetEnvironmentVariable("API_ENDPOINT");
            
            // Step 3: Validate environment variables and show helpful errors
            
            // Step 4: Initialize the Azure AI client
            // var endpoint = new Uri(endpointUrl);
            // var client = new ChatCompletionsClient(endpoint, new AzureKeyCredential(token));
            // var model = "gpt-4o";
            
            // Step 5: Create specialized system message for travel assistance
            // var messages = new List<ChatRequestMessage>
            // {
            //     new ChatRequestSystemMessage(@"You are an expert travel support agent...")
            // };
            
            // Step 6: Implement the conversation loop
            // while (true)
            // {
            //     // Get user input
            //     // Add user message to conversation history
            //     // Send request to AI model
            //     // Display response
            //     // Add assistant response to conversation history
            //     // Handle exit condition
            // }
            
            // Step 7: Add error handling with try-catch blocks
            
            Console.WriteLine("\n⚠️  Assessment not yet implemented!");
            Console.WriteLine("Please complete the implementation according to the requirements above.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // TODO: Add helper methods as needed
        // Example: LoadEnvFile(), DisplayWelcomeMessage(), etc.
        
        // Helper method suggestion - implement this:
        // private static void LoadEnvFile()
        // {
        //     // Load environment variables from .env file
        //     // Look at other examples for reference
        // }
    }
}