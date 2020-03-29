using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using BusinessLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Functions;

namespace BusinessLayer.Managers
{
    public class MailManager
    {
        public void sendMail(string fromAddress, string fromPassword, string toAddress, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage(fromAddress, toAddress, subject, message);
            SmtpClient client = new SmtpClient("smtp.outlook.com", 587);
            client.Credentials = new NetworkCredential(fromAddress, fromPassword);
            client.EnableSsl = true;
            client.Send(mailMessage);
        }

        public BMailBot convertToBMailBot(MailBot mailBot)
        {
            return new BMailBot
            {
                Username = mailBot.Username,
                Password = mailBot.Password
            };
        }

        public BMailBot getBMailBot()
        {
            MailBotAccess mba = new MailBotAccess();
            return convertToBMailBot(mba.getMailBot());
        }

    }

}
