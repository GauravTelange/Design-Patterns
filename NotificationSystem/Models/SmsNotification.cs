using NotificationSystem.Factories;

namespace NotificationSystem.Models
{
    // PATTERN: RIP - this class's own Send() replaces an if-check in the caller

    public class SmsNotification : Notification
    {
        public SmsNotification(string message, string recipient, ISendStrategy sendStrategy) : base(message, recipient, sendStrategy) { }


        protected override bool Validate()
        {
            return base.Validate() && Recipient.Length == 10;
        }

        
    }
}