using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class CharOrg
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

    }

}
