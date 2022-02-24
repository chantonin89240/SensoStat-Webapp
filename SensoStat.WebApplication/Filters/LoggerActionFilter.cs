﻿namespace SensoStat.WebApplication.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using SensoStat.WebApplication.Controllers;
    using SensoStat.WebApplication.Services;

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
            var tokenExiste = context.HttpContext.Request.Cookies.ContainsKey("Jwt");
            var controllerName = (string)context.RouteData.Values["Controller"];

            if (!tokenExiste && controllerName != "Home")
            {

                context.Result = new RedirectToActionResult("Index", "Home", null);
            }

            if (context.ModelState.IsValid)
            {
                if (tokenExiste)
                {
                    var token = context.HttpContext.Request.Cookies["Jwt"];
                    ClientService.tokenApi = token;
                }
            }
            else
            {
                // context.Result = new BadRequestObjectResult(context.ModelState);
                context.ModelState.AddModelError(string.Empty, "Veuillez saisir tous les champs obligatoires.");
            }
        }

        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
            this._logger.LogDebug(1, "");
        }
    }
}
