using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using AI_ChatApp2._0_Server;
using AI_ChatApp2._0_Server.Mbot;
using SharedClass;

namespace AI_ChatApp2._0_Test
{
    [TestClass()]
    public class BotTester
    {

        [TestMethod]
        public void TestInsertAndRemoveBW()
        {
            File.WriteAllText("BlackList.txt", "");

            MBotHandler botHandler = new MBotHandler(new Server());
        }
    }
}
