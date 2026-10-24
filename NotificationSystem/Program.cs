using NotificationSystem.Factories;
using NotificationSystem.Mediators;
using NotificationSystem.Models;
using NotificationSystem.Repositories;
using System;
using System.Security.Cryptography;
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

Console.WriteLine("\n--Prototype Pattern Test ---");
Notification original = new EmailNotification("Weekly newsletter","first@test.com", new NormalSendStrategy());

Notification copy1 = original.Clone();
copy1.Recipient = "second@test.com";

Notification copy2 = original.Clone();
copy2.Recipient = "third@test.com";

original.Process();
copy1.Process();
copy2.Process();

Console.WriteLine($"Same Object? {ReferenceEquals(original, copy1)}");

Console.WriteLine("\n--Memento Pattern Test ---");
Notification draft = new EmailNotification("Draft v1","draft@test.com", new NormalSendStrategy());
NotificationHistory history = new NotificationHistory();

history.Push(draft.Save());
draft.Message = "Draft v2";

history.Push(draft.Save());
draft.Message = "Draft v3 (wrong edit)";
Console.WriteLine($"Current : {draft.Message}");

draft.Restore(history.Pop());
Console.WriteLine($"After undo: {draft.Message}");

draft.Restore(history.Pop());
Console.WriteLine($"After second undo: {draft.Message}");


Console.WriteLine("\n--Iterator Pattern Test ---");
NotificationCollection collection = new NotificationCollection();
collection.Add(email);
collection.Add(sms);
collection.Add(urgentEmail);

Console.WriteLine("All Notifications:");
foreach(var n in collection)
{
    Console.WriteLine($" {n.Recipient}");
}

Console.WriteLine("Only Emails:");
foreach(var n in collection.onlyEmails())
{
    Console.WriteLine($" {n.Recipient}");
}

Console.WriteLine("\n--Mediator Pattern Test ---");
INotificationMediator mediator = new NotificationMediator(new NotificationRepository(), new LogRepository());

mediator.Dispatch(new EmailNotification("Welcome", "new@test.com", new NormalSendStrategy()));
mediator.Dispatch(new EmailNotification("Bad","invalid", new NormalSendStrategy()));

Console.WriteLine("\n--- Factory Method Test ---");
NotificationCreator emailCreator = new EmailCreator();
emailCreator.Notify("Welcome mail","user@test.com");

NotificationCreator smsCreator = new SmsCreator();
smsCreator.Notify("OTP 4321", "9876543210");

NotificationCreator urgentCreator = new UrgentEmailCreator();
urgentCreator.Notify("Server down", "admin@test.com"); 