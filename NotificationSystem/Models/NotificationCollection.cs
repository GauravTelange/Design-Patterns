using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Models
{
    //Pattern : Iterator
    // Lets callers loop with foreach without knowing how the items are stored
    public class NotificationCollection
    {
        private readonly List<Notification> _items = new List<Notification>();
        
        public void Add(Notification notification)
        {
            _items.Add(notification);
        }

        public IEnumerator<Notification> GetEnumerator()
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }

        // A second iterator : gives only email notifications
        public IEnumerable<Notification> onlyEmails()
        {
            foreach (var item in _items)
            {
                if (item is EmailNotification)
                    yield return item;
            }
        }

    }
}
