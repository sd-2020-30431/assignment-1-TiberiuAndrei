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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BUser buser)
        {
            UserManager um = new UserManager();
            if (um.validate_user(buser))
            {
                BUsername u = new BUsername(buser.Username);
                return RedirectToAction("Index", "MainPage", u);
            }
            ViewData["message"] = "Invalid Username or Password";
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BUser buser)
        {
            UserManager um = new UserManager();
            if (um.validate_user(buser))
            {
                FoodManager fm = new FoodManager();
                long uid = um.get_id(buser);
                List<BFoodItem> bfood_list = fm.get_food_list(uid);
                BFoodItem bfood_item = new BFoodItem
                {
                    Id = 1,
                    Name = "mar",
                    Quantity = 1,
                    Calories = 1,
                    PurchaseDate = new DateTime(2020-01-01),
                    ExpDate = new DateTime(2020-01-01),
                    ConsDate = new DateTime(2020-01-01),
                    User_id = 1
                };
                return RedirectToAction("Index", "MainPage", bfood_item);
                //"{controller=LogIn}/{action=Index}/{id?}"
                //MainPageController mpc = new MainPageController();
                //return mpc.Index(bfood_list);
                //return View("~/Views/MainPage/Index.cshtml", bfood_list);
            }
            ViewData["message"] = "Invalid Username or Password";
            return View();
        }*/

    }
}