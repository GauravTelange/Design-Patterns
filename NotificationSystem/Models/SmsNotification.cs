namespace NotificationSystem.Models
{
    // PATTERN: RIP - this class's own Send() replaces an if-check in the caller

    public class SmsNotification : Notification
    {
        public SmsNotification(string message, string recipient) : base(message, recipient) { }


        public override void Send()
        {
            Console.WriteLine($"Sending SMS to {Recipient}: {Message}");
        }
    }
}