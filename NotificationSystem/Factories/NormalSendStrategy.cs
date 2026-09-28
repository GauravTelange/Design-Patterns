using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Factories
{
        public class NormalSendStrategy : ISendStrategy
        {
            public void Send(Notification notification)
            {
                //send notification normally
                Console.WriteLine($"[Normal] Sending to {notification.Recipient}: {notification.Message}");
            }
    }

}
