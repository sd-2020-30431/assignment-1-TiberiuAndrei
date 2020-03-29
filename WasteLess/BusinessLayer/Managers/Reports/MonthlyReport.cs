using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;

namespace BusinessLayer.Managers.Reports
{
    public class MonthlyReport : AbstractMonthlyReport
    {
        public long quantity;
        public long calories;
        public List<BFoodItem> foodItemList;
        public MonthlyReport(long quantity, long calories, List<BFoodItem> foodItemList)
        {
            this.quantity = quantity;
            this.calories = calories;
            this.foodItemList = foodItemList;
        }
    }
}
