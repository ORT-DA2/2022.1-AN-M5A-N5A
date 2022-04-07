using System.Collections.Generic;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi;
namespace WebApiTest
{
    [TestClass]
    public class RestaurantControllerTest
    {
        [TestMethod]
        public void GetTest()
        {
            //inicializar los datos
            //Arrange
            List<Restaurant> restaurantsExpected = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Id = 1,
                    Name = "HorreoBurger",
                    Address = "General Rivera 3091",
                    Products = new List<Product>
                    {
                        new Product()
                        {
                            Id = 1,
                            Name = "Grajera",
                            Price = 300
                        }
                    }
                }
            };
            var mock = new Mock<IRestaurantLogic>(MockBehavior.Strict);
            mock.Setup(r=>r.GetAll()).Returns(restaurantsExpected);
            var controller = new RestaurantController(mock.Object);
           
            //Ejecucion del caso de prueba
            //act
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var restaurantResult = okResult.Value as IEnumerable<Restaurant>;
            //validar el resultado
            //Assert
            //Assert.AreEqual(200,okResult.StatusCode);
            //Assert.AreEqual(restaurantsExpected,restaurantResult);
            CollectionAssert.AreEqual(restaurantsExpected, (System.Collections.ICollection)restaurantResult, new BasicComparer());
        }
    }
}
