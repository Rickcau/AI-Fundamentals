# Chat Completion Endpoint Examples

## Simple Chat Completion Call
***Endpoint:***
***POST*** https://{your-resource-name}.openai.azure.com/openai/deployments/{deployment-id}/chat/completions?api-version=2023-05-15
***Request Body:***
```
      {
        "model": "gpt-4",
        "messages": [
          {
            "role": "system",
            "content": "You are a helpful assistant."
          },
          {
            "role": "user",
            "content": "Why is the sky blue?"
          }
        ],
        "max_tokens": 100,
        "temperature": 0.7
      }
```

## Simple Chat Completion Call with Function Calling
***Endpoint:***
***POST*** https://{your-resource-name}.openai.azure.com/openai/deployments/{deployment-id}/chat/completions?api-version=2023-05-15
***Request Body:***
```
      {
        "messages": [
          {
            "role": "system",
            "content": "You are a helpful assistant that can call functions when needed."
          },
          {
            "role": "user",
            "content": "What's the weather in New York?"
          }
        ],
        "functions": [
          {
            "name": "get_weather",
            "description": "Get the current weather for a specified location.",
            "parameters": {
              "type": "object",
              "properties": {
                "location": {
                  "type": "string",
                  "description": "The location for which to get the weather."
                }
              },
              "required": ["location"]
            }
          }
        ],
        "function_call": "auto", 
        "max_tokens": 100,
        "temperature": 0.7,
        "deployment_id": "{your-deployment-id}"
      }
```

## Simple Chat Completion Call with Function Calling and Chain of Thought
***Endpoint:***
***POST*** https://{your-resource-name}.openai.azure.com/openai/deployments/{deployment-id}/chat/completions?api-version=2023-05-15
***Request Body:***
```
      {
        "messages": [
          {
            "role": "system",
            "content": "You are a helpful assistant that can think step-by-step and call functions when needed."
          },
          {
            "role": "user",
            "content": "What's the weather in New York?"
          },
          {
            "role": "assistant",
            "content": "Let's think step by step. First, I need to determine if the user's query is related to weather. Since the user asked about the weather in New York, I will call the 'get_weather' function to retrieve the relevant information."
          }
        ],
        "functions": [
          {
            "name": "get_weather",
            "description": "Get the current weather for a specified location.",
            "parameters": {
              "type": "object",
              "properties": {
                "location": {
                  "type": "string",
                  "description": "The location for which to get the weather."
                }
              },
              "required": ["location"]
            }
          }
        ],
        "function_call": "auto",
        "max_tokens": 100,
        "temperature": 0.7,
        "deployment_id": "{your-deployment-id}"
      }
```
