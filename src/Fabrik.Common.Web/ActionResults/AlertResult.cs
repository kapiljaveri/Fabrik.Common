﻿using System.Web.Mvc;

namespace Fabrik.Common.Web
{
    /// <summary>
    /// An ActionResult for returning notifications to the user
    /// </summary>
    public class AlertResult<TResult> : ActionResult where TResult : ActionResult
    {       
        private readonly TResult result;
        private readonly Alert message;

        public AlertResult(TResult result, AlertType alertType, string title, string description = null)
        {
            Ensure.Argument.NotNull(result, "result");
            Ensure.Argument.NotNullOrEmpty(title, "title");
            
            this.result = result;
            this.message = new Alert(alertType, title, description);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.Controller.TempData[typeof(Alert).FullName] = message;
            result.ExecuteResult(context);
        }
    }
}