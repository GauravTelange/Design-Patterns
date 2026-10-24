using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Factories
{
    public  class FlakySendStrategy : ISendStrategy
    {
        private int _attempt = 0;

        public void Send(Notification notification)
        {
            _attempt++;
            if(_attempt < 3 )
            {
                throw new Exception($"Network error (attempt {_attempt})");
            }
            Console.WriteLine($"[Flaky] Delivered to {notification.Recipient}: {notification.Message}");
        }
    }
}
