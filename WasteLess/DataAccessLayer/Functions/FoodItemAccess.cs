using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.DataContext;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Functions
{
    public class FoodItemAccess
    {
        public List<FoodItem> get_food_list(long id)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                IEnumerable<FoodItem> food_item_enum = (from _food_item in _dcm.FoodItems where _food_item.User_id == id select _food_item).AsEnumerable();
                return food_item_enum.ToList();
            }
        }

        //returns the food items for the user identified by uid, that have been purchased between leftTime and rightTime
        //this function is not used anymore but i have not delete it just in case I will need it again
        public List<FoodItem> getFoodList(long id, DateTime leftDate, DateTime rightDate)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                IEnumerable<FoodItem> food_item_enum = _dcm.FoodItems.Where(x => (x.User_id == id && x.PurchaseDate <= rightDate.AddDays(-1) && x.PurchaseDate >= leftDate && x.ConsDate == null));
                return food_item_enum.ToList();
            }
        }

        //returns the food items for the user identified by uid, that will expire between leftTime and rightTime
        public List<FoodItem> getFoodListExp(long id, DateTime leftDate, DateTime rightDate)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                IEnumerable<FoodItem> food_item_enum = _dcm.FoodItems.Where(x => (x.User_id == id && x.ExpDate <= rightDate && x.ExpDate >= leftDate && x.ConsDate == null));
                return food_item_enum.ToList();
            }
        }

        public FoodItem getFoodItem(long id)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                FoodItem foodItem = _dcm.FoodItems.Where(x => x.Id == id).FirstOrDefault();
                return foodItem;
            }
        }

        public void editConsDate(long id, DateTime? consDate)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                var foodItem = _dcm.FoodItems.Find(id);
                foodItem.ConsDate = consDate;
                _dcm.FoodItems.Update(foodItem);
                _dcm.SaveChanges();
            }

        }

        public void addFoodItem(FoodItem fi)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                _dcm.Add(fi);
                _dcm.SaveChanges();
            }
        }

        public void removeFoodItem(long id)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                var foodItem = _dcm.FoodItems.Find(id);
                _dcm.FoodItems.Remove(foodItem);
                _dcm.SaveChanges();
            }
        }

        public int findId(long id)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                int count = _dcm.FoodItems.Count(x => x.Id == id);
                return count;
            }
        }

        //used to avoid reinserting the last element in the database when the user refreshes the page
        public FoodItem findLatestFood()
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                int count = _dcm.FoodItems.Count();
                if (count != 0)
                {
                    long maxId = _dcm.FoodItems.Max(x => x.Id);
                    FoodItem query_food = _dcm.FoodItems.Where(x => x.Id == maxId).FirstOrDefault();
                    return query_food;
                }
                else
                {
                    FoodItem query_food = new FoodItem();
                    query_food.Name = "Initial food";
                    query_food.PurchaseDate = new DateTime(2020 - 01 - 01);
                    return query_food;
                }
            }
        }

    }
}
