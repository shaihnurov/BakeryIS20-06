using System;

namespace BakeryIS.View
{
    internal class Console
    {

        private adminbakery.adbakery bakerys;

        public Console(string path)
        {
            try
            {
                bakerys = new adminbakery.adbakery(path);
                consolepusk();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private void consolem()
        {
            System.Console.WriteLine("commands - список команд");
            System.Console.WriteLine("listbakery - список выпечки");
            System.Console.WriteLine("addbakery - добавить новую выпечку");
            System.Console.WriteLine("exit - завершить сеанс");
        }

        public void consolepusk()
        {
            consolem();
            while (true)
            {
                try
                {
                    switch (Consolestart("Введите команду...").ToLower())
                    {
                        case "commands": consolem(); break;
                        case "listbakery": Listbakery(); break;
                        case "addbakery": AddBakery(); break;
                        case "exit": Environment.Exit(0); break;
                        default:
                            System.Console.WriteLine("неверная команда"); break;
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddBakery()
        {
            string name = Consolestart("Укажите название выпечки");
            string structure = Consolestart("Укажите состав выпечки");
            string calories = Consolestart("Укажите калорийность (например - \"200 ккал\")");
            string price = Consolestart("Укажите стоимость данной выпечки (например - \"130 рублей за 300 грамм\")");
            string time = Consolestart("Укажите время выпекания (например - \"40 минут 200градусов\")");
            bakerys.Add(name, structure, calories, price, time);
            System.Console.WriteLine("Выпечка успешно добавлена");
            Listbakery();
        }

        private void Listbakery()
        {
            if (bakerys.Bakerys.Count == 0)
            {
                System.Console.WriteLine("Информации о выпечки отсутствует");
                return;
            }

            foreach (var item in bakerys.Bakerys)
            {
                System.Console.WriteLine(item);
            }
        }

        private string Consolestart(string v)
        {
            System.Console.WriteLine(v);
            var s = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s))
            {
                System.Console.WriteLine("некоректный ввод");
                return Consolestart(v);
            }
            return s.TrimStart().TrimEnd();
        }
    }
}
