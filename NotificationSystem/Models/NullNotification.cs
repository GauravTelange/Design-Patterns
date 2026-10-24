using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Factories;

namespace NotificationSystem.Models
{
    // Pattern: Null Object
    // Does nothing instead of returning null or throwing , so callers need no null checks
    public class NullNotification : Notification
    {
        public NullNotification() : base(string.Empty, string.Empty, new NullSendStrategy())
        {
        }

        protected override void Prepare() { }

        protected override bool Validate()
        {
            return true;
        }

    }
}
