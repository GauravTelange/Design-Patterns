using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Models
{
    //Memento Pattern
    // Stores a snapshot of a notification's state so it can be restore later
    public class NotificationMemento
    {
        public string Message { get; }
        public string Recipient { get; }

        public NotificationMemento(string message, string recipient)
        {
            Message = message;
            Recipient = recipient;
        }
    }
}
