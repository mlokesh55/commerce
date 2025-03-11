using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using commerce.Aspects;
using commerce.Exceptions;

namespace commerce.Aspects
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var message = context.Exception.Message;

            if (exceptionType == typeof(CartNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(CartAlreadyExistsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }
            else
            {
                var result = new StatusCodeResult(500);
                context.Result = result;
            }
        }
    }
}
