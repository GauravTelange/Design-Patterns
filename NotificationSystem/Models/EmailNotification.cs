using NotificationSystem.Factories;

namespace NotificationSystem.Models
{
    // PATTERN: RIP (via base Send) + Template Method (Validate override) + Strategy (injected _sendStrategy)
    public class EmailNotification : Notification
    {

        public EmailNotification(string message, string recipient, ISendStrategy sendStrategy)
            : base(message, recipient, sendStrategy) { }
    
        protected override bool Validate()
        {
            return base.Validate() && Recipient.Contains("@");
        }
    }


}