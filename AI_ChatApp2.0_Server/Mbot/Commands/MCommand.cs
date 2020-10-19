using SharedClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_ChatApp2._0_Server.Mbot.Commands
{
    class MCommand
    {

        protected Server Server;
        protected string ActivationCommand;

        public MCommand(Server server, string ActivationString)
        {
            this.Server = server;
            this.ActivationCommand = ActivationString;
        }

        public virtual void DoCommand(Sentence sentence)
        {
            Console.WriteLine("No message implemented");
        }

        public string GetActivation()
        {
            return this.ActivationCommand;
        }

    }
}
