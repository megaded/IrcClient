using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChat.Model
{
  public  class ChatMessage
    {
        public ChatMessage(string nickname,string message)
        {
            _nickname = nickname;
            _message = message;
            _time = DateTime.Now;
        }
        private string _nickname;
        private string _message;
        private DateTime _time;
        public string NickName
        {
            get { return _nickname; }
        }
        public string Message
        {
            get { return _message; }
        }
        public string Time
        {
            get { return _time.ToShortTimeString(); }
        }
    }
}
