using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Factories
{
    public class NullSendStrategy : ISendStrategy
    {
        public void Send(Notification notification)
        {
            // intenstionaly Do nothing
        }
    }
}
