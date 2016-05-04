using IrcClient.Model;
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

namespace IrcClient.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            ServerName = "irc.chat.twitch.tv";
            Port = 6667;
            NickName = "megaded";
            Password = "oauth:6huwmg6jwb4po4cuh33hovbb7a14aq";
            ChannelName = "";
            ConnectCommand = new Command(() =>
            {
                infoConnect = new ConnectInfo(ServerName, Port, NickName, Password);
                IrcClient = new IrcConnect(infoConnect);
                commands = new ClientCommand(IrcClient.IrcClient, ChannelsList, Channels);
                Application.Current.Dispatcher.Invoke(() => Channels.Add(new Channel("Чат")));
                IrcClient.Connecting += commands.Connect;
                IrcClient.ListChannel += commands.ChannelsList;
                IrcClient.GetMessages += commands.DecodeMessage;
                IrcClient.Connect();
               
            });
            SendMessage = new Command(() => commands.SendMessage(MessageInput, IndexChannel));
            AddChannel = new Command(() => commands.AddChannel(ChannelName));
            CloseChannel = new Command(() => commands.CloseChannel(IndexChannel));
        }
        private ConnectInfo infoConnect;
        private ClientCommand commands;
        IrcConnect IrcClient;
        public ICommand ConnectCommand { get; set; }
        public ICommand SendMessage { get; set; }
        public ICommand AddChannel { get; set; }
        public ICommand CloseChannel { get; set; }
        private string serverName;
        private int port;
        private string nickname;
        private string password;
        private string channelName;
        private string messageInput;
        private int indexChannel;
        public ObservableCollection<Channel> Channels { get; set; } = new ObservableCollection<Channel>();
        public ObservableCollection<string> ChannelsList { get; set; } = new ObservableCollection<string>();
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
        public string ChannelName
        {
            get { return channelName; }
            set
            {
                if (value != channelName)
                {
                    channelName = value;
                    OnPropertyChanged("ChannelName");
                }
            }
        }
        public string MessageInput
        {
            get { return messageInput; }
            set
            {
                if (value != messageInput)
                {
                    messageInput = value;
                    OnPropertyChanged("MessagaInput");
                }
            }
        }
        public int IndexChannel
        {
            get { return indexChannel; }
            set
            {
                if (value!= indexChannel)
                {
                    indexChannel = value;
                    OnPropertyChanged("IndexChannel");
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
