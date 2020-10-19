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
                    case "saveChat":
                        {
                            if (words.Length > 2)
                            {
                                throw new Exception();
                            }
                            break;
                        }
                    case "loadChat":
                        {
                            if (words.Length > 3)
                            {
                                throw new Exception();
                            }
                            break;
                        }
                    case "addBW":
                        {
                            if (words.Length > 3)
                            {
                                throw new Exception();
                            }
                            if (!File.ReadAllText("BlackList.txt").Contains(words[2].ToLower()))
                            {
                                File.AppendAllText("BlackList.txt", words[2].ToLower() + ", ");
                                this.Server.SendToUser(sentence.Sender, $"{words[2]} has been added to the blacklist.");
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
                                string[] blackList = File.ReadAllText("BlackList.txt").Split(", ");
                                List<string> bl = blackList.ToList<string>();

                                if (bl.Contains(words[2].ToLower()))
                                {
                                    bl.Remove(words[2].ToLower());

                                    string allWords = String.Join(", ", bl.ToArray());
                                    File.WriteAllText("BlackList.txt", allWords);

                                    this.Server.SendToUser(sentence.Sender, $"{words[2]} has been removed from the blacklist.");
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
                                string blacklistedWords = File.ReadAllText("BlackList.txt");
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
