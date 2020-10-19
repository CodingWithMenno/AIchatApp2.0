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
            this.Server.sendServerMessage(
                "ALL COMANDS:\r\n  " +
                "------------------------------------------------------------------------------\r\n" +
                "[WEATHER]\r\n" +
                "   !weather <city> temp = Shows the current temperature of the given city\r\n" +
                "   !weather <city> windspeed = Shows the current windspeed of the given city\r\n" +
                "   !weather <city> humidity = Shows the current humidity of the given city\r\n" +
                "   !weather <city> pressure = Shows the current pressure of the given city\r\n" +
                "\r\n[BOT2]" +
                "------------------------------------------------------------------------------\r\n"
                );

        }
    }
}
