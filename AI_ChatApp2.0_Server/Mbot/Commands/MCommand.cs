using SharedClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_ChatApp2._0_Server.Mbot.Commands
{
    class MCommand
    {
        private string ActivationCommand;

        public MCommand(string ActivationString)
        {
            this.ActivationCommand = ActivationString;
        }

        public virtual void DoCommand(Sentence sentence)
        {
            // Handle your command
        }

        public string GetActivation()
        {
            return this.ActivationCommand;
        }

    }
}
