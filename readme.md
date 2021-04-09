# Dapr Sample Project for Secret Retrieval

## Prerequisites

- [.NET Core 3.1 or .NET 5+](https://dotnet.microsoft.com/download) installed
- [Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/)
- [Initialized Dapr environment](https://docs.dapr.io/getting-started/install-dapr-selfhost/)
- [Dapr .NET SDK](https://docs.dapr.io/developing-applications/sdks/dotnet/)

## Overview
The Secrets management building block in Dapr currently has a few different options for accessing the store from a .NET application:
* HTTP
* Using the DaprClient in the Dapr .NET SDK
* Using the configuration provider in the .NET SDK

The first two are fairly straight forward and the third is only slightly more complex, but it adds benefits of tying into the existing .NET configuration system and allowing for dependency injection. All three are demonstrated in the Startup.cs file using a local secret store located at /components/dapr-secretstore.json and defined by /components/secretstore.yaml.

This sample is not meant to recommend one method over another, just to demonstrate their usage in a simple app.

## Run the app
Since Dapr is integrated into the solution, use Dapr to run using the following command:
 ```shell
 dapr run --app-id DaprSecretsExample --dapr-http-port 3500 --components-path ./components -- dotnet run
 ```

 Once running, open a browser and navigate to [https://localhost:5001/](https://localhost:5001/) to see the results (it's not very exciting.)