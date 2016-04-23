using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChat.Model
{
  public  class ConnectInfo:EventArgs
    {
        public string Servername;
        public int Port;
        public string NickName;
        public string Password;
        public string Channel;

        public ConnectInfo(string server,int port,string nickname,string password,string channel)
        {
            Servername = server;
            Port = port;
            NickName = nickname;
            Password = password;
            Channel = channel;
        }
    }
}
