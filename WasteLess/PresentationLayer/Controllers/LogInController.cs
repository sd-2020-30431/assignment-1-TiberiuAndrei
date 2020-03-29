using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Models;
using BusinessLayer.Managers;

namespace PresentationLayer.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //validates authenticcation
        //also automatically sends email reminder to user when he logs in, only if at least one day has passed sience he has logged in last
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BUser buser)
        {
            UserManager um = new UserManager();
            if (um.validate_user(buser))
            {
                string umail = um.getMail(buser.Username);
                MailManager mailManager = new MailManager();

                BMailBot bMailBot = mailManager.getBMailBot();

                if(DateTime.Now > um.getLastSent(buser.Username).AddDays(1))
                {
                    NotificationManager cm = new NotificationManager();
                    string message = cm.generateMessage(um.getId(buser.Username));
                    mailManager.sendMail(bMailBot.Username, bMailBot.Password, umail, "Report", message);
                    um.updateLastSent(um.getId(buser.Username));
                }

                BUsername u = new BUsername(buser.Username);
                return RedirectToAction("Index", "MainPage", u);
            }
            ViewData["message"] = "Invalid Username or Password";
            return View();
        }

    }

}