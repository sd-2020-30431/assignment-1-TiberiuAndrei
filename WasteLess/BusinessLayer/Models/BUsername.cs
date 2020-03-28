using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class BUsername
    {
        public BUsername() { }
        public BUsername(string u)
        {
            Username = u;
        }
        public string Username { get; set; }
    }
}
