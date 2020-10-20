using AI_ChatApp2._0_Server.Mbot.Commands;
using SharedClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AI_ChatApp2._0_Server.Mbot
{
    public class MBotHandler
    {
        private string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "BlackList.txt");
        private Server Server;
        private List<MCommand> commands;
        public List<string> blackList;

        public MBotHandler(Server server)
        {
            this.Server = server;
            this.blackList = new List<string>(File.ReadAllText(path).Split(", "));

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

        public bool CheckInputBL(Sentence sentence)
        {
            List<string> words = sentence.getData().Split(" ").ToList<string>();

            foreach (string word in words)
            {
                if (this.blackList.Contains(word))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
