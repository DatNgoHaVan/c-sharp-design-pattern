namespace BehavioralPatterns.Strategy.Problem
{
    // Let's say we have a NotificationService class that sends 
    // notifications via email, SMS, and push notification
    // The SendNotification method has a type parameter to specify the type of notification
    public class NotificationService
    {
        // The SendNotification method sends a notification based on the type
        // This method is not flexible, if we want to add a new type of notification because we need to modify this method
        // This violates the Open/Closed Principle because this class is not open for extension but closed for modification
        // and Single Responsibility Principle because this class has more than one reason to change and it has more than one responsibility
        // This class is not following the Strategy DP because it doesn't have a common interface for all notification types
        public void SendNotification(string message, string type)
        {
            if (type == "email")
            {
                System.Console.WriteLine("Send email: " + message);
            }
            else if (type == "sms")
            {
                System.Console.WriteLine("Send SMS: " + message);
            }
            else if (type == "push")
            {
                System.Console.WriteLine("Send push notification: " + message);
            }
        }
    }

    public class main
    {
        static void Main(string[] args)
        {
            var notificationService = new NotificationService();
            notificationService.SendNotification("Hello world via email", "email");
            notificationService.SendNotification("Hello world via SMS", "sms");
            notificationService.SendNotification("Hello world via push notification", "push");
        }
    }
}