using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using System.Configuration;
using Console_SK_DeFi_Assistant.Plugins;
using Console_SK_Assistant.Plugins;

Console.WriteLine("Hello, this is our first Semantic Kernel App, using plugins.");

// 5 Simple steps to use the Kernel!

#region Step 1 - Create Kernel Builder
// Create a Builder for Creating Kernel Objects
var builder = Kernel.CreateBuilder();
#endregion

#region Step 2 - Load AI Endpoint Values

var openAiDeployment = ConfigurationManager.AppSettings.Get("AzureOpenAIModel");
var openAiUri = ConfigurationManager.AppSettings.Get("AzureOpenAIEndpoint");
var openAiApiKey = ConfigurationManager.AppSettings.Get("AzureOpenAIKey");

#endregion

#region Step 3 - Add ChatCompletion Service

builder.Services.AddAzureOpenAIChatCompletion(
   deploymentName: openAiDeployment!,
   endpoint: openAiUri!,
   apiKey: openAiApiKey!);

#endregion

#region Step 4 - Add our Plugins
builder.Plugins.AddFromType<UniswapV3SubgraphPlugin>();
builder.Plugins.AddFromType<LightOnPlugin>();
builder.Plugins.AddFromType<WeatherPlugin>();
#endregion


#region Step 5 - Construct Kernel, ChatHistory Get instance of ChatCompletion Service
// Construct instance of Kernel using Builder Settings
var kernel = builder.Build();

ChatHistory history = [];
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

#endregion

#region Step 6 - Chat Loop

while (true)
{
    Console.Write(">> ");
    var userMessage = Console.ReadLine();
    if (userMessage != "Exit")
    {
        history.AddUserMessage(userMessage!);

        // Not really being used in this example but we will use it in future examples
        OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
        };

        try
        {
            var result = await chatCompletionService.GetChatMessageContentAsync(
                history,
                executionSettings: openAIPromptExecutionSettings,
                kernel: kernel);

            Console.WriteLine("<< " + result);

            if (result.Content != null)
            {
                history.AddAssistantMessage(result.Content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    else break;
}

#endregion

