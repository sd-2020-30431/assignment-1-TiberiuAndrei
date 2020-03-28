using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Functions;
using DataAccessLayer.Entities;
using BusinessLayer.Models;

namespace BusinessLayer.Managers
{
    public class FoodManager
    {
        public List<BFoodItem> getFoodList(long uid)
        {
            FoodItemAccess fia = new FoodItemAccess();
            List<FoodItem> food_list = fia.get_food_list(uid);
            List<BFoodItem> bfood_list = new List<BFoodItem>();
            foreach(FoodItem fi in food_list)
            {
                bfood_list.Add(convert_to_bfi(fi));
            }
            return bfood_list;
        }

        private BFoodItem convert_to_bfi(FoodItem fi)
        {
            return new BFoodItem
            {
                Id = fi.Id,
                Name = fi.Name,
                Quantity = fi.Quantity,
                Calories = fi.Calories,
                PurchaseDate = fi.PurchaseDate,
                ExpDate = fi.ExpDate,
                ConsDate = fi.ConsDate,
                User_id = fi.User_id
            };
        }

        private FoodItem convert_to_fi(BFoodItem bfi)
        {
            return new FoodItem
            {
                Id = bfi.Id,
                Name = bfi.Name,
                Quantity = bfi.Quantity,
                Calories = bfi.Calories,
                PurchaseDate = bfi.PurchaseDate,
                ExpDate = bfi.ExpDate,
                ConsDate = bfi.ConsDate,
                User_id = bfi.User_id
            };
        }

        public void addFoodItem(BFoodItem bFoodItem)
        {
            FoodItemAccess fia = new FoodItemAccess();
            FoodItem latestFood = fia.findLatestFood();
            if (!(latestFood.Name.Equals(bFoodItem.Name) && latestFood.PurchaseDate.Equals(bFoodItem.PurchaseDate)))
            {
                fia.addFoodItem(convert_to_fi(bFoodItem));
            }
        }

        public void removeFoodItem(long bfid)
        {
            FoodItemAccess fia = new FoodItemAccess();
            if (fia.findId(bfid) != 0)
            {
                fia.removeFoodItem(bfid);
            }
        }

    }
}
