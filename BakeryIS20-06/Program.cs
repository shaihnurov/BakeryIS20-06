using System;

namespace BakeryIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Информация о выпечке";

            Console.WriteLine("Программа для вывода информации о выпечке");
            try
            {
                View.Console myConsole = new View.Console("bakery.bin");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
