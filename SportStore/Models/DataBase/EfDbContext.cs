
using SportStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportStore.Models.DataBase
{
    public class EfDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}