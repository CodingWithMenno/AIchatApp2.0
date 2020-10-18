using AI_ChatApp2._0_Server.Mbot.Commands;
using SharedClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_ChatApp2._0_Server.Mbot
{
    class MBotHandler
    {
        private Server Server;
        private List<MCommand> commands;

        public MBotHandler()
        {
            //this.Server = server;
            setCommands();
        }

        private void setCommands()
        {
            this.commands = new List<MCommand>();

            this.commands.Add(new WeatherCommand("weather"));
        }

        public void HandleMessage(Sentence sentence)
        {
            string message = sentence.getData();

            foreach (MCommand command in this.commands)
            {
                if (message.StartsWith(command.GetActivation()))
                {
                    command.DoCommand(sentence);
                }
            }
        }
    }
}
