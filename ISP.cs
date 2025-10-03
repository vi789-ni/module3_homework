using System;

namespace ISP
{
    public interface IPrinter
    {
        void Print(string content);
    }

    public interface IScanner
    {
        void Scan(string content);
    }

    public interface IFax
    {
        void Fax(string content);
    }

    public class AllInOnePrinter : IPrinter, IScanner, IFax
    {
        public void Print(string content) => Console.WriteLine("Печать: " + content);
        public void Scan(string content) => Console.WriteLine("Сканирование: " + content);
        public void Fax(string content) => Console.WriteLine("Факс: " + content);
    }

    public class BasicPrinter : IPrinter
    {
        public void Print(string content) => Console.WriteLine("Печать: " + content);
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Выберите принтер (1 - AllInOne, 2 - Basic): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var printer = new AllInOnePrinter();
                printer.Print("Документ");
                printer.Scan("Документ");
                printer.Fax("Документ");
            }
            else
            {
                var printer = new BasicPrinter();
                printer.Print("Документ");
            }
        }
    }
}


    public interface INotificationSender
