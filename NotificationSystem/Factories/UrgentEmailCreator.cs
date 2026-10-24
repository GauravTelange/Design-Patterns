using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Factories
{
    public class UrgentEmailCreator : NotificationCreator
    {
        protected override Notification CreateNotification(string message, string recipent)
        {
            ISendStrategy strategy = new RetryDecorator(new UrgentStrategy());
            return new EmailNotification(message, recipent, strategy);
        }
    }
}
