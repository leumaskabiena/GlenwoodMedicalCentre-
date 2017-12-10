using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlenwoodMed.BusinessLogic
{
    public class WithNotificationResult : ActionResult
    {
        private readonly ActionResult _result;
        private readonly Status _status;
        private readonly string _message;

        public WithNotificationResult(ActionResult result, Status status, string message)
        {
            _result = result;
            _status = status;
            _message = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            // Add the notification
            context.Controller.Notifications().Add(_status, _message);

            // Continue with execution
            _result.ExecuteResult(context);
        }
    }
    public static class NotificationExtensions
    {
        // Action result extension method
        // Used within actions to add Notifications to results 
        public static ActionResult WithNotification(this ActionResult actionResult, Status status, string message)
        {
            return new WithNotificationResult(actionResult, status, message);
        }

        // Controller extension method
        // Used to hold retrieve the notifications from tempdata
        public static NotificationsO Notifications(this ControllerBase controller)
        {
            return new NotificationsO(controller.TempData);
        }

        // Html Helper extensions method
        // Used within Views to get the notifications THefrom temp data
        public static NotificationsO Notifications(this HtmlHelper htmlHelper)
        {
            return new NotificationsO(htmlHelper.ViewContext.TempData);
        }

    }
}
