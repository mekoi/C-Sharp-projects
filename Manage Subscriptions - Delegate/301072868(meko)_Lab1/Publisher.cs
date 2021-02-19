using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301072868_meko__Lab1
{
    class Publisher
    {

        public static bool Subscribed { get; set; }

        public delegate void PublishtMessageDel(string msg);

        public static PublishtMessageDel publishmsg = null;

        public void PublishMessage(string message)
        {
            publishmsg.Invoke(message);
        
        }
    }
}
