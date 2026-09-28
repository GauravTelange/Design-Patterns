using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private List<Notification> _notification = new List<Notification>();

        public void Save(Notification notification)
        {
            _notification.Add(notification);
            Console.WriteLine("Saved to repository.");
        }

        public List<Notification> GetAll()
        {
            return _notification;

        }
    }
}
