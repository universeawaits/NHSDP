using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System;


namespace NHSDP_Request_handling.WEB.Filters
{
    public class ExceptionGuard : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionMessage = context.Exception.Message;

            context.Result = new ContentResult
            {
                Content = $"An exception occured in {actionName}: \n {GetExceptionMessage(context.Exception)}"
            };
            context.ExceptionHandled = true;
        }

        private string GetExceptionMessage(Exception ex)
        {
            return ex.InnerException == null ? ex.Message : GetExceptionMessage(ex.InnerException); 
        }
    }
}
