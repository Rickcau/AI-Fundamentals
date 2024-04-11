# Advanced: Chat Completion with Semantic Kernel plus adding additional features with Plugins
Now, let's take our skills to the next level but adding features to our Chat Bot that are not possible with LLMS by using Plugins.  This exercise will prepare you for building more advanced Chat Bots that can handle more complex conversations.

## There are 6 basic steps that are needed for any Chat Completion with Semantic Kernel Plugins
    1. Create the Kernel Builder
	2. Load the AI Endpoint variables
	3. Add the Chat Completion Serivce to the Services collection
	4. Add the Plugins to the Services collection
	5. Construct Kernel, ChatHistory Get instance of ChatCompletion Service
	6. Create the Chat Loop

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

### Step 4: Add the Plugins to the Services collection
We need to add the Plugins to the Services collection.  This is done by calling the AddPlugin extension method on the Kernel Builder.

	builder.Plugins.AddFromType<UniswapV3SubgraphPlugin>();
    builder.Plugins.AddFromType<LightOnPlugin>();
    builder.Plugins.AddFromType<WeatherPlugin>();

### Step 5: Construct Kernel, ChatHistory Get instance of ChatCompletion Service
We need to construct the Kernel, ChatHistory and get an instance of the ChatCompletion Service.

	var kernel = builder.Build();
    ChatHistory history = [];
    var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

### Step 6: Create the Chat Loop
We need to create the Chat Loop.  This is done by calling the Chat method on the ChatCompletion Service.

	while (true)
	{
		Console.Write("You: ");
		var input = Console.ReadLine();
		history.Add(new ChatHistoryItem(input, ChatParticipant.User));
		var response = chatCompletionService.Chat(history);
		Console.WriteLine($"Bot: {response}");
		history.Add(new ChatHistoryItem(response, ChatParticipant.Bot));
	}
