using NotificationSystem.Factories;
using NotificationSystem.Models;
Notification email = NotificationFactory.Create("email", "Hello there!", "gaurav@test.com");
email.Send();

Notification sms = NotificationFactory.Create("sms", "OTP is 1234", "9876543210");
sms.Send();


Console.WriteLine("Program is Started");
Console.WriteLine(TemplateProvider.GetTemplate("welcome"));
Console.WriteLine(TemplateProvider.GetTemplate("otp"));