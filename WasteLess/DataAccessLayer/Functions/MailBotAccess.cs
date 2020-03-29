using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer.Functions
{
    public class MailBotAccess
    {
        public MailBot getMailBot()
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                MailBot mailBot = _dcm.MailBots.First();
                return mailBot;
            }
        }

    }
}
