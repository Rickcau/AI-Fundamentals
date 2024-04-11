# Chat Completion using Azure OpenAI SDK
We start our code journey by first using the Azure OpenAI SDK to generate chat completions. We will use the GPT-3.5 model for this purpose.

## There are 5 basic steps that are needed for any Chat Completion

	1. Populate the Azure OpenAI Configuration variables
	2. Create the Azure OpenAI Client
	3. Create the Azure OpenAI Chat Completion Object
	4. Call the GetChatCompletionAsync method 
	5. Display the Chat Completion Response

### Step 1: Populate the Azure OpenAI Configuration variables
    	
	   var openAiDeployment = ConfigurationManager.AppSettings.Get("AzureOpenAIModel");
       var openAiUri = ConfigurationManager.AppSettings.Get("AzureOpenAIEndpoint");
       var openAiApiKey = ConfigurationManager.AppSettings.Get("AzureOpenAIKey");


### Step 2: Create the Azure OpenAI Client

	   OpenAIClient client = new OpenAIClient(
          new Uri(openAiUri!),
          new AzureKeyCredential(openAiApiKey!));


### Step 3: Create the Azure OpenAI Chat Completion Object

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


### Step 4: Call the GetChatCompletionAsync method

	   Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);

### Step 5: Display the Chat Completion Response

	   ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
	   Console.WriteLine($"[{responseMessage.Role.ToString().ToUpperInvariant()}]: {responseMessage.Content}");
