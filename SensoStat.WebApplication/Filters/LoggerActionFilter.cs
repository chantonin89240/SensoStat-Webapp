﻿namespace SensoStat.WebApplication.Filters
{
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class LoggerActionFilter : IActionFilter, IExceptionFilter
    {
        private readonly ILogger _logger;

        public LoggerActionFilter(ILogger<LoggerActionFilter> logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            /*StringBuilder stringBuilder = new StringBuilder("Sortie de l'action [");
            stringBuilder.Append(context.ActionDescriptor.ControllerDescriptor.ControllerType.FullName)
                .Append(".")
                .Append(context.ActionDescriptor.DisplayName)
                .Append("].");
            this._logger.LogDebug(stringBuilder.ToString());
            stringBuilder.Clear();
            base.OnActionExecuted(context);*/
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
            this._logger.LogDebug(1, "");
        }
    }
}