using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BotConsoleApp
{
    public enum CommandEnum {
        None = 0,
        XeroxTaken = 1,
        XeroxLeftover = 2,
        CafeeLeftover = 3,
    }
    public static class State {

        private static readonly Dictionary<long, Dictionary<string, int>> UserStates = new();
        private static readonly Dictionary<long, string> UserCommands = new();
        public static CommandEnum? CurrentCommand { get; set; } = null;

        public static int GetReportValue(long chatId, string command)
        {
            if (!UserStates.ContainsKey(chatId))
            {
                return 0;
            }
            if (!UserStates[chatId].ContainsKey(command))
            {
                return 0;
            }
            return UserStates[chatId][command];
        }

        public static async Task RequestReportValue(ITelegramBotClient botClient, long chatId, string command)
        {
            if (!UserCommands.ContainsKey(chatId))
            {
                UserCommands[chatId] = command;
            }
            await botClient.SendTextMessageAsync(chatId, "Please enter the number:");
        }

        public static async Task<bool> TryToStoreReportValue(ITelegramBotClient botClient, long chatId, string messageText)
        {
            try
            {
                if (int.TryParse(messageText, out var number))
                {
                    if (!UserCommands.ContainsKey(chatId))
                    {
                        return false;
                    }
                    var currentCommand = UserCommands[chatId];
                    if (currentCommand != null)
                    {
                        if (!UserStates.ContainsKey(chatId))
                        {
                            UserStates[chatId] = new Dictionary<string, int>();
                        }
                        UserStates[chatId][currentCommand] = number;
                        UserCommands.Remove(chatId);
                        return true;
                    }

                    await botClient.SendTextMessageAsync(chatId, $"Invalid command");
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}