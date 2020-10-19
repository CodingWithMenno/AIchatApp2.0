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

        public WeatherCommand(Server server, string ActivationString) : base(server, ActivationString)
        {

        }

        public override void DoCommand(Sentence sentence)
        {
            string[] words = sentence.getData().Split(" ");
            string city = words[1];
            string command = words[2];
            string workingCity = city.Substring(0, 1).ToUpper() + city.Substring(1).ToLower();
            string data = APIHandler.Get("http://api.openweathermap.org/data/2.5/weather?q=" + city + ",nl&APPID=" + this.APIKEY);
            dynamic data_ = JsonConvert.DeserializeObject(data);
            switch (command)
            {
                case "temp":
                    {
                        this.Server.sendServerMessage($"The temperature in {workingCity} is currently {Math.Round((double)(data_.main.temp - 273.15), 2)} Celcius.");
                        break;
                    }
                case "pressure":
                    {
                        this.Server.sendServerMessage($"The pressure in {workingCity} is currently {data_.main.pressure} hPa.");
                        break;
                    }
                case "humidity":
                    {
                        this.Server.sendServerMessage($"The humidity in {workingCity} is currently {data_.main.humidity} %.");
                        break;
                    }
                case "windspeed":
                    {
                        this.Server.sendServerMessage($"The windspeed in {workingCity} is currently {data_.wind.speed} m/s.");
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
