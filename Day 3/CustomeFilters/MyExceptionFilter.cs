using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Day_3.Controllers
{
    public class MyExceptionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)

        {

            if(context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult() { Content = "PLZ TRY AGAIN" };
                //= new viewresult() {ViewName= "My error"};
            }
            base.OnActionExecuted(context);

        }
    }
}
