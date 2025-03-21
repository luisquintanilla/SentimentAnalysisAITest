# Sentiment Analysis Sample

Sample using GH Models and Ollama with Microsoft.Extensions.AI.

## Quickstart

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://github.com/codespaces/new?hide_repo_select=true&ref=main&repo=952629371&skip_quickstart=true&machine=standardLinux32gb&devcontainer_path=.devcontainer.json&geo=UsEast)

## Prerequisites

- .NET 9
- If using GH Models, you need a GH Token
- If using Ollama, you need Ollama

## Changing providers

Update the following code to use the respective provider

```csharp
var provider = AIProviders.GitHub;
```