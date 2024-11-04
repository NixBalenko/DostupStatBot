using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotConsoleApp
{
    public static class BotHandleEvents {

        // Handle incoming updates (messages, commands, etc.)
        public static async Task HandleUpdateAsyncWithCancelationToken(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await HandleUpdateAsync(botClient, update);
        }
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update)
        {

            if (update.Type == UpdateType.Message)
            {
                await ProcessMessageUpdate(botClient, update);
            }

            if (update.Type == UpdateType.CallbackQuery)
            {
                await MainBotNavigation.ProccessCallbackUpdate(botClient, update);
            }
            // Ignore anything else
            Console.WriteLine($"Update with type " + update.Type + " received");
            if (update.Type != UpdateType.Message) return;
            if (update.Message!.Type != MessageType.Text) return;

        }

        private static async Task ProcessMessageUpdate(ITelegramBotClient botClient, Update update)
        {
            try
            {
                var chatId = update.Message.Chat.Id;
                var messageText = update.Message.Text;

                Console.WriteLine($"Received a message from {chatId}: {messageText}");
                // Check if the user is currently waiting for a number input
                var userInput = await State.TryToStoreReportValue(botClient, chatId, messageText);
                if (userInput)
                {
                    await MainBotNavigation.ShowReportScreen(botClient, chatId);
                    return;
                }

                // Simple command handling
                await MainBotNavigation.ProcessCommands(botClient, chatId, messageText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}