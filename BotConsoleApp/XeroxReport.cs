using System;
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
                    InlineKeyboardButton.WithCallbackData($"📄 Папір: {State.GetReportValue(chatId, "createnewreport_xerox_taken_paper")}", "createnewreport_xerox_taken_paper")
                },
                [
                    InlineKeyboardButton.WithCallbackData($"📁 Файли: {State.GetReportValue(chatId, "createnewreport_xerox_taken_files")}", "createnewreport_xerox_taken_files")
                ],
                [
                    InlineKeyboardButton.WithCallbackData($"📑 Папки: {State.GetReportValue(chatId, "createnewreport_xerox_taken_folders")}", "createnewreport_xerox_taken_folders")
                ],
                [
                    InlineKeyboardButton.WithCallbackData($"🍫 Батончики: {State.GetReportValue(chatId, "createnewreport_xerox_taken_candies")}", "createnewreport_xerox_taken_candies")
                ],
                [
                    InlineKeyboardButton.WithCallbackData("Згенерувати", "submit_xerox_taken")
                ],
                [
                    InlineKeyboardButton.WithCallbackData("Заповнити заново", "reset_all")
                ]
            });


            await botClient.SendMessage(
                chatId,
                "Звіт взятих матеріалів для ксероксу",
                replyMarkup: inlineKeyboard
            );
        }

        public static async Task CreateNewReportXeroxLeftover(ITelegramBotClient botClient, long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
             {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📄 Папір: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_paper")}", "createnewreport_xerox_leftover_paper")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📁 Файли: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_files")}", "createnewreport_xerox_leftover_files")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"📑 Папки: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_folders")}", "createnewreport_xerox_leftover_folders")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"🍫 Батончики: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_candies")}", "createnewreport_xerox_leftover_candies")
                },
                [
                    InlineKeyboardButton.WithCallbackData("Згенерувати", "submit_xerox_leftover")
                ],
                [
                    InlineKeyboardButton.WithCallbackData("Заповнити заново", "reset_all")
                ]
            });


            await botClient.SendMessage(
                chatId,
                "Щоденний Звіт роботи ксероксу по залишкам",
                replyMarkup: inlineKeyboard
            );
        }

        public static async Task SubmitXeroxTaken(ITelegramBotClient botClient, long chatId)
        {
            var message = $"Звіт взятих матеріалів для ксероксу за {DateTime.Now.ToString("dd.MM.yyyy")}" +
                $"\n📄 Папір: {State.GetReportValue(chatId, "createnewreport_xerox_taken_paper")} уп." +
                $"\n📁 Файли: {State.GetReportValue(chatId, "createnewreport_xerox_taken_files")} уп. "+
                $"\n📑 Папки: {State.GetReportValue(chatId, "createnewreport_xerox_taken_folders")} уп." +
                $"\n🍫 Батончики: {State.GetReportValue(chatId, "createnewreport_xerox_taken_candies")} уп.";
            //clean state
            State.Reset(chatId, "createnewreport_xerox_taken");
            await botClient.SendMessage(chatId, message);
        }

        public static async Task SubmitXeroxLeftover(ITelegramBotClient botClient, long chatId)
        {
            var message = $"Щоденний Звіт роботи ксероксу по залишкам за {DateTime.Now.ToString("dd.MM.yyyy")}" +
                $"\n📄 Папір: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_paper")} уп." +
                $"\n📁 Файли: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_files")} уп. " +
                $"\n📑 Папки: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_folders")} уп." +
                $"\n🍫 Батончики: {State.GetReportValue(chatId, "createnewreport_xerox_leftover_candies")} уп.";
            //clean state
            State.Reset(chatId, "createnewreport_xerox_leftover");
            await botClient.SendMessage(chatId, message);
        }
    }
}