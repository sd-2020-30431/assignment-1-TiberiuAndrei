using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;

namespace BusinessLayer.Managers
{
    public class NotificationManager
    {
        public string generateMessage(long uid)
        {
            FoodManager fm = new FoodManager();
            List<BFoodItem> foodItemList = fm.getFoodListExp(uid, DateTime.Now, DateTime.Now.AddDays(6));
            int quantity = 0;
            int calories = 0;
            int[] ideal = new int[8];
            for(int i = 0; i < 8; i++)
            {
                ideal[i] = 0;
            }
            foreach (BFoodItem bFoodItem in foodItemList)
            {
                quantity += bFoodItem.Quantity;
                calories += bFoodItem.Quantity * bFoodItem.Calories;
                int days = ((int)(bFoodItem.ExpDate - DateTime.Now).TotalDays + 1);
                Console.WriteLine("days: " + days);
                //Console.WriteLine("days: " + days);
                for(int i = 1; i <= days; i++)
                {
                    ideal[i] += (calories / days);
                }
            }

            string message = "";
            message += "Reminder\nYou have " + quantity + " items that are about to expire this week, ";
            message += "having a total of " + calories + " calories\n";
            message += "The ideal burndown rate for the following days are:\n";
            message += "Today: " + ideal[1] +"\n";
            message += "Tommorow: " + ideal[2] + "\n";

            for (int i = 3; i <= 7; i++)
            {
                message += "After " + i + " days: " + ideal[i] + "\n";
            }

            message += "These items that are about to expire this week are: \n";

            foreach (BFoodItem bFoodItem in foodItemList)
            {
                message += "Name: " + bFoodItem.Name + " Quantity: " + bFoodItem.Quantity + "\n";
            }

            return message;

        }

    }

}
