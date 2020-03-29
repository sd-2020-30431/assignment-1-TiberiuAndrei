using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
    public class BFoodItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Calories { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Expiration Date")]
        public DateTime ExpDate { get; set; }

        [Display(Name = "Consumption Date")]
        public DateTime? ConsDate { get; set; }

        public long User_id { get; set; }

    }
}
