# Console Web Job with a Timer POC

The goal of this project is to demonstrate how to create an Azure WebJob that is triggered on a Timer, and will utlilize Application Insights.

This project in written in C#, and uses .NET 4.7.

In order to get things working, an azure storage connection string will be needed, as well as an Application Insights Instrumentation Key. These values will be placed into the appsettings.json file.

```
{
   "AzureWebJobsStorage": "AzureStorageConnectionString",
   "APPINSIGHTS_INSTRUMENTATIONKEY": "APPINSIGHTS_INSTRUMENTATIONKEY",
   "ConnectionStrings": {
      "AzureWebJobsStorage": "AzureStorageConnectionString"
   }
}

```



### Packages used
```
Microsoft.Azure.WebJobs
Microsoft.Azure.WebJobs.Core
Microsoft.Azure.WebJobs.Extensions
Microsoft.Azure.WebJobs.Host.Storage
Microsoft.Azure.WebJobs.Logging
Microsoft.Azure.WebJobs.Logging.ApplicationInsights
Microsoft.Azure.Storage.Common
Microsoft.ApplicationInsights
Microsoft.ApplicationInsights.Channel
Microsoft.ApplicationInsights.Extensibility
Microsoft.Extensions.DependencyInjection
Microsoft.Extensions.Logging
Microsoft.Extensions.Logging.Console
```

### Web Resources

```
[Getting Started](https://docs.microsoft.com/en-us/azure/app-service/webjobs-sdk-get-started)
[Web Jobs "How To"](https://docs.microsoft.com/en-us/azure/app-service/webjobs-sdk-how-to)
[Setting up a Timer](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer?tabs=csharp)
[Some Sample Code](https://github.com/Azure/azure-webjobs-sdk/tree/dev/sample/SampleHost)
```