using SharedClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace AI_ChatApp2._0_Server.Mbot.Commands
{
    class ModCommand : MCommand
    {
        private string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "BlackList.txt");

        public ModCommand(Server server, string ActivationString) : base(server, ActivationString)
        {
        }
        public override void DoCommand(Sentence sentence)
        {
            try
            {
                string[] words = sentence.getData().Split(" ");
                string command = words[1];
                switch (command)
                {
                    case "kick":
                        {
                            if (words.Length < 3)
                            {
                                throw new Exception();
                            }
                            if (sentence.Sender == words[2])
                            {
                                this.Server.SendToUser(sentence.Sender, "You can't kick yourself.");
                                break;
                            }

                            string reason = sentence.getData().Substring(words[0].Length + words[1].Length + words[2].Length + 3);

                            if (!this.Server.SendDisconnectRequest(words[2], reason))
                            {
                                this.Server.SendToUser(sentence.Sender, $"{words[2]} is not a valid username.");
                            }
                            else
                            {
                                this.Server.SendServerMessage($"{words[2]} got kicked for: {reason}");
                            }
                            break;
                        }
                    case "addBW":
                        {
                            if (words.Length > 3)
                            {
                                throw new Exception();
                            }
                            if (!File.ReadAllText(path).Contains(words[2].ToLower()))
                            {
                                File.AppendAllText(path, words[2].ToLower() + ", ");
                                this.Server.BotHandler.blackList.Add(words[2].ToLower());

                                this.Server.SendToUser(sentence.Sender, $"{words[2]} has been added to the blacklist.");
                                Console.WriteLine("Word added");
                            }
                            else
                            {
                                this.Server.SendToUser(sentence.Sender, $"{words[2]} already exists in the blacklist.");
                            }

                            break;
                        }
                    case "removeBW":
                        {
                            if (words.Length > 3)
                            {
                                throw new Exception();
                            }
                            try
                            {
                                this.Server.BotHandler.blackList = new List<string>(File.ReadAllText(path).Split(", "));

                                if (this.Server.BotHandler.blackList.Contains(words[2].ToLower()))
                                {
                                    this.Server.BotHandler.blackList.Remove(words[2].ToLower());

                                    string allWords = String.Join(", ", this.Server.BotHandler.blackList.ToArray());
                                    File.WriteAllText(path, allWords);

                                    this.Server.SendToUser(sentence.Sender, $"{words[2]} has been removed from the blacklist.");
                                    Console.WriteLine("Word deleted");
                                }
                                else
                                {
                                    this.Server.SendToUser(sentence.Sender, $"The word \"{words[2]}\" doesn't exist in the blacklist");
                                }
                            }
                            catch (Exception ex)
                            {
                                this.Server.SendToUser(sentence.Sender, $"The blacklist is empty, can't remove {words[2]}.");
                            }
                            break;
                        }
                    case "showBL":
                        {
                            if (words.Length > 2)
                            {
                                throw new Exception();
                            }
                            try
                            {
                                string blacklistedWords = File.ReadAllText(path);
                                blacklistedWords = blacklistedWords.Substring(0, blacklistedWords.Length - 2);

                                this.Server.SendToUser(sentence.Sender, $"BlackList: {blacklistedWords}\n");
                            }
                            catch (Exception ex)
                            {
                                this.Server.SendToUser(sentence.Sender, "The blacklist is empty.");
                            }
                            break;
                        }
                    default:
                        this.Server.SendToUser(sentence.Sender, $"The command \"{sentence.getData()}\" is not valid, type !help for a list of all my commands.");
                        break;
                }
            }
            catch (Exception ex)
            {
                this.Server.SendToUser(sentence.Sender, $"The command \"{sentence.getData()}\" is not valid, type !help for a list of all my commands.");
            }
        }

    }
}
