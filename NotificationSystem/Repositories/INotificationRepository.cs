using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Repositories
{
    //  PATTERN : Repository 
    // Abstracts how notifications are stored - caller doesn't know if it's a List, database, or file

        public interface INotificationRepository {

            void Save(Notification notification);
            List<Notification> GetAll();
        }
    
}
