
using Azure;
using Azure.AI.OpenAI;
using System.Configuration;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, this is our first Azure OpenAI Application ");

#region Step 1 - Populate Azure OpenAI Configuration variables
var openAiDeployment = ConfigurationManager.AppSettings.Get("AzureOpenAIModel");
var openAiUri = ConfigurationManager.AppSettings.Get("AzureOpenAIEndpoint");
var openAiApiKey = ConfigurationManager.AppSettings.Get("AzureOpenAIKey");
#endregion

#region Step 2 - Create an OpenAI client
OpenAIClient client = new OpenAIClient(
          new Uri(openAiUri!),
          new AzureKeyCredential(openAiApiKey!));
#endregion

#region Step 3 - Create a ChatCompletionsOptions object
var chatCompletionsOptions = new ChatCompletionsOptions()
{
    DeploymentName = openAiDeployment, // Use DeploymentName for "model" with non-Azure clients
    Messages =
    {
        // The system message represents instructions or other guidance about how the assistant should behave
        new ChatRequestSystemMessage("You are a helpful assistant. You will talk like a pirate."),
        // User messages represent current or historical input from the end user
        new ChatRequestUserMessage("Can you help me?"),
        // Assistant messages represent historical responses from the assistant
        new ChatRequestAssistantMessage("Arrrr! Of course, me hearty! What can I do for ye?"),
        new ChatRequestUserMessage("What's the best way to train a parrot?"),
    }
};
#endregion

#region Step 4 - Call the GetChatCompletionsAsync method
Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
#endregion

#region Step 5 - Display the response
ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
Console.WriteLine($"[{responseMessage.Role.ToString().ToUpperInvariant()}]: {responseMessage.Content}");
#endregion
