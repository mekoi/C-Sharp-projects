using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301072868_meko__Lab1
{
    class SendBySms
    {
        private string mobileNumber;

        public SendBySms() { }

        public SendBySms(string mobNo)
        {
            this.mobileNumber = mobNo;
        }

        public void setMobileNumber(string mobNo)
        {
            this.mobileNumber = mobNo;
        }

        public string getMobileNumber()
        {
            return mobileNumber;
        }

        public void sendSms(string message)
        {
            Console.WriteLine("The message '" + message + "' has been sent to " + mobileNumber);
        }

        public void Subscribe(Publisher pub)
        {
            Publisher.publishmsg += sendSms;
        }

        public void Unsubscribe(Publisher pub)
        {
            Publisher.publishmsg -= sendSms;
        }

    }
}
