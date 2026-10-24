using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly List<string> _logs = new List<string>();

        public void Save(string log)
        {
            _logs.Add(log);
            Console.WriteLine("Log saved.");
        }

        public List<string> GetAll()
        {
            return _logs;
        }
     }
}
