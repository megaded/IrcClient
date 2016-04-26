using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChat.Model
{
    public class MessageDecode
    {
        public static string Decode(string message, string nickname)
        {
            if (message.StartsWith(":"))
            {
                var index = message.IndexOf(" ");
                var code = message.Substring(index + 1, 3);
                if (code == "322")
                {
                    var tempString = message;
                    index = tempString.IndexOf("#");
                    tempString = tempString.Remove(0, index);
                    index = tempString.IndexOf(" ");
                    tempString = tempString.Substring(0, index);
                    return tempString;
                }
                else
                {
                    index = message.IndexOf(nickname);
                    var mes = message.Remove(0, index + nickname.Length);
                    return mes;
                }
            }
           else return String.Empty;
        }
    }
}
