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

Notification smsViaGateway = new SmsNotification("Delivery Update", "9876543210", new SmsGatewayAdapter());
smsViaGateway.Process();

INotificationRepository repo = new NotificationRepository();
repo.Save(email);
repo.Save(sms);
repo.Save(urgentEmail);

Console.WriteLine("\n--- All Saved Notifications ---");
foreach (var n in repo.GetAll())
{
    Console.WriteLine($"To: {n.Recipient} | Message: {n.Message}");
}

Console.WriteLine("\n--Unit of Work Test ---");
IUnitOfWork uow = new UnitOfWork();

uow.AddNotification(email);
uow.AddLog("Email is sent to gaurav@test.com");
uow.Commit();

uow.AddNotification(sms);
uow.AddLog("SMS sent to 9876543210");
uow.Rollback();

Console.WriteLine($"Notification saved: {uow.Notification.GetAll().Count}");
Console.WriteLine($"Logs saved: {uow.Logs.GetAll().Count}");


Console.WriteLine("\n--Decorator Pattern Test ---");

Notification retryEmail = new EmailNotification("Payment received","gaurav@test.com", new RetryDecorator(new FlakySendStrategy()));
retryEmail.Process();


Console.WriteLine("\n--Null Object Test ---");
Notification unknown = NotificationFactory.Create("whatsapp","HI", "9876543210", new NullSendStrategy());
unknown.Process();
Console.WriteLine("Program continued safely");