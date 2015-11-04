using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Mail;
using CommonTypes;
using System.Net;

namespace RssNewsletterService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class NewsletterService : INewsletterService
    {
        private SmtpClient smtpClient;

        private string password;
        private string senderAddress;
        private string smtpAddress = "smtp.gmail.com";
        private int smtpPort = 587;

        public NewsletterService()
        {
            this.senderAddress = @"abc@abc.com";
            this.password = @"qwerty";

            smtpClient = new SmtpClient(smtpAddress, smtpPort);
            smtpClient.Credentials = new NetworkCredential(senderAddress, password);
            smtpClient.EnableSsl = true;
        }

        public void SendNewsItem(FeedItem item, string[] addresses)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));
            if (addresses.Length < 1)
                return;

            var message = new MailMessage();
            message.From = new MailAddress(senderAddress);
            foreach (var address in addresses)
            {
                message.To.Add(new MailAddress(address));
            }
            message.Subject = item.Title;
            message.Body = item.Summary;
            message.IsBodyHtml = true;

            smtpClient.Send(message);
        }

        public void SendNewsItems(FeedItem[] items, string[] addresses)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                SendNewsItem(item, addresses);
        }
    }
}

