using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.WEB.API.Middware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string message;
            var respon = new
            {
                devMsg = exception.Message,
                userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA",
                MISACode = "MISA002",
                Data = exception.Data
            };

            var stackTrace = String.Empty;
            message = exception.Message;

            var result = JsonSerializer.Serialize(respon);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            return context.Response.WriteAsync(result);
        }
    }
}