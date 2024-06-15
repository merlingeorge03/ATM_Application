using System;

namespace ATM_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================= WELCOME TO ATM APPLICATION =========================================");
            AtmApplication app = new AtmApplication();
            app.displayMainMenu();
        }
    }
}
