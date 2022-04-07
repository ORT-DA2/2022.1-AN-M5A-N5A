using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApi.Filters
{
    public class AuthorizationWithParameterFilter : Attribute, IAuthorizationFilter
    {
        private IUserLogic logic;
        private string arg;

        public AuthorizationWithParameterFilter(string arguments)
        {
            arg = arguments;

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            logic = context.HttpContext.RequestServices.GetService<IUserLogic>();
            string token = context.HttpContext.Request.Headers["token"];
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "You aren't logued."
                };
            }else if (!logic.IsLogued(token)) //Aca se debería hacer algo con el arg que pasamos
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "You aren't logued correctly."
                };

                //Para obli, segun el perfil, decir si no sos del tipo X => 403.
            }
        }
    }
}
