using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApi.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly IUserLogic logic;
        public AuthorizationFilter(IUserLogic logic)
        {
            this.logic = logic;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["token"];
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "You aren't logued."
                };
            }
            else if (!logic.IsLogued(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "You aren't logued correctly."
                };

                //Para obli, crear para cada perfil y decir si no sos del tipo X 403.
            }
        }
    }
}