using NotificationSystem.Factories;
using System.Net.Http.Headers;

namespace NotificationSystem.Models
{
    // PATTERN: RIP(Replace If with Polymorphism)
    // Abstract Send() forces every child class to define its own behavior,
    // so no "if (type == ...)" is needed anywhere when sending.

    public abstract class Notification
    {
        protected ISendStrategy _sendStrategy;

        public string Message { get; set; }
        public string Recipient { get; set; }

        protected Notification(string message, string recipient, ISendStrategy sendStrategy)
        {
            Message = message;
            Recipient = recipient;
            _sendStrategy = sendStrategy;
        }


        //Template Pattern 
        // Fixed sequence of steps - subclasses can override individual steps but never the order

        public bool Process()
        {
            Prepare();
            if (!Validate())
            {
                Console.WriteLine($"Validation failed for {Recipient}. Skipping send.");
                return false;
            }
            Send();
            return true;
        }

        protected  virtual void Prepare()
        {
            Console.WriteLine($"Preparing notification for {Recipient}.");
        }

        protected virtual bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Recipient);
        }
        public void Send()
        {
            _sendStrategy.Send(this);
        }

        //Prototype Pattern
        // Creates a copy of this notification so callers can change only whatdiffers

        public Notification Clone()
        {
            return (Notification)this.MemberwiseClone();
        }

        public NotificationMemento Save()
        {
            return new NotificationMemento(Message, Recipient);
        }

        public void Restore(NotificationMemento memento)
        {
            Message = memento.Message;
            Recipient = memento.Recipient;
        }
    }
}