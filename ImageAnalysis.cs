using Azure;
using Azure.AI.Inference;

namespace GenAIStarter
{
    /// <summary>
    /// Image Analysis Example - Using GPT-4o Vision Capabilities
    /// 
    /// This example demonstrates how to use GPT-4o's vision capabilities to analyze images.
    /// The application:
    /// 1. Loads a sample image from the app/images folder
    /// 2. Converts the image to a base64 data URL format
    /// 3. Sends both text and image data to the AI model
    /// 4. Receives a detailed description of what's in the image
    /// 
    /// Key concepts demonstrated:
    /// - Multi-modal input handling (text + image)
    /// - File system operations for reading image files
    /// - Base64 encoding for image data transmission
    /// - Error handling for file operations
    /// - Vision model configuration and usage
    /// 
    /// This showcases the multimodal capabilities of modern AI models that can understand
    /// and describe visual content alongside text prompts.
    /// 
    /// Converted from sample-image.js
    /// Run with: dotnet run --project ImageAnalysis.csproj
    /// </summary>
    public class ImageAnalysis
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("=== Image Analysis Example - GPT-4o Vision ===\n");

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
                var model = "gpt-4o"; // GPT-4o model for vision capabilities

                Console.WriteLine("Analyzing image with GPT-4o Vision...\n");

                // Get the image data URL
                var imageDataUrl = GetImageDataUrl("sample.jpg", "jpg");
                if (imageDataUrl == null)
                {
                    return; // Error already handled in GetImageDataUrl
                }

                // Create the request with both text and image content
                var requestOptions = new ChatCompletionsOptions
                {
                    Model = model,
                    Messages =
                    {
                        // System message defines the AI's role for image description
                        new ChatRequestSystemMessage("You are a helpful assistant that describes images in details."),
                        // User message contains both text query and image data
                        new ChatRequestUserMessage(
                            new ChatMessageTextContentItem("What's in this image?"),
                            new ChatMessageImageContentItem(new Uri(imageDataUrl), ChatMessageImageDetailLevel.Low)
                        )
                    },
                    Temperature = 0.7f,
                    MaxTokens = 1000
                };

                // Send the request and get the response
                var response = await client.CompleteAsync(requestOptions);

                // Output the AI's description of the image
                Console.WriteLine("AI's Image Description:");
                Console.WriteLine("======================");
                Console.WriteLine(response.Value.Content);
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"API Error: {ex.Message}");
                if (ex.Status == 401)
                {
                    Console.Error.WriteLine("Authentication failed. Please check your GitHub token.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Utility method to convert an image file to a base64 data URL
        /// This is required for sending image data to the AI model via API
        /// </summary>
        /// <param name="imageFile">The filename of the image file (e.g., "sample.jpg")</param>
        /// <param name="imageFormat">The format of the image file (e.g., "jpg", "png")</param>
        /// <returns>The data URL of the image, or null if an error occurred</returns>
        private static string? GetImageDataUrl(string imageFile, string imageFormat)
        {
            try
            {
                // Construct the full path to the image in the images folder
                var imagePath = Path.Combine("images", imageFile);
                
                // Check if the file exists
                if (!File.Exists(imagePath))
                {
                    Console.Error.WriteLine($"Could not find image file: {imagePath}");
                    Console.Error.WriteLine("Please ensure the image file exists in the images/ directory.");
                    Console.Error.WriteLine("Expected structure:");
                    Console.Error.WriteLine("  images/");
                    Console.Error.WriteLine("    sample.jpg");
                    return null;
                }

                // Read the image file as bytes
                var imageBytes = File.ReadAllBytes(imagePath);
                
                // Convert the bytes to base64 string
                var imageBase64 = Convert.ToBase64String(imageBytes);
                
                // Return the complete data URL format required by the API
                return $"data:image/{imageFormat};base64,{imageBase64}";
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error reading image file '{imageFile}': {ex.Message}");
                Console.Error.WriteLine("Please ensure:");
                Console.Error.WriteLine("1. The image file exists in images/ directory");
                Console.Error.WriteLine("2. The file has proper read permissions");
                Console.Error.WriteLine("3. The file is a valid image format");
                return null;
            }
        }

        /// <summary>
        /// Load environment variables from .env file
        /// </summary>
        private static void LoadEnvFile()
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
    }
}