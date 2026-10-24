using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Factories
{
    //Pattern : Factory Method
    // Base class defines the flow, each subclass decides which notification to create
    public abstract class NotificationCreator
    {
            protected abstract Notification CreateNotification(string message, string recipent);

            public void Notify(string message, string recipent)
            {
                Notification notification = CreateNotification(message, recipent);
                notification.Process();
            }
        
    }
}
