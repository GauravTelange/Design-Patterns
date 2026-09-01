using NotificationSystem.Models;

namespace NotificationSystem.Factories {


    // PATTERN: Factory
    // Centralizes object creation. This is the ONLY place with an if/switch
    // for deciding which concrete Notification type to instantiate.
    public static class NotificationFactory
    { 
        public static Notification Create(string type, string message, string recipient)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification(message, recipient);
                case "sms":
                    return new SmsNotification(message, recipient);
                default:
                    throw new ArgumentException($"Unkown notification type; {type}");
            }



            }
         
    }

}