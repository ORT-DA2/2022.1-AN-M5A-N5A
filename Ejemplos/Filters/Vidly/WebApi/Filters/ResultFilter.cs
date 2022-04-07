using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebApi.DTO;

namespace WebApi.Filters
{
    public class ResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            ResponseDTO response = new ResponseDTO
            {
                Code = 1000,
                Content = ((ObjectResult)context.Result).Value,
                IsSuccess = true
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = 200
            };
        }
    }
}
