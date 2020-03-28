using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class BFoodItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Calories { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime ExpDate { get; set; }

        public DateTime? ConsDate { get; set; }

        public long User_id { get; set; }

    }
}
