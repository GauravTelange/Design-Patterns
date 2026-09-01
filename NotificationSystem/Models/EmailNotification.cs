namespace NotificationSystem.Models
{
    // PATTERN: RIP - this class's own Send() replaces an if-check in the caller
    public class EmailNotification : Notification
    {
    
        public EmailNotification( string message, string recipient) 
            : base(message, recipient){ }

        public override void Send()
        {
            Console.WriteLine($"Sending Email to {Recipient}: {Message}");

        }
    }


}