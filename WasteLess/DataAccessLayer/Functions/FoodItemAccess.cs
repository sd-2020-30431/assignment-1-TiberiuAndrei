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
                //IEnumerable<FoodItem> account = (from _account in _dcm.BankAccount where _account.User_id == query_user.Id select _account).AsEnumerable();
            }
        }

        public void addFoodItem(FoodItem fi)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                _dcm.Add(fi);
                _dcm.SaveChanges();
                //IEnumerable<FoodItem> account = (from _account in _dcm.BankAccount where _account.User_id == query_user.Id select _account).AsEnumerable();
            }
        }

        public void removeFoodItem(long id)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                var movie = _dcm.FoodItems.Find(id);
                _dcm.FoodItems.Remove(movie);
                _dcm.SaveChanges();
                //IEnumerable<FoodItem> account = (from _account in _dcm.BankAccount where _account.User_id == query_user.Id select _account).AsEnumerable();
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
