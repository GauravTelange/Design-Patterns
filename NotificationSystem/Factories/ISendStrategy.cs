using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Factories
{
    //strategy pattern for sending notifications
    public interface ISendStrategy
    {
        void Send(Notification notification);
    }
}
