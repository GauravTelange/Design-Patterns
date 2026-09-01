namespace NotificationSystem.Models
{
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