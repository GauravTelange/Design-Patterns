namespace NotificationSystem.Models
{
    // PATTERN: RIP(Replace If with Polymorphism)
    // Abstract Send() forces every child class to define its own behavior,
    // so no "if (type == ...)" is needed anywhere when sending.

    public abstract class Notification
    {
        public string Message { get; set; }
        public string Recipient { get; set; }

        protected Notification(string message, string recipient)
        {
            Message = message;
            Recipient = recipient;
        }

        public abstract void Send();
    }
}