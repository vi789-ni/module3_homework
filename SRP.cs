using System;

namespace SRP
{

    public class Order
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class PriceCalculator
    {
        public double CalculateTotalPrice(Order order)
        {
            return order.Quantity * order.Price * 0.9; 
        }
    }

    public class PaymentProcessor
    {
        public void ProcessPayment(string paymentDetails, double amount)
        {
            Console.WriteLine($"Оплата {amount}$ прошла через: {paymentDetails}");
        }
    }

    public class NotificationService
    {
        public void SendConfirmation(string email)
        {
            Console.WriteLine($"Подтверждение отправлено на: {email}");
        }
    }

    class Program
    {
        static void Main()
        {
            var order = new Order();

            Console.Write("Введите название товара: ");
            order.ProductName = Console.ReadLine();

            Console.Write("Введите количество: ");
            order.Quantity = int.Parse(Console.ReadLine());

            Console.Write("Введите цену за единицу: ");
            order.Price = double.Parse(Console.ReadLine());

            var calculator = new PriceCalculator();
            double total = calculator.CalculateTotalPrice(order);

            Console.WriteLine($"Итого к оплате: {total}$");

            Console.Write("Введите способ оплаты (например, 'Карта'): ");
            string payment = Console.ReadLine();

            var paymentProcessor = new PaymentProcessor();
            paymentProcessor.ProcessPayment(payment, total);

            Console.Write("Введите email для подтверждения: ");
            string email = Console.ReadLine();

            var notifier = new NotificationService();
            notifier.SendConfirmation(email);
        }
    }
}
