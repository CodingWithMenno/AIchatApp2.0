using AI_ChatApp2._0_Server.Mbot.Commands;
using SharedClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AI_ChatApp2._0_Server.Mbot
{
    class MBotHandler
    {
        private Server Server;
        private List<MCommand> commands;

        public MBotHandler(Server server)
        {
            this.Server = server;
            setCommands();
        }

        private void setCommands()
        {
            this.commands = new List<MCommand>();

            this.commands.Add(new WeatherCommand(this.Server,"weather"));
            this.commands.Add(new HelpCommand(this.Server,"help"));
            this.commands.Add(new ModCommand(this.Server, "mod"));
        }

        private void HandleMessageAsync(Sentence sentence)
        {
            string message = sentence.getData().Substring(1);
            foreach (MCommand command in this.commands)
            {
                if (message.StartsWith(command.GetActivation()))
                {
                    command.DoCommand(sentence);
                    return;
                }
            }

            this.Server.SendToUser(sentence.Sender, $"The command \"{sentence.getData()}\" is not valid, type !help for a list of all my commands.");
        }

        public void HandleMessage(Sentence sentence)
        {
            Thread messageThread = new Thread(() =>
            {
                HandleMessageAsync(sentence);
            });

            messageThread.Start();
        }
    }
}
