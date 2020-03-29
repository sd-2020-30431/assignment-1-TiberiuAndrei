using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class MailBot
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public string Password { get; set; }

    }

}
