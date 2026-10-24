using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly List<Action> _pending = new List<Action>();

        public INotificationRepository Notification { get; } = new NotificationRepository();
        public ILogRepository Logs { get; } = new LogRepository();

        public void AddNotification(Notification notification)
        {
            _pending.Add(() => Notification.Save(notification));
        }

        public void AddLog(string log)
        {
            _pending.Add(() => Logs.Save(log));

        }

        public void Commit()
        {
            foreach (var action in _pending)
            {
                action();
            }

            _pending.Clear();
            Console.WriteLine("Commit done.");
        }

        public void Rollback()
        {
            _pending.Clear();
            Console.WriteLine("Rolled back. Nothing was saved.");
        }
    }
}
