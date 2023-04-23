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
                _ => StatusCodes.Status500InternalServerError,
            };

            context.Result = new ContentResult
            {
                ContentType = "application/json",
                StatusCode = statusCode,
                Content = JsonSerializer.Serialize($"В методе {context.ActionDescriptor.DisplayName} возникло исключение: \n {context.Exception.Message} \n {context.Exception.StackTrace}")
            };
            context.ExceptionHandled = true;
        }
    }
}
