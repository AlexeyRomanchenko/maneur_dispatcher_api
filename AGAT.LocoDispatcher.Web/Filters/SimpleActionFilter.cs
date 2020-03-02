using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AGAT.LocoDispatcher.Web.Filters
{
    public class SimpleActionFilter : Attribute, IActionFilter
    {
        private int _id;
        public SimpleActionFilter(int id)
        {
            _id = id;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append($"LastVisit {_id}", DateTime.Now.ToString("dd/MM/yyyy hh-mm-ss"));
        }
    }
}
