using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;
using NotificationSystem.Repositories;


namespace NotificationSystem.Mediators
{
    // Pattern: Mediator
    // Coordinates sending, saving and logging so callers only call Dispatch
    public class NotificationMediator : INotificationMediator
    {
        private readonly INotificationRepository _notifications;
        private readonly ILogRepository _logs;

        public NotificationMediator(INotificationRepository notification, ILogRepository logs)
        {
            _notifications = notification;
            _logs = logs;
        }

        public void Dispatch(Notification notification)
        {
            if (notification.Process())
            {
                _notifications.Save(notification);
                _logs.Save($"Sent to {notification.Recipient}");
            }
            else
            {
                _logs.Save($"Failed validation for {notification.Recipient}");
            }
        }
    }
}
