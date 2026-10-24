using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Factories
{
    public class SmsCreator : NotificationCreator
    {
        protected override Notification CreateNotification(string message, string recipent)
        {
            return new SmsNotification(message, recipent, new SmsGatewayAdapter());
        }

    }
}
