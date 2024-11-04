using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;

namespace BotConsoleApp
{
    public static class Program
    {
        private static TelegramBotClient _botClient;

        static async Task Main(string[] args)
        {
            var token = Environment.GetEnvironmentVariable("DostupStatBot_BotToken");
            _botClient = new TelegramBotClient(token);

            Console.WriteLine($"Bot is starting...");

            var me = await _botClient.GetMe();
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            using var cts = new CancellationTokenSource();

            // Set up receiving messages
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            _botClient.StartReceiving(
                BotHandleEvents.HandleUpdateAsyncWithCancelationToken,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token
            );

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            // Cancel the bot on key press
            cts.Cancel();
        }



        // Error handling
        static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);
            return Task.CompletedTask;
        }
    }
}