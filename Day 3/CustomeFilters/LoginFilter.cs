using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Day_3.CustomeFilters
{
    public class LoginFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == false)
            {
                context.Result = new ContentResult() { Content = "You Must LOGIN" };

                //new redirecttoaction("login","accoun",null")
            }
        }


    }
}
