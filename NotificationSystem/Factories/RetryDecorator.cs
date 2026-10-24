using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Factories
{
    //Decorator Pattern
    // Wraps any ISendStrategy and adds retry behavior without changing the wrapped class
    public class RetryDecorator : ISendStrategy
    {
        private readonly ISendStrategy _inner;
        private readonly int _maxAttempts;

        public RetryDecorator(ISendStrategy inner, int maxAttempts = 3)
        {
            _inner = inner;
            _maxAttempts = maxAttempts;
        }

        public void Send(Notification notification)
        {
            for (int attempt = 1; attempt <= _maxAttempts; attempt++)
            {

                try
                {
                    _inner.Send(notification);
                    return; // Exit if successful
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");
                }
            }
                Console.WriteLine("All retries failed");
            
        }
    }
}
