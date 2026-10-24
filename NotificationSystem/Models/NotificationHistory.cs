using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Models
{
    public class NotificationHistory
    {

        private readonly Stack<NotificationMemento> _snapshots = new Stack<NotificationMemento>();

        public bool CanUndo => _snapshots.Count > 0;

        public void Push(NotificationMemento memento)
        {
            _snapshots.Push(memento);
        }

        public NotificationMemento Pop()
        {
            return _snapshots.Pop();
        }
    }
}
