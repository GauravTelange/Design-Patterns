namespace NotificationSystem.Models
{
    public class SmsNotification : Notification
    {
        public SmsNotification(string message, string recipient) : base(message, recipient) { }


        public override void Send()
        {
            Console.WriteLine($"Sending SMS to {Recipient}: {Message}");
        }
    }
}