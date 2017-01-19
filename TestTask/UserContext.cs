using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TestTask.Models;
namespace TestTask
{
    class UserContext : DbContext
    {
        public UserContext() : base("DefaultConnection")
        { }
        public DbSet<UserModel> Users { get; set; }
    }
}