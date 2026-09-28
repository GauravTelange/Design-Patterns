using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Factories
{
    public class UrgentStrategy : ISendStrategy
    {
        public void Send(Notification notification)
        {
            Console.WriteLine($"Urgent: Sending to {notification.Recipient}: {notification.Message}");
            Console.WriteLine("Retrying to confirm delivery...");   

        }

    }
    
}
