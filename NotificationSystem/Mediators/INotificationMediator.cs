using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Mediators
{
    public interface INotificationMediator
    {
        void Dispatch(Notification notification);
    }
}
