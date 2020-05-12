# DemoWebAPI

This is a Demo Web API, it is only implemented for MSRD tests

This API uses ASP.NET Core 2.2 now

## analyzers

dotnet add package StyleCop.Analyzers --version 1.1.118
dotnet add package Microsoft.CodeAnalysis.FxCopAnalyzers --version 2.9.8

## architecture

Here I follow a DDD Microservices based architecture:

https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice


[![Total alerts](https://img.shields.io/lgtm/alerts/g/RafaPazos/DemoWebAPI.svg?logo=lgtm&logoWidth=18)](https://lgtm.com/projects/g/RafaPazos/DemoWebAPI/alerts/)


https://ade.applicationinsights.io/subscriptions/95b44dd6-5808-485e-9f1a-923eaeef3b37/resourcegroups/rpr-umbraco/providers/microsoft.insights/components/rpr-umbraco-appin

# the WhiteSource Agent
java -jar wss-unified-agent.jar -c wss-unified-agent.config -apiKey 5ed1de1e9fca420d886a08bebca2b0ba1d707b6ffd33494c8b656a927646bd4e -product DemoWebAPI -project DemoRESTAPI
