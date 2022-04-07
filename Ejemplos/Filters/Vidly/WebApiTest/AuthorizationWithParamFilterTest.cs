
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Abstractions;
using WebApi.Filters;
using BusinessLogicInterface;
using System;

namespace WebapiTest
{
    [TestClass]
    public class AuthorizationWithParamFilterTest
    {
        [TestMethod]
        public void TestAuthFilterWithoutHeader()
        {
            var logicMock = new Mock<IUserLogic>(MockBehavior.Strict);
            // Si provider.GetService(typeof(IUserLogic)) es llamado, IUserLogic mock va a ser retornado
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(provider => provider.GetService(typeof(IUserLogic)))
                .Returns(logicMock.Object);

            // Mock el HttpContext para retornar lo moqueado
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(context => context.RequestServices)
                .Returns(serviceProviderMock.Object);
            //Header es null
            httpContextMock.SetupGet(context => context.Request.Headers["token"]).Returns((string)null);

            ActionContext fakeActionContext = new ActionContext(httpContextMock.Object,  new Microsoft.AspNetCore.Routing.RouteData(),
                                                                 new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
            //No usamos la metadata
            List<IFilterMetadata> metadata = new();
            //Instancio la clase final que voy a mockear
            AuthorizationFilterContext fakeAuthFilterContext = new AuthorizationFilterContext(fakeActionContext, metadata);


            //ACT
            AuthorizationWithParameterFilter authFilter = new AuthorizationWithParameterFilter("Admin");
            authFilter.OnAuthorization(fakeAuthFilterContext);

            ContentResult response = fakeAuthFilterContext.Result as ContentResult;
            
            //Assert
            Assert.AreEqual(401, response.StatusCode);
            Assert.AreEqual("You aren't logued.", response.Content);

        }

        [TestMethod]
        public void TestAuthFilterWithInvalidHeader()
        {
            string token = "qwert123yu5i4o6p87";
            var logicMock = new Mock<IUserLogic>(MockBehavior.Strict);
            logicMock.Setup(x => x.IsLogued(token)).Returns(false);

            // Si provider.GetService(typeof(IUserLogic)) es llamado, IUserLogic mock va a ser retornado
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(provider => provider.GetService(typeof(IUserLogic)))
                .Returns(logicMock.Object);

            // Mock el HttpContext para retornar lo moqueado
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(context => context.RequestServices)
                .Returns(serviceProviderMock.Object);
            //defino y mockero respuesta del Header para el token
 
            httpContextMock.SetupGet(context => context.Request.Headers["token"]).Returns(token);

            ActionContext fakeActionContext = new ActionContext(httpContextMock.Object, new Microsoft.AspNetCore.Routing.RouteData(),
                                                                 new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
            //No usamos la metadata
            List<IFilterMetadata> metadata = new();
            //Instancio la clase final que voy a mockear
            AuthorizationFilterContext fakeAuthFilterContext = new AuthorizationFilterContext(fakeActionContext, metadata);


            //ACT
            AuthorizationWithParameterFilter authFilter = new AuthorizationWithParameterFilter("Admin");
            authFilter.OnAuthorization(fakeAuthFilterContext);

            ContentResult response = fakeAuthFilterContext.Result as ContentResult;

            Assert.AreEqual(403, response.StatusCode);
        }

        [TestMethod]
        public void TestAuthFilterWithValidHeader()
        {
            string token = "qwert123yu5i4o6p87";
            var logicMock = new Mock<IUserLogic>(MockBehavior.Strict);
            logicMock.Setup(x => x.IsLogued(token)).Returns(true);

            // Si provider.GetService(typeof(IUserLogic)) es llamado, IUserLogic mock va a ser retornado
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(provider => provider.GetService(typeof(IUserLogic)))
                .Returns(logicMock.Object);

            // Mock el HttpContext para retornar lo moqueado
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(context => context.RequestServices)
                .Returns(serviceProviderMock.Object);
            //defino y mockero respuesta del Header para el token

            httpContextMock.SetupGet(context => context.Request.Headers["token"]).Returns(token);

            ActionContext fakeActionContext = new ActionContext(httpContextMock.Object, new Microsoft.AspNetCore.Routing.RouteData(),
                                                                 new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
            //No usamos la metadata
            List<IFilterMetadata> metadata = new();
            //Instancio la clase final que voy a mockear
            AuthorizationFilterContext fakeAuthFilterContext = new AuthorizationFilterContext(fakeActionContext, metadata);


            //ACT
            AuthorizationWithParameterFilter authFilter = new AuthorizationWithParameterFilter("Admin");
            authFilter.OnAuthorization(fakeAuthFilterContext);

            ContentResult response = fakeAuthFilterContext.Result as ContentResult;

            Assert.IsNull(response);
        }
    }
}