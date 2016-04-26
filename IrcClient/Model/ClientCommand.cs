using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Collections.ObjectModel;
using System.Windows;

namespace IrcClient.Model
{
    class ClientCommand
    {
        private TcpClient Client;
        private ObservableCollection<string> _listChannels;
        private ObservableCollection<Channel> _channels;
        public ClientCommand(TcpClient client,  ObservableCollection<string> listChannels, ObservableCollection<Channel> channels)
        {
            Client = client;
            _listChannels = listChannels;
            _channels = channels;
        }
        public void Connect(object sender, ConnectInfo e)
        {
            StreamWriter writterStream = new StreamWriter(Client.GetStream());
            if (e.Password != null)
            {
                writterStream.WriteLine($"PASS {e.Password}");
                writterStream.Flush();
            }
            writterStream.WriteLine($"USER {e.NickName} 0 * :{e.NickName}");
            writterStream.Flush();
            writterStream.WriteLine($"NICK {e.NickName}");
            writterStream.Flush();
            writterStream.WriteLine($"MOTD");
            writterStream.Flush();
        }
        public void AddChannel(string channelName) 
        {
           Application.Current.Dispatcher.Invoke(()=> _channels.Add(new Channel(channelName)));
            StreamWriter writterStream = new StreamWriter(Client.GetStream());
            writterStream.WriteLine($"JOIN {channelName}");
            writterStream.Flush();
        }
        public void SendMessage (string message,string channel)
        {
            StreamWriter writterStream = new StreamWriter(Client.GetStream());
            writterStream.WriteLine($"PRIVMSG {channel} :{message}");
            writterStream.Flush();
        }
        public void ChannelsList(object sender, ConnectInfo e)
        {
            StreamWriter writterStream = new StreamWriter(Client.GetStream());
            writterStream.WriteLine($"LIST");
            writterStream.Flush();
        }
        // Продумать способ получше.
        public void DecodeMessage(object sender, ConnectInfo e)
        {
            var IrcClient = (IrcConnect)sender;
            var message = IrcClient.Message;
            if (message.StartsWith(":"))
            {
                if (message.Contains("PRIVMSG"))
                {
                    var indexx = message.IndexOf("!");
                    if (indexx > 0)
                    {
                        var nick = message.Substring(1, indexx - 1);
                        indexx = message.IndexOf("#");
                        message = message.Remove(0, indexx);
                        indexx = message.IndexOf(":");
                        var channelname = "";
                        foreach (var channel in _channels)
                        {
                            if (message.Contains(channel.Name))
                            {
                                channelname = channel.Name;
                                break;
                            }
                        }
                        var targetChannel = _channels.Where(channel => channel.Name == channelname).First();
                        var indexTargetChannel = _channels.IndexOf(targetChannel);                
                        message = message.Substring(indexx + 1, (message.Length - indexx) - 1);
                        Application.Current.Dispatcher.Invoke(
                            () => _channels[indexTargetChannel].Messages.Add(new ChatMessage(nick,message)));
                    }
                }
                else
                {
                    var index = message.IndexOf(" ");
                    var code = message.Substring(index + 1, 3);
                    // 322 код вывода каналов LIST
                    if (code == "322")
                    {
                        var channel = message;
                        index = channel.IndexOf("#");
                        channel = channel.Remove(0, index);
                        index = channel.IndexOf(" ");
                        channel = channel.Substring(0, index);
                        Application.Current.Dispatcher.Invoke(() => _listChannels.Add(channel));
                    }
                    else
                    {
                        index = message.IndexOf(e.NickName);
                        if (index > 0)
                        {
                            var mes = message.Remove(0, index + e.NickName.Length);
                          Application.Current.Dispatcher.Invoke(() => _channels[0].Messages.Add(new ChatMessage(string.Empty, message)));
                        }
                    }
                }
            }
        }
    }
}
