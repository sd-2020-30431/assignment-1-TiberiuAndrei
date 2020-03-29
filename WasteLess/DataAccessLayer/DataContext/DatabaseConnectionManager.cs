using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataContext
{
    public class DatabaseConnectionManager : DbContext
    {
        /*public DatabaseConnectionManager(DbContextOptions<DatabaseConnectionManager> options) : base(options)
        {

        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-H7CJLP2;Initial Catalog=WasteLess;Integrated Security=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<MailBot> MailBots { get; set; }

    }
}
