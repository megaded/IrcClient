using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrcClient.Model
{
  public  class ConnectInfo:EventArgs
    {
        public string Servername;
        public int Port;
        public string NickName;
        public string Password;
        public ConnectInfo(string server,int port,string nickname,string password)
        {
            Servername = server;
            Port = port;
            NickName = nickname;
            Password = password;

        }
    }
}
