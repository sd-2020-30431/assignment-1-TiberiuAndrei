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
        //automatically sends mail using the server "smtp.outlook.com" and port 587
        public void sendMail(string fromAddress, string fromPassword, string toAddress, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage(fromAddress, toAddress, subject, message);
            SmtpClient client = new SmtpClient("smtp.outlook.com", 587);
            client.Credentials = new NetworkCredential(fromAddress, fromPassword);
            client.EnableSsl = true;
            client.Send(mailMessage);
        }

        //create clone model of MailBot so I don not skip a layer by using database models
        //directly in views and controllers
        public BMailBot convertToBMailBot(MailBot mailBot)
        {
            return new BMailBot
            {
                Username = mailBot.Username,
                Password = mailBot.Password
            };
        }

        //returns the first mail bot in the database
        public BMailBot getBMailBot()
        {
            MailBotAccess mba = new MailBotAccess();
            return convertToBMailBot(mba.getMailBot());
        }

    }

}
