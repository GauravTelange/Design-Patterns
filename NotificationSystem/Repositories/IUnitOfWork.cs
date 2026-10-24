using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Repositories
{
    // Unit Of Work Pattern
    // Collects changes and applies them together on Commit , or discards them on Rollback
    public  interface IUnitOfWork
    {
        INotificationRepository Notification { get; }
        ILogRepository Logs     { get; }
        void AddNotification(Notification notification);
        void AddLog(string log);
        void Commit();
        void Rollback();
     
    }
}
