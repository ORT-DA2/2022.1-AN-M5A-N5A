using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi;
namespace WebApiTest
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void GetMoviesFilteredTest()
        {
            //inicializar los datos
            //Arrange
            var controller = new MoviesController();
            int dummy =1;

            //Ejecucion del caso de prueba
            //act
            var result = controller.GetMoviesFiltered(dummy);
            var okResult = result as OkResult;

            //validar el resultado
            //Assert
            Assert.AreEqual(200,okResult.StatusCode);
        }
    }
}
