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

        public void Process()
        {
            Prepare();
            if (!Validate())
            {
                Console.WriteLine($"Validation failed for {Recipient}. Skipping send.");
                return;
            }
            Send();
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
    }
}