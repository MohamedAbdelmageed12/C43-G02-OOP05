using System;

namespace Assignment5OOP
{
    #region Q1: IShape, ICircle, and IRectangle Interfaces with Implementations
    interface IShape
    {
        double Area { get; }
        void DisplayShapeInfo();
    }

    interface ICircle : IShape
    {
        double Radius { get; set; }
    }

    interface IRectangle : IShape
    {
        double Width { get; set; }
        double Height { get; set; }
    }

    class Circle : ICircle
    {
        public double Radius { get; set; }

        public double Area => Math.PI * Radius * Radius;

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Circle: Radius = {Radius}, Area = {Area:F2}");
        }
    }

    class Rectangle : IRectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double Area => Width * Height;

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Rectangle: Width = {Width}, Height = {Height}, Area = {Area:F2}");
        }
    }
    #endregion

    #region Q2: Authentication Service Implementation
    interface IAuthenticationService
    {
        bool AuthenticateUser(string username, string password);
        bool AuthorizeUser(string username, string role);
    }

    class BasicAuthenticationService : IAuthenticationService
    {
        private readonly string validUsername = "admin";
        private readonly string validPassword = "password";
        private readonly string validRole = "admin";

        public bool AuthenticateUser(string username, string password)
        {
            return username == validUsername && password == validPassword;
        }

        public bool AuthorizeUser(string username, string role)
        {
            return username == validUsername && role == validRole;
        }
    }
    #endregion

    #region Q3: Notification Service Implementation
    interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Email sent to {recipient}: {message}");
        }
    }

    class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"SMS sent to {recipient}: {message}");
        }
    }

    class PushNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Push notification sent to {recipient}: {message}");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region Q1: Testing Shape Interfaces
            ICircle circle = new Circle { Radius = 5 };
            IRectangle rectangle = new Rectangle { Width = 4, Height = 7 };

            circle.DisplayShapeInfo();
            rectangle.DisplayShapeInfo();
            #endregion

            #region Q2: Testing Authentication Service
            IAuthenticationService authService = new BasicAuthenticationService();

            Console.WriteLine("\nAuthentication and Authorization Testing:");
            bool isAuthenticated = authService.AuthenticateUser("admin", "password");
            Console.WriteLine($"User authenticated: {isAuthenticated}");

            bool isAuthorized = authService.AuthorizeUser("admin", "admin");
            Console.WriteLine($"User authorized: {isAuthorized}");
            #endregion

            #region Q3: Testing Notification Services
            INotificationService emailService = new EmailNotificationService();
            INotificationService smsService = new SmsNotificationService();
            INotificationService pushService = new PushNotificationService();

            Console.WriteLine("\nNotification Service Testing:");
            emailService.SendNotification("user@example.com", "Welcome to the platform!");
            smsService.SendNotification("123-456-7890", "Your OTP is 1234");
            pushService.SendNotification("User123", "You have a new message!");
            #endregion
        }
    }
}
