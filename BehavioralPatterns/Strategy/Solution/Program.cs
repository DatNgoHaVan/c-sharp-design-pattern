using System;

namespace NotificationServiceExample
{
    // The INotifier interface is a common interface for all notification types
    // It follows the Strategy DP
    // This interface is open for extension but closed for modification
    // This interface has only one reason to change and only one responsibility
    interface INotifier
    {
        void Send(string message);
    }

    // The EmailNotifier class is a concrete implementation of the INotifier interface
    // This will handle business logic to send an email notification
    class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending message: {message} (Sender: Email)");
        }
    }

    class SMSNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending message: {message} (Sender: SMS)");
        }
    }

    class PushNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending message: {message} (Sender: Push)");
        }
    }

    // The NotificationService class is a client class that uses the INotifier interface
    // Why we not use inheritance here? because we want to use composition over inheritance (has-a relationship)
    // Why we use composition over inheritance? Because we want to change the behavior at runtime, and we can use multiple inheritance
    // Imagine in real-world scenario, we have a lot of changes in the notification service, we can use multiple inheritance to handle that
    class NotificationService
    {
        private INotifier _notifier;

        public NotificationService(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void SendNotification(string message)
        {
            _notifier.Send(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            var emailService = new NotificationService(emailNotifier);
            var smsService = new NotificationService(smsNotifier);
            var pushService = new NotificationService(pushNotifier);

            emailService.SendNotification("Hello world and Strategy DP via email");
            smsService.SendNotification("Hello world and Strategy DP via SMS");
            pushService.SendNotification("Hello world and Strategy DP via push notification");
        }
    }
}
