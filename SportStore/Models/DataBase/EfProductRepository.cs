using SportStore.Models.Entities;
using SportStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Models.DataBase
{
    public class EfProductRepository : IProductRepository
    {
        private EfDbContext context = new EfDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}