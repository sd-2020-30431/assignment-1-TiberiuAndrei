using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer.Functions
{
    public class UserAccess
    {
        public int count_users(string username, string password)
        {
            int count = 0;
            using (var _dcm = new DatabaseConnectionManager())
            {
                count = _dcm.Users.Count(x => (x.Username == username && x.Password == password));
            }
            return count;
        }
        public long get_id(string username, string password)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                User query_user = _dcm.Users.Where(x => (x.Username == username && x.Password == password)).FirstOrDefault();
                return query_user.Id;
            }

        }

        public long getId(string username)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                User query_user = _dcm.Users.Where(x => x.Username == username).FirstOrDefault();
                return query_user.Id;
            }

        }

        public string getMail(string username)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                User query_user = _dcm.Users.Where(x => x.Username == username).FirstOrDefault();
                return query_user.Mail;
            }

        }

        //LastSent is used to avoid mail spamming
        public DateTime getLastSent(string username)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                User query_user = _dcm.Users.Where(x => x.Username == username).FirstOrDefault();
                return query_user.LastSent;
            }

        }

        public void updateLastSent(long uid, DateTime date)
        {
            using (var _dcm = new DatabaseConnectionManager())
            {
                var user = _dcm.Users.Find(uid);
                user.LastSent = date;
                _dcm.Users.Update(user);
                _dcm.SaveChanges();
            }

        }

    }
}
