using System;

namespace DIP
{
    public interface INotificationSender
    {
        void Send(string message);
    }

    public class EmailSender : INotificationSender
    {
        public void Send(string message) => Console.WriteLine("Email отправлен: " + message);
    }

    public class SmsSender : INotificationSender
    {
        public void Send(string message) => Console.WriteLine("SMS отправлено: " + message);
    }

    public class NotificationService
    {
        private readonly INotificationSender _sender;

        public NotificationService(INotificationSender sender)
        {
            _sender = sender;
        }

        public void SendNotification(string message)
        {
            _sender.Send(message);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Выберите способ уведомления (1 - Email, 2 - SMS): ");
            string choice = Console.ReadLine();

            INotificationSender sender = choice == "2" ? new SmsSender() : new EmailSender();

            var service = new NotificationService(sender);

            Console.Write("Введите сообщение: ");
            string msg = Console.ReadLine();

            service.SendNotification(msg);
        }
    }
}
