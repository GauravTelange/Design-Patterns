using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Repositories
{
    public interface ILogRepository
    {

        void Save(string log);
        List<string> GetAll();
    }
}
