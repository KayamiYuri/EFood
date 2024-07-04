using Core.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Web.Areas.Admin.Extensions;

namespace Web.Areas.Filters
{
    public class CostomActionFilter : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            var area = context.RouteData.Values["area"];
            if (context.RouteData.Values["action"].ToString() != "Login" && area?.ToString() == "Admin")
            {
                var member = context.HttpContext.Session.GetObject<Member>("Member");
                if (member == null)
                {
                    context.Result = new RedirectResult("/Admin/Member/Login");
                }
            }
        }
    }
}
