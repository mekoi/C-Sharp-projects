using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301072868_meko__Lab1
{
    class SendByEmail
    {
        public string emailAddress;

        public SendByEmail() { }

        public SendByEmail(string emailAddr) 
        {
            this.emailAddress = emailAddr;
        }

        public void setEmailAddress(string emailAddr)
        {
            this.emailAddress = emailAddr;
        }

        public string getEmailAddress()
        {
            return emailAddress;
        }

        public void sendEmail (string message)
        {
            Console.WriteLine("The message '" + message + "' has been sent to " + emailAddress);
        }

        public void Subscribe(Publisher pub)
        {
            Publisher.publishmsg += sendEmail;
        }

        public void Unsubscribe(Publisher pub)
        {
            Publisher.publishmsg -= sendEmail;
        }
    }
}
