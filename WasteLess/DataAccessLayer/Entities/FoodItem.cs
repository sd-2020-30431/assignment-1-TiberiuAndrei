using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class FoodItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public DateTime ExpDate { get; set; }

        public DateTime? ConsDate { get; set; }

        [Required]
        public long User_id { get; set; }

        public User User { get; set; }
    }
}
