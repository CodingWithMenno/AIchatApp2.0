using Newtonsoft.Json;
using SharedClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AI_ChatApp2._0_Server.Mbot.Commands
{
    class WeatherCommand : MCommand
    {
        private readonly string APIKEY = "7b1198570c69d548131bb8b6e07024c1";

        public WeatherCommand(string ActivationString) : base(ActivationString)
        {

        }

        public override void DoCommand(Sentence sentence)
        {
            string city = sentence.getData().Substring(this.GetActivation().Length + 1);
            string workingCity = city.Substring(0, 1).ToUpper() + city.Substring(1).ToLower();
            Console.WriteLine(APIHandler.Get("http://api.openweathermap.org/data/2.5/weather?q=" + city + ",nl&APPID=" + this.APIKEY));
        }
    }
}
