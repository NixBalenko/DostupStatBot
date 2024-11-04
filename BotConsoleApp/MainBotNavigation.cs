using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotConsoleApp
{
    public static class MainBotNavigation {
        public static async Task ProcessCommands(ITelegramBotClient botClient, long chatId, string? messageText)
        {
            switch (messageText.ToLower())
            {
                case "/xeroxleftover":
                    State.CurrentCommand = CommandEnum.XeroxLeftover;
                    await XeroxReport.CreateNewReportXeroxLeftover(botClient, chatId);
                    break;
                case "/xeroxtaken":
                    State.CurrentCommand = CommandEnum.XeroxTaken;
                    await XeroxReport.CreateNewReportXeroxTaken(botClient, chatId);
                    break;
                case "/cafeeleftover":
                    State.CurrentCommand = CommandEnum.CafeeLeftover;
                    await botClient.SendMessage(chatId, "In development");
                    break;
                case "/help":
                    await botClient.SendMessage(chatId, "Available commands:" +
                        "\n/xeroxleftover - Xerox Leftover daily report" +
                        "\n/xeroxtaken - Xerox taken optional report" +
                        "\n/cafeeleftover - Cafee Leftover daily report" +
                        "\n /help - List commands" +
                        "\n/exit Exit");
                    break;
                case "/exit":
                    await botClient.SendMessage(chatId, "Bye! Bye!");
                    break;

                case "/echo":
                    await botClient.SendMessage(chatId, "Welcome to the bot! Type /help to see available commands.");
                    break;

                default:
                    break;
            }
        }

        public static async Task  ShowReportScreen(ITelegramBotClient botClient, long chatId) {
            var state = State.CurrentCommand;
            switch (state)
            {
               case CommandEnum.XeroxLeftover:
                    await XeroxReport.CreateNewReportXeroxLeftover(botClient, chatId);
                    break;

                case CommandEnum.XeroxTaken:
                    await XeroxReport.CreateNewReportXeroxTaken(botClient, chatId);
                    break;
                default:
                    break;
            }
        }

        public static async Task ProccessCallbackUpdate(ITelegramBotClient botClient, Update update)
        {
            var callbackQuery = update.CallbackQuery;
            var chatId = callbackQuery.Message.Chat.Id;

            switch (callbackQuery.Data)
            {
                case "createnewreport_xerox_taken_paper":
                    await State.RequestReportValue(botClient, chatId, "createnewreport_xerox_taken_paper");
                    break;
                case "createnewreport_xerox_taken_files":
                    await State.RequestReportValue(botClient, chatId, "createnewreport_xerox_taken_files");
                    break;
                case "createnewreport_xerox_taken_folders":
                    await State.RequestReportValue(botClient, chatId, "createnewreport_xerox_taken_folders");
                    break;
                case "createnewreport_xerox_taken_candies":
                    await State.RequestReportValue(botClient, chatId, "createnewreport_xerox_taken_candies");
                    break;
                case "createnewreport_xerox_leftover_paper":
                    await State.RequestReportValue(botClient, chatId, "createnewreport_xerox_leftover_paper");
                    break;
                case "createnewreport_xerox_leftover_files":
                    await State.RequestReportValue(botClient, chatId, "createnewreport_xerox_leftover_files");
                    break;
                case "createnewreport_xerox_leftover_folders":
                    await State.RequestReportValue(botClient, chatId, "createnewreport_xerox_leftover_folders");
                    break;
                case "createnewreport_xerox_leftover_candies":
                    await State.RequestReportValue(botClient, chatId, "createnewreport_xerox_leftover_candies");
                    break;
                case "createnewreport_cafee":
                    await botClient.SendMessage(chatId, "You selected 'Cafee' for your report.");
                    break;
                default:
                    await botClient.SendMessage(chatId, $"Sorry, i'm not ready to process {callbackQuery.Data} yet.");
                    break;
            }

            // Optionally, answer the callback query to remove the "loading" indicator
            await botClient.AnswerCallbackQuery(callbackQuery.Id, "Selection received.");
        }
    }
}