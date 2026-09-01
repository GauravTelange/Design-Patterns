namespace NotificationSystem.Models
{

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