using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Factories
{
    public class ThirdPartySmsGateway
    {
        public void DispatchSms(string phoneNumber, string text)
        {
            // Simulate sending SMS via a third-party service
            Console.WriteLine($"[ThirdPartySmsGateway] SMS to {phoneNumber}: {text}");
        }

    }
}
