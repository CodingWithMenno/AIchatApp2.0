using SharedClass;

namespace AI_ChatApp2._0_Server.Mbot.Commands
{
    class HelpCommand : MCommand
    {
        public HelpCommand(Server server, string ActivationString) : base(server, ActivationString)
        {

        }

        public override void DoCommand(Sentence sentence)
        {
            this.Server.SendToUser(sentence.Sender,
                "ALL COMMANDS:\r\n  " +
                "------------------------------------------------------------------------------\r\n" +
                "[WEATHER]\r\n" +
                "   !weather <city> temp = Shows the current temperature of the given city\r\n" +
                "   !weather <city> windspeed = Shows the current windspeed of the given city\r\n" +
                "   !weather <city> humidity = Shows the current humidity of the given city\r\n" +
                "   !weather <city> pressure = Shows the current pressure of the given city\r\n" +
                "\r\n[MOD]\r\n" +
                "   !mod kick <username> <reason> = Kicks the user\r\n" +
                "   !mod showBL = Shows all the words on the blacklist\r\n" +
                "   !mod addBW = Adds a word to the blacklist\r\n" +
                "   !mod removeBW = Removes a word from the blacklist\r\n" +
                "------------------------------------------------------------------------------\r\n"
                );

        }
    }
}
