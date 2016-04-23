using MultiChat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MultiChat.ViewModel
{
 public   class ClientViewModel : INotifyPropertyChanged
    {
        public ClientViewModel()
        {
            ServerName = "irc.ircnet.ru";
            Port = 6667;
            NickName = "megadedDDD";
            Password = "11111";
            Channel = "etozhemad";
            infoConnect = new ConnectInfo(ServerName,Port,NickName,Password,Channel);
            IrcClient = new IrcConnect(infoConnect);
            ConnectCommand = new Command(ConnectToChannel);
            commands = new ClientCommand(IrcClient.IrcClient);
            IrcClient.Connecting += commands.Connect;
            IrcClient.JoiningChannel += commands.Join;
            IrcClient.ListChannel += commands.Channels;                
        }
        public void ConnectToChannel()
        {
            IrcClient.GetMessage = (mess) => Application.Current.Dispatcher.Invoke(() => Messages.Add(mess));
            IrcClient.Connect();
        }

        private void IrcClient_Join(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private ConnectInfo infoConnect;
        private ClientCommand commands;
        IrcConnect IrcClient;
        public ICommand ConnectCommand { get; set; }
        private string serverName;
        private int port;
        private string nickname;
        private string password;
        private string channel;
        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();
        public string ServerName
        {
            get { return serverName; }
            set
            {
                if (value != serverName)
                {
                    serverName = value;
                    OnPropertyChanged("ServerName");
                }
            }
        }        
        public int Port
        {
            get { return port; }
            set
            {
                if (value != port)
                {
                    port = value;
                    OnPropertyChanged("Port");
                }
            }
        }       
        public string NickName
        {
            get { return nickname; }
            set
            {
                if (value != nickname)
                {
                    nickname = value;
                    OnPropertyChanged("NickName");
                }
            }
        }        
        public string Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }        
        public string Channel
        {
            get { return channel; }
            set
            {
                if (value != channel)
                {
                    channel = value;
                    OnPropertyChanged("Channel");
                }
            }
        }       
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;     
    }
}
