using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Models;
using BusinessLayer.Managers;
using BusinessLayer.Managers.Reports;

namespace PresentationLayer.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index(BUsername bu)
        {
            return View(bu);
        }

        public IActionResult List(string username)
        {
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
            int cod = fm.addFoodItem(bFoodItem);
            if (cod == 0) { ViewData["message"] = ""; }
            else { ViewData["message"] = "Food Item not added: "; }
            if (cod == 1) { ViewData["message"] += "Invalid Purchase Date"; }
            if (cod == 2) { ViewData["message"] += "Invalid Expiration Date"; }
            if (cod == 3) { ViewData["message"] += "Invalid Consumption Date"; }
            if (cod == 4) { ViewData["message"] += "Name can contain olny english letters"; }
            if (cod == 5) { ViewData["message"] += "Can not enter nagative quantities"; }
            if (cod == 6) { ViewData["message"] += "Maximum quantity exceded"; }
            if (cod == 7) { ViewData["message"] += "Can not enter nagative calories"; }
            if (cod == 8) { ViewData["message"] += "Maximum calories exceded"; }
            if (cod == 9) { ViewData["message"] += "Consumption date can not be in the future"; }
            if (cod == 10) { ViewData["message"] += "Purchase date can not be in the future"; }
            if (cod == 11) { ViewData["message"] = ""; }

            IEnumerable<BFoodItem> foodItemList;
            foodItemList = fm.getFoodList(id).AsEnumerable();

            return View("~/Views/MainPage/List.cshtml", foodItemList);

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

        public IActionResult Reports(string username)
        {
            ViewData["username"] = username;
            UserManager um = new UserManager();
            long id = um.getId(username);

            AbstractReportFactory rf = new ConcreteReportFactory();
            FullReport fr = new FullReport(rf.createWeeklyReport(id), rf.createMonthlyReport(id));
            return View(fr);

        }

        public IActionResult AddConsDate(string username, long bfid)
        {
            ViewData["username"] = username;
            ViewData["bfid"] = bfid;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddConsDate(string username, long bfid, BConsDate bConsDate)
        {
            Console.WriteLine(bConsDate.ConsDate);

            ViewData["username"] = username;

            UserManager um = new UserManager();
            long id = um.getId(username);

            FoodManager fm = new FoodManager();
            int cod = fm.editConsDate(bfid, bConsDate.ConsDate);
            if (cod == 0) { ViewData["message"] = ""; }
            else { ViewData["message"] = "Update failed: "; }
            if (cod == 1) { ViewData["message"] += "Consumption date can not be in the future"; }

            IEnumerable<BFoodItem> foodItemList = fm.getFoodList(id);

            return View("~/Views/MainPage/List.cshtml", foodItemList);
        }

        public IActionResult Donate(string username)
        {
            ViewData["username"] = username;

            CharOrgManager com = new CharOrgManager();
            List<BCharOrg> bCharOrgList = com.getBCharOrgList();

            return View(bCharOrgList);

        }

    }

}