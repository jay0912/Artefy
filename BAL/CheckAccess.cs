using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Artefy.BAL
{
    public class CheckAccess : ActionFilterAttribute, IAuthorizationFilter
    {
        //when userid is not there then it will bw rwdirect to the login page
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("UserID") == null)
            {
                filterContext.Result = new RedirectResult("~/SEC_User/SEC_User/Index");
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            filterContext.HttpContext.Response.Headers["Expires"] = "-1";
            filterContext.HttpContext.Response.Headers["Pragma"] = "no-cache";
            base.OnResultExecuting(filterContext);
        }

    }
}
