using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace MultiChat.Model
{
    class ClientCommand
    {
        private TcpClient Client;
        public ClientCommand(TcpClient client)
        {
            Client = client;
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
        public void Channels(object sender, ConnectInfo e)
        {
            StreamWriter writterStream = new StreamWriter(Client.GetStream());
            writterStream.WriteLine($"LIST");
            writterStream.Flush();
        }
    }
}
