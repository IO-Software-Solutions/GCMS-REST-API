using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Modules
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEY = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ApiKeyIsProvided = context.HttpContext.Request.Headers.TryGetValue(APIKEY, out var apiKey);

            if (ApiKeyIsProvided)
            {
                var app = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

                if (apiKey.Equals(app.GetValue<string>(APIKEY)))
                {
                    await next();
                }
                else
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "Provided API Key Is Invalid"
                    };
                }
            }
            else
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No API Key Provided"
                };
            }
        }
    }
}
