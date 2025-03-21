using Azure;
using Azure.AI.Inference;
using Microsoft.Extensions.AI;
using OllamaSharp;

var provider = AIProviders.GitHub;

// Construct client
IChatClient chatClient =
    provider switch
    {
        AIProviders.GitHub => 
            new ChatCompletionsClient(
                new Uri("https://models.inference.ai.azure.com"),
                new AzureKeyCredential(Environment.GetEnvironmentVariable("GITHUB_TOKEN")))
                .AsChatClient("mistral-small-2503"), // Mistral Small 3.1
        AIProviders.Ollama => 
            new OllamaApiClient("http://localhost:11434", "gemma3:4b"),
        _ => throw new NotImplementedException($"Provider {provider} is not implemented.")
    };


// Get sentiment
var input = new ReviewSentiment("I love this product!", null);

var response = await chatClient.GetResponseAsync<ReviewSentiment>($"What is the sentiment of this review? {input.Text}");

Console.WriteLine($"Text: {response.Result.Text} | Sentiment: {response.Result.CustomerSentiment}");

record ReviewSentiment(string Text, Sentiment? CustomerSentiment);

public enum Sentiment
{
    Positive,
    Negative,
    Neutral
}

public enum AIProviders
{
    GitHub,
    Ollama
}