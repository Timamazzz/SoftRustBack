using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SoftRustBack.DTO.ErrorsMessage;
using System.Text.Json;

namespace SoftRustBack.Application.Filters
{
    /// <summary>
    /// Фильтр исключений
    /// </summary>
    public class MyExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Метод перехватывает и обрабатывает исключение
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            int statusCode = context.Exception switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                FormatException => StatusCodes.Status400BadRequest,
                NullReferenceException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            context.Result = new ContentResult
            {
                ContentType = "application/json",
                StatusCode = statusCode,
                Content = JsonSerializer.Serialize(new ErrorMessageDto
                {
                    Key = string.Empty,
                    Method = context.ActionDescriptor.DisplayName,
                    Message = context.Exception.Message,
                    StackTrace = context.Exception.StackTrace
                })
            };
            context.ExceptionHandled = true;
        }
    }
}
