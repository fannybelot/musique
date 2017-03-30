using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.App_Start
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) //ing = avant
        {
            filterContext.Controller.ViewBag.CustomActionMessage1 = "Message from OnActionExecuting method";
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) //ed = après
        {
            filterContext.Controller.ViewBag.CustomActionMessage2 = "Message from OnActionExecuted method";
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage3 = "Message from OnResultExecuting method";
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage4 = "Message from OnResultExecuted method";
        }
    }
}