using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SPArte.api.Infra
{
    public class GlobalException : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var message = string.Empty;

            if (context.Exception.InnerException != null)
            {
                message = context.Exception.InnerException.Message;
            }
            else
            {
                message = context.Exception.Message;
            }

            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(new { message });
        }
    }
}
