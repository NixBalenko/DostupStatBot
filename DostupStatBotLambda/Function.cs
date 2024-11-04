using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.SystemTextJson;
using BotConsoleApp;
using Newtonsoft.Json;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;


var token = Environment.GetEnvironmentVariable("DostupStatBot_BotToken");
if (token == null) {
    throw new Exception("Specify value of DostupStatBot_BotToken as env variable for your AWS Lambda");
}
TelegramBotClient _botClient = new TelegramBotClient(token);


// The function handler that will be called for each Lambda event
var handler = async (Update update, ILambdaContext context) =>
{
    try
    {     
        context.Logger.LogLine($"Received Update: {JsonConvert.SerializeObject(update)}");
        await BotHandleEvents.HandleUpdateAsync(_botClient, update);
        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = "Ok"
        };
    }
    catch (Exception ex)
    {
        context.Logger.LogLine($"Error: {ex.Message}");
        return new APIGatewayProxyResponse
        {
            StatusCode = 500,
            Body = "Internal Server Error"
        };
    }
};

// Build the Lambda runtime client passing in the handler to call for each
// event and the JSON serializer to use for translating Lambda JSON documents
// to .NET types.
// Create a JsonSerializerOptions instance with camel case property naming

var serializer = new DefaultLambdaJsonSerializer(x => x.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower);

await LambdaBootstrapBuilder.Create(handler, serializer)
    .Build()
    .RunAsync();