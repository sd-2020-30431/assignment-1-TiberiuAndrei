using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;
using DataAccessLayer.Functions;

namespace BusinessLayer.Managers
{
    public class UserManager
    {
        //cheks if the combination of user and password exists in the database
        public bool validate_user(BUser buser)
        {
            UserAccess ua = new UserAccess();
            if (ua.count_users(buser.Username, buser.Password) == 1)
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

        public string getMail(string username)
        {
            UserAccess ua = new UserAccess();
            return ua.getMail(username);
        }

        //gets the last date when a mail has been sent to a user
        //used to avoid spamming
        public DateTime getLastSent(string username)
        {
            UserAccess ua = new UserAccess();
            return ua.getLastSent(username);
        }

        public void updateLastSent(long uid)
        {
            UserAccess ua = new UserAccess();
            ua.updateLastSent(uid, DateTime.Now);
        }

    }
}
