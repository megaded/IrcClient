using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;

namespace MultiChat.Model
{
    public class IrcConnect
    {
        public TcpClient IrcClient;
        private ConnectInfo _connectInfo;
        private NetworkStream _stream;
        private StreamWriter _writter;
        private StreamReader _reader;
        public Action<string> GetMessage;
        public IrcConnect(ConnectInfo connectInfo)
        {
            _connectInfo = connectInfo;
            IrcClient = new TcpClient(_connectInfo.Servername, _connectInfo.Port);
        }
        public  void Connect()
        {            
            using (_stream = IrcClient.GetStream())
            {
                Connecting(this, _connectInfo);
                ListChannel(null, null);
                using (_reader = new StreamReader(_stream))
                {
                    while(IrcClient.Connected)
                    {
                        GetMessage(_reader.ReadLine());                      
                    }
                }
            }
        }
        public void Send(string message)
        {

        }
        public event EventHandler<ConnectInfo> Connecting;
        public event EventHandler<ConnectInfo> JoiningChannel;
        public event EventHandler<ConnectInfo> ListChannel;           
    }
}
