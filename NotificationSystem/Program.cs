using NotificationSystem.Factories;
using NotificationSystem.Models;
using NotificationSystem.Repositories;
Notification email = NotificationFactory.Create("email", "Hello there!", "gaurav@test.com", new NormalSendStrategy());
email.Process();

Notification sms = NotificationFactory.Create("sms", "OTP is 1234", "9876543210", new NormalSendStrategy());
sms.Process();


Console.WriteLine("Program is Started");
Console.WriteLine(TemplateProvider.GetTemplate("welcome"));
Console.WriteLine(TemplateProvider.GetTemplate("otp"));

Notification urgentEmail = new EmailNotification("Server down!", "admin@test.com", new UrgentStrategy());
urgentEmail.Process();


Notification invalidEmail = new EmailNotification("Test", "noteanemail", new NormalSendStrategy());
invalidEmail.Process();

INotificationRepository repo = new NotificationRepository();
repo.Save(email);
repo.Save(sms);
repo.Save(urgentEmail);

Console.WriteLine("\n--- All Saved Notifications ---");
foreach (var n in repo.GetAll())
{
    Console.WriteLine($"To: {n.Recipient} | Message: {n.Message}");
}