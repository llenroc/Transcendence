using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;

namespace TranscendenceChatServer.Core
{
    public abstract class EmailNotification
    {
        protected SendGridMessage Message { get; }

        protected EmailNotification()
        {
            Message = new SendGridMessage();
            Message.AddTo("Admin <admin@inner6.com>");
        }

        internal abstract void GenerateMessage();

        public void Send()
        {
            GenerateMessage();

            try
            {
                var credentials = new NetworkCredential("azure_9755879eb7ff84ba5fc47c2199f1d912@azure.com", "2afGwJ7BoECekX1");
                Message.From = new MailAddress("admin@inner6.com", "Inner6");
                var transportWeb = new Web(credentials);
                transportWeb.Deliver(Message);
            }
            catch (Exception ex)
            {
                //Logger.Error("Error sending email", new { Exception = ex });
            }
        }
    }
}
