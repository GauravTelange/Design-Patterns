using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Factories
{
    public static class TemplateProvider
    {

        private static readonly Lazy<Dictionary<string, string>> _templates = 
            new Lazy<Dictionary<string, string>>(() =>
            {

                Console.WriteLine("Loading templates....(this runs only once)");
                return new Dictionary<string, string>
                {
                    {"welcome", "Welcome to our service!"},
                    {"otp", "Your OTP is {0}"},
                    {"reminder", "This is a reminder for your appointment."}
                };

            });

        public static string GetTemplate(string key)
        {
            return _templates.Value.TryGetValue(key, out var value) ? value : "Template not found";
        }
    }
}
