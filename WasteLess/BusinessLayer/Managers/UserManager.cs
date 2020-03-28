﻿using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;
using DataAccessLayer.Functions;

namespace BusinessLayer.Managers
{
    public class UserManager
    {
        public bool validate_user(BUser buser)
        {
            UserAccess ua = new UserAccess();
            if(ua.count_users(buser.Username, buser.Password) == 1)
            {
                return true;
            }
            return false;

        }

        public long get_id(BUser buser)
        {
            UserAccess ua = new UserAccess();
            return ua.get_id(buser.Username, buser.Password);

        }

        public long getId(string user)
        {
            UserAccess ua = new UserAccess();
            return ua.getId(user);

        }

    }
}
