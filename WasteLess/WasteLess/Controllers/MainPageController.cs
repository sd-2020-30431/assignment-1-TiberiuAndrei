using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Models;
using BusinessLayer.Managers;

namespace PresentationLayer.Controllers
{
    public class MainPageController : Controller
    {
        /*public IActionResult Index(IEnumerable<BFoodItem> bfood_list)
        {
            return View(bfood_list);
        }*/

        public IActionResult Index(BUsername bu)
        {
            return View(bu);
        }

        public IActionResult List(string username)
        {
            //BUsername bUsername = new BUsername(username);
            Console.WriteLine("Am ajuns la list cu username = " + username);
            ViewData["username"] = username;
            UserManager um = new UserManager();
            long id = um.getId(username);
            FoodManager fm = new FoodManager();
            IEnumerable<BFoodItem> foodItemList;
            foodItemList = fm.getFoodList(id).AsEnumerable();
            return View(foodItemList);
        }

        public IActionResult Create(string username, int overArg)
        {
            ViewData["username"] = username;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string username, BFoodItem bFoodItem)
        {
            Console.WriteLine("The username is " + username);
            ViewData["username"] = username;

            UserManager um = new UserManager();
            long id = um.getId(username);

            bFoodItem.User_id = id;
            FoodManager fm = new FoodManager();
            fm.addFoodItem(bFoodItem);

            Console.WriteLine(bFoodItem.Id + " " + bFoodItem.Name + " " + bFoodItem.Calories + " " + bFoodItem.PurchaseDate);

            //fm.insertFoodItem();
            
            IEnumerable<BFoodItem> foodItemList;
            foodItemList = fm.getFoodList(id).AsEnumerable();

            return View("~/Views/MainPage/List.cshtml", foodItemList);
            //return List(username);
            //return RedirectToAction("List", "MainPage", username);
        }

        public IActionResult Delete(string username, long bfid)
        {
            ViewData["username"] = username;

            UserManager um = new UserManager();
            long id = um.getId(username);

            FoodManager fm = new FoodManager();
            fm.removeFoodItem(bfid);

            IEnumerable<BFoodItem> foodItemList = fm.getFoodList(id);

            return View("~/Views/MainPage/List.cshtml", foodItemList);
        }

        public IActionResult Test(BFoodItem bfood_item)
        {
            ViewData["Message"] = "Varianta test merge";
            return View(bfood_item);
        }

    }
}