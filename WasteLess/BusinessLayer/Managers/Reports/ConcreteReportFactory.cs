using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;

namespace BusinessLayer.Managers.Reports
{
    public class ConcreteReportFactory : AbstractReportFactory
    {
        public override MonthlyReport createMonthlyReport(long uid)
        {
            DateTime nowDate = DateTime.Now;
            FoodManager foodManager = new FoodManager();
            List<BFoodItem> foodItemList = foodManager.getFoodListExp(uid, nowDate.AddDays(-30), nowDate.AddDays(-1));

            int quantity = 0;
            int calories = 0;

            foreach (BFoodItem bFoodItem in foodItemList)
            {
                if (bFoodItem.ConsDate.Equals(null))
                {
                    quantity += bFoodItem.Quantity;
                    calories += bFoodItem.Quantity * bFoodItem.Calories;
                }
            }

            return new MonthlyReport(quantity, calories, foodItemList);
        }

        public override WeeklyReport createWeeklyReport(long uid)
        {
            DateTime nowDate = DateTime.Now;
            FoodManager foodManager = new FoodManager();
            List<BFoodItem> foodItemList = foodManager.getFoodListExp(uid, nowDate.AddDays(-7), nowDate.AddDays(-1));

            int quantity = 0;
            int calories = 0;

            foreach(BFoodItem bFoodItem in foodItemList)
            {
                if (bFoodItem.ConsDate.Equals(null))
                {
                    quantity += bFoodItem.Quantity;
                    calories += bFoodItem.Quantity * bFoodItem.Calories;
                }
            }

            return new WeeklyReport(quantity, calories, foodItemList);
        }

    }

}
