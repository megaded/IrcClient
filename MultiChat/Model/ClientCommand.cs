using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Collections.ObjectModel;
using System.Windows;

namespace MultiChat.Model
{
    class ClientCommand
    {
        private TcpClient Client;
        private ObservableCollection<string> _messages;
        private ObservableCollection<string> _channels;
        public ClientCommand(TcpClient client, ObservableCollection<string> messages, ObservableCollection<string> channels)
        {
            Client = client;
            _messages = messages;
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
            writterStream.WriteLine("USER guest 0 * :Ronnie Reagan");
            writterStream.Flush();
            writterStream.WriteLine($"NICK {e.NickName}");
            writterStream.Flush();
            writterStream.WriteLine($"MOTD");
            writterStream.Flush();
        }
        public void Join(object sender, ConnectInfo e)
        {
            StreamWriter writterStream = new StreamWriter(Client.GetStream());
            writterStream.WriteLine($"JOIN #{e.Channel}");
            writterStream.Flush();
        }
        public void ChannelsList(object sender, ConnectInfo e)
        {
            StreamWriter writterStream = new StreamWriter(Client.GetStream());
            writterStream.WriteLine($"LIST");
            writterStream.Flush();
        }
        public void DecodeMessage(object sender, ConnectInfo e)
        {
            var IrcClient = (IrcConnect)sender;
            var message = IrcClient.Message;
            if (message.StartsWith(":"))
            {
                if (message.Contains("PRIVMSG"))
                {
                    var indexx = message.IndexOf("!");
                    var nick = message.Substring(1, indexx - 1);
                    var channel = e.Channel;
                    indexx = message.IndexOf(channel);
                    message = message.Remove(0, indexx + channel.Length + 2);
                    Application.Current.Dispatcher.Invoke(() => _messages.Add(nick+":"+message));
                }
                var index = message.IndexOf(" ");
                var code = message.Substring(index + 1, 3);
                if (code == "322")
                {
                    var channel = message;
                    index = channel.IndexOf("#");
                    channel = channel.Remove(0, index);
                    index = channel.IndexOf(" ");
                    channel = channel.Substring(0, index);
                    Application.Current.Dispatcher.Invoke(() => _channels.Add(channel));
                }
                else
                {
                    index = message.IndexOf(e.NickName);
                    if (index > 0)
                    {
                        var mes = message.Remove(0, index + e.NickName.Length);
                        Application.Current.Dispatcher.Invoke(() => _messages.Add(message));
                    }
                }
            }
        }
    }
}
