using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotConsoleApp
{
    public static class XeroxReport {

        public static async Task CreateNewReportXeroxTaken(ITelegramBotClient botClient, long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
             {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📄 Paper: {State.GetReportValue(chatId, "createnewreport_xerox_taken_paper")}", "createnewreport_xerox_taken_paper")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📁 Files: {State.GetReportValue(chatId, "createnewreport_xerox_taken_files")}", "createnewreport_xerox_taken_files")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📑 Folders: {State.GetReportValue(chatId, "createnewreport_xerox_taken_folders")}", "createnewreport_xerox_taken_folders")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"🍫 Candy: {State.GetReportValue(chatId, "createnewreport_xerox_taken_candies")}", "createnewreport_xerox_taken_candies")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Back", "createnewreport_xerox")
                }
            });


            await botClient.SendMessage(
                chatId,
                "Xerox Taken report",
                replyMarkup: inlineKeyboard
            );
        }

        public static async Task CreateNewReportXeroxLeftover(ITelegramBotClient botClient, long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
             {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📄 Paper: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_paper")}", "createnewreport_xerox_leftover_paper")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📁 Files: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_files")}", "createnewreport_xerox_leftover_files")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📑 Folders: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_folders")}", "createnewreport_xerox_leftover_folders")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"🍫 Candy: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_candies")}", "createnewreport_xerox_leftover_candies")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Back", "createnewreport_xerox")
                }
            });


            await botClient.SendMessage(
                chatId,
                "Xerox Leftover report",
                replyMarkup: inlineKeyboard
            );
        }
    }
}