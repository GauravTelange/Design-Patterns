using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationSystem.Models;

namespace NotificationSystem.Factories
{
    //Pattern : Adapter
    // Makes ThirdPartySmsGateway fit our ISendStrategy interface
    public class SmsGatewayAdapter : ISendStrategy 
    {
        private readonly ThirdPartySmsGateway _gateway = new ThirdPartySmsGateway();

        public void Send(Notification notification)
        {
            _gateway.DispatchSms(notification.Recipient, notification.Message);
        }
    }
    
}
