using Microsoft.VisualStudio.TestTools.UnitTesting;
using AI_ChatApp2._0_Server;
using System.IO;
using System.Threading;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTests
{
    [TestClass]
    public class BotTest
    {
        private string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "BlackList.txt");
        private readonly string APIKEY = "7b1198570c69d548131bb8b6e07024c1";


        [TestMethod]
        public void TestAPI()
        {
            string result = APIHandler.Get("http://api.openweathermap.org/data/2.5/weather?q=" + "Dordrecht" + ",nl&APPID=" + this.APIKEY);
            dynamic data_ = JsonConvert.DeserializeObject(result);
            string city = data_.name;
            int timezone = data_.timezone;

            Assert.AreEqual("Dordrecht", city);
            Assert.AreEqual(7200,timezone);
        }

        [TestMethod]
        public void TestInputForBW()
        {
            File.WriteAllText(this.path, "testen, ");
            Server s = new Server();

            bool result = s.BotHandler.CheckInputBL(new SharedClass.Sentence()
            {
                Sender = "TEST",
                Data = "testen",
                MessageType = SharedClass.Sentence.Type.BOT_REQUEST
            });

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestAddBW()
        {
            File.WriteAllText(this.path, "");

            Server s = new Server();

            var wait = Task.Factory.StartNew(() =>
            {
                addBW(s);
            });

            Task.WaitAll(wait);

            string result = File.ReadAllText(this.path);
            Console.WriteLine(result);

            Assert.AreEqual("testword, ", result);
        }

        [TestMethod]
        public void TestRemoveBW()
        {
            File.WriteAllText(this.path, "test, ");

            Server s = new Server();

            var wait = Task.Factory.StartNew(() =>
            {
                removeBW(s);
            });

            Task.WaitAll(wait);

            string result = File.ReadAllText(this.path);
            Console.WriteLine(result);

            Assert.AreEqual("", result);
        }

        private void removeBW(Server s)
        {
            s.BotHandler.HandleMessage(new SharedClass.Sentence()
            {
                Sender = "TEST",
                Data = "!mod removeBW test",
                MessageType = SharedClass.Sentence.Type.BOT_REQUEST
            });

            Thread.Sleep(2000);
        }

        private void addBW(Server s)
        {
            s.BotHandler.HandleMessage(new SharedClass.Sentence()
            {
                Sender = "TEST",
                Data = "!mod addBW testWord",
                MessageType = SharedClass.Sentence.Type.BOT_REQUEST
            });

            Thread.Sleep(2000);
        }
    }
}
