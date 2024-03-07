using Microsoft.AspNetCore.Http;
using Core.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class HandleExpceptionMiddleware
    {
        private RequestDelegate _next;

        public HandleExpceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Content-Type", "application/json");
            try
            {
                await _next(context);
            }
            catch (ValidateException ex)
            {
                var serviceResult = new ServiceResult();
                serviceResult.DevMsg = new List<string> { ex.Message };
                context.Response.StatusCode = 400;
                var res = JsonConvert.SerializeObject(serviceResult);
                await context.Response.WriteAsync(res);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                serviceResult.DevMsg = new List<string> { ex.Message };
                var res = JsonConvert.SerializeObject(serviceResult);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(res);
            }
        }
    }
}
