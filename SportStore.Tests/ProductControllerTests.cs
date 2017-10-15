using Moq;
using NUnit.Framework;
using SportStore.Controllers;
using SportStore.Models;
using SportStore.Models.Entities;
using SportStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Tests
{
    [TestFixture]
    public class ProductControllerTests
    {
        [Test]
        public void Can_Paginate()
        {
            // przygotowanie
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {

                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // działanie
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;
            // asercje
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
        [Test]
        public void Can_Send_Pagination_View_Model()
        {
            // przygotowanie
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
new Product {ProductID = 1, Name = "P1"},
new Product {ProductID = 2, Name = "P2"},
new Product {ProductID = 3, Name = "P3"},
new Product {ProductID = 4, Name = "P4"},
new Product {ProductID = 5, Name = "P5"}
});
            // przygotowanie
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // działanie
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;
            // asercje
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }

}
