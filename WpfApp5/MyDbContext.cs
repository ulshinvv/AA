using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp5.model;

namespace WpfApp5
{
    internal class MyDbContext:DbContext
    {
        public string connetionString = @"Data Source=; Initial Catalog=testik; Integrated Security=true;";
        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }

        public DbSet<Comments> Comments { get; set; }
        
        public DbSet<Reqiests> Reqiests { get; set; }


    }
}
