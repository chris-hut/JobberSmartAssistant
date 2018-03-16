# JobberSmartAssistant [![CircleCI](https://circleci.com/gh/gantonious/JobberSmartAssistant.svg?style=svg)](https://circleci.com/gh/gantonious/JobberSmartAssistant)

An assistant utilizing DialogFlow to help Jobber clients carry out common tasks and ask common questions without having to open up their laptop.

## Building

This project uses the .NET Core 2 SDK. If you don't have it available you can grab it from https://www.microsoft.com/net/download/. To build the project do:

```bash
dotnet restore
dotnet build
```

## Running

Running the project will first synchronize the defined intents to the DialogFlow project then launch the intent fulfillment server. To run the project do:

```bash
dotnet run -p Jobber.SmartAssistant/Jobber.SmartAssistant.csproj
```

Environment Variables:

- `JSA_DIALOG_FLOW_KEY`: API key for the DialogFlow project where intents should be synchronized to
- `PORT`: Defines the port the fulfillment server should be launched on

## Adding to the Conversation

### Intents

DialogFlow uses intents to mark the entry point of a conversation and how that conversation is carried out. The following is an example of creating a simple intent that asks a user for their favorite number:

```csharp
var intent = IntentBuilder.For("FAVORITE_NUMBER")
    .TriggerOn("Guess what my favorite number is?")
    .TriggerOn("Ask me what is my favorite number.")
    .RequireParameter(
        ParameterBuilder.Of("num", Entity.Number)
            .WithPrompt("What is your favorite number?")
    )
    .RespondsWith("Your favorite number is $num!")
    .Build();
```

Above we defined multiple trigger statements. DialogFlow will train using these statements to determine what statements should trigger this conversation. Sometimes we want to run some custom logic to determine how to respond to an intent. In that case we should drop the `RespondsWith()` method above and use this method instead:

```csharp
.FulfillWithWebhook()
```

This tells dialog flow to call into our own service to handle the request.

### Creating an Intent Definition

To add a new intent to the JobberSmartAssistant we need to create an implementation of `IIntentDefinition`. All this interface does is return an intent. We can just return the intent defined above:

```csharp
public class FavoriteNumberIntentDefinition : IIntentDefinition
{
    public Intent DefineIntent()
    {
        return IntentBuilder.For("FAVORITE_NUMBER")
            .TriggerOn("Guess what my favorite number is?")
            .TriggerOn("Ask me what is my favorite number.")
            .RequireParameter(
                ParameterBuilder.Of("num", Entity.Number)
                    .WithPrompt("What is your favorite number?")
            )
            .FulfillWithWebhook()
            .Build();
    }
}
```

### Creating an Intent Fulfiller

If we specify that we want an intent to be fulfilled by a webhook we then need to define an IntentFulfiller that can handle that logic. An IntentFulfiller should be able to answer if a fulfillment request belongs to that intent. If sho it should also define logic that handles the fulfillment request. We can make one for the favorite number intent as follows:

```csharp
public class FavoriteNumberIntentFulfiller : IJobberIntentFulfiller
{
    public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
    {
        return fulfillmentRequest.IsForAction("FAVORITE_NUMBER");
    }

    public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
    {
        var num = fulfillmentRequest.GetParameterAsInt("num");

        return FulfillmentResponseBuilder.Create()
            .Speech($"Your favorite number is {num}")
            .Build();
    }
}
```

As shown above the `FulfillAsync()` method receives an instance of an `IJobberService`. This service provides access to the user's Jobber account that triggered the request. You can use this to actually query and modify the users account data for a real request.

### Registering the new Intent Definition and Fulfiller

After implementing custom intent definitions and fulfillers they can be registered by modifying the `BuildIntentRegistry()` and `BuilderIntentFulfiller()` methods in the main program:

```csharp
private static IIntentRegistry BuildIntentRegistry()
{
    return new DefaultIntentRegistry()
        ...
        ...
        .WithIntentDefinition(new FavoriteNumberIntentDefinition());
}

private static IIntentFulfiller BuildIntentFulfiller()
{
    return new JobberSmartAssistantIntentFulfiller()
        ...
        ...
        .WithJobberIntentFulfiller(new FavoriteNumberIntentFulfiller());
}
```

# License

```
MIT License

Copyright (c) 2018 Jobber

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```