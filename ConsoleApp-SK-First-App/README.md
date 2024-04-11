# Chat Completion using Semantic Kernel
Now, let's leverage the Semantic Kernel for Chat Completions.  This will prepare you for the more powerful features of the Semantic Kernel, which we will see in the next example.

## There are 5 basic steps that are needed for any Chat Completion with Semantic Kernel
    1. Create the Kernel Builder
	2. Load the AI Endpoint variables
	3. Add the Chat Completion Serivce to the Services collection
	4. Construct Kernel, ChatHistory, get an instance of ChatCompletion Service
	5. Send the prompt and display the response

### Step 1: Create the Kernel Builder
The Kernel Builder is the main entry point for creating a Kernel.  It is used to configure the Kernel and build the Kernel.

    var builder = Kernel.CreateBuilder();

### Step 2: Load the AI Endpoint variables
The AI Endpoint variables are used to connect to the AI Endpoint.  

	var openAiDeployment = ConfigurationManager.AppSettings.Get("AzureOpenAIModel");
    var openAiUri = ConfigurationManager.AppSettings.Get("AzureOpenAIEndpoint");
    var openAiApiKey = ConfigurationManager.AppSettings.Get("AzureOpenAIKey");;

### Step 3: Add the Chat Completion Serivce to the Services collection
We need to add the Chat Completion Service to the Services collection.  This is done by calling the AddAzureOpenAIChatCompletion extension method on the Kernel Builder.

    builder.Services.AddAzureOpenAIChatCompletion(
       deploymentName: openAiDeployment!,
       endpoint: openAiUri!,
       apiKey: openAiApiKey!);

### Step 4: Construct Kernel, ChatHistory, get an instance of ChatCompletion Service
We need to build the Kernel and create a ChatHistory object.  The ChatHistory object is used to keep track of the conversation.  We also need to get an instance of the ChatCompletion Service.

	var kernel = builder.Build();
	var chatHistory = new ChatHistory();
	var chatCompletion = kernel.GetRequiredService<ChatCompletion>();

### Step 5: Send the prompt and display the response
We can now send the prompt to the ChatCompletion Service and display the response.

	var response = await chatCompletion.CompleteAsync(chatHistory, "What is the capital of France?");
	Console.WriteLine(response.Text);

