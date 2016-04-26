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

namespace IrcClient.Model
{
    public class IrcConnect
    {
        public TcpClient IrcClient;
        private ConnectInfo _connectInfo;
        private NetworkStream _stream;
        private StreamReader _reader;
        public  string Message;
        public IrcConnect(ConnectInfo connectInfo)
        {
            _connectInfo = connectInfo;
            IrcClient = new TcpClient(_connectInfo.Servername, _connectInfo.Port);
        }
        public void Connect()
        {
            using (_stream = IrcClient.GetStream())
            {
                Connecting(this, _connectInfo);
                ListChannel(null, null);
                using (_reader = new StreamReader(_stream))
                {
                    while (IrcClient.Connected)
                    {
                        Message = _reader.ReadLine();
                        if (Message != null)
                        {
                            GetMessages(this, _connectInfo);
                        }                       
                    }
                }
            }
        }
        public event EventHandler<ConnectInfo> Connecting;
        public event EventHandler<ConnectInfo> ListChannel;
        public event EventHandler<ConnectInfo> GetMessages;
    }
}
