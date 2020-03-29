using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Mail { get; set; }

        public DateTime LastSent { get; set; }

        [ForeignKey("User_id")]
        public ICollection<FoodItem> FoodItems { get; set; }


    }
}
