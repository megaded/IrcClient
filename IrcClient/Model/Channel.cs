using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace IrcClient.Model
{
    public class Channel
    {
        public string Name { get; set; }
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();
        public Channel(string name)
        {
            Name = name;
        }
    }
}
