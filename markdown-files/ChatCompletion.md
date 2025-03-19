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
