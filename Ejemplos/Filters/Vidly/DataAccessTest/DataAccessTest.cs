using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class DataAccessTest
    {
        [TestMethod]
        public void CreateRestaurantOk()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new MyContext(options))
            {
                var repository = new RestaurantRepository(context);
                Restaurant restaurant = new Restaurant()
                {
                    Id = 1,
                    Name = "Prueba"
                };
                repository.Create(restaurant);
                repository.Save();
                Assert.AreEqual("Prueba", repository.GetAll().First().Name);
                context.Set<Restaurant>().Remove(restaurant);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void GetAllTest()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
            .UseInMemoryDatabase(databaseName: "TestDB2")
            .Options;

            using (var context = new MyContext(options))
            {
                var repository = new RestaurantRepository(context);
                Restaurant restaurant = new Restaurant()
                {
                    Id = 1,
                    Name = "Prueba",
                    Products = new List<Product>()

                };
               Restaurant restaurant2 = new Restaurant()
                {
                    Id = 2,
                    Name = "Prueba2",
                    Products = new List<Product>()
                };
                context.Set<Restaurant>().Add(restaurant);
                context.Set<Restaurant>().Add(restaurant2);
                context.SaveChanges();

                IEnumerable<Restaurant> restaurants = repository.GetAll();
                Assert.AreEqual(2, restaurants.Count());
            }
        }
    }
}
