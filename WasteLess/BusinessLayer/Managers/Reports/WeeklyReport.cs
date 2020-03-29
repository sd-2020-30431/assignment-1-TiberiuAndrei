using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;

namespace BusinessLayer.Managers.Reports
{
    public class WeeklyReport : AbstractWeeklyReport
    {
        public long quantity;
        public long calories;
        public List<BFoodItem> foodItemList;
        public WeeklyReport(long quantity, long calories, List<BFoodItem> foodItemList)
        {
            this.quantity = quantity;
            this.calories = calories;
            this.foodItemList = foodItemList;
        }
    }
}
