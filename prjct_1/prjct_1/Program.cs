using System;

class Program
{
    static void Main()
    {
        
        Console.WriteLine();
        Console.WriteLine("\t++===================================================++");
        Console.WriteLine("\t||              Лабрадорная робота 1                ||");
        Console.WriteLine("\t++---------------------------------------------------++");
        Console.WriteLine("\t||        читаємо книги разом з Едосiком            ||");
        Console.WriteLine("\t++===================================================++");
        Console.WriteLine();

        
        // === ОЖИДАНИЕ ENTER  ===
        Console.WriteLine("Натиснiть ENTER, щоб продовжити");
        ConsoleKeyInfo key = Console.ReadKey(true);

        while (key.Key != ConsoleKey.Enter)
        {
            Console.Clear();
            Console.WriteLine("Натиснiть ENTER, щоб продовжити");
            key = Console.ReadKey(true);
        }

        Console.Clear();
        
        Console.Write("Загрузка");
        Thread.Sleep(1000); 
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.WriteLine(".");

        Thread.Sleep(500);
        Console.Clear();
        
        Console.Write("Загрузка");
        Thread.Sleep(1000); // 1 секунда
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.WriteLine(".");

        Thread.Sleep(500);
        Console.Clear();
        
        Console.Write("Загрузка");
        Thread.Sleep(1000); // 1 секунда
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.WriteLine(".");

        Thread.Sleep(500);
        Console.Clear();



        
        while (true) // главный цикл библиотеки
        {
            ShowMenu();

            int number = 0;
            bool success = false;

            // цикл ввода, пока пользователь не введёт корректное число
            while (!success)
            {
                
                Console.WriteLine();
                Console.Write("Введiть номер твору: ");
                string numberString = Console.ReadLine();

                success = int.TryParse(numberString, out number);
                
                Console.Clear();
        
                Console.Write("Загрузка");
                Thread.Sleep(1000); 
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.WriteLine(".");

                Thread.Sleep(500);
                Console.Clear();
        
                Console.Write("Загрузка");
                Thread.Sleep(1000); // 1 секунда
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.WriteLine(".");

                Thread.Sleep(500);
                Console.Clear();
        
                Console.Write("Загрузка");
                Thread.Sleep(1000); // 1 секунда
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.WriteLine(".");

                Thread.Sleep(500);
                Console.Clear();

                if (!success)
                {
                    Console.Clear();
                    Console.WriteLine("Помилка: потрiбно ввести цiле число.");
                    Console.WriteLine("Спробуйте ще раз.");
                    Console.WriteLine();
                    
                    Console.WriteLine("=== Мiнi-бiблiотека — Новий список ===");
                    Console.WriteLine("1. Сергiй Жадан — «Тамплiєри» (уривок)");
                    Console.WriteLine("2. Юрiй Андрухович — «Самiйло» (уривок)");
                    Console.WriteLine("3. Ернест Гемiнґвей — «Старий i море» — анотацiя");
                    Console.WriteLine("4. Рей Бредберi — «451° за Фаренгейтом» — анотацiя");
                    Console.WriteLine("5. Вихiд");
                    
                }
            }

            // если пользователь выбрал выход → выходим из программы
            if (number == 5)
            {
                Console.Clear();
                Console.WriteLine("До побачення!");
                break;
            }

            Console.WriteLine();
            ShowWorkByNumber(number);

            Console.WriteLine();
            Console.WriteLine("Натиснiть Enter, щоб повернутися до списку книг...");
            Console.ReadLine();

            Console.Clear();
        
            Console.Write("Загрузка");
            Thread.Sleep(1000); 
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");

            Thread.Sleep(500);
            Console.Clear();
        
            Console.Write("Загрузка");
            Thread.Sleep(1000); // 1 секунда
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");

            Thread.Sleep(500);
            Console.Clear();
        
            Console.Write("Загрузка");
            Thread.Sleep(1000); // 1 секунда
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");

            Thread.Sleep(500);
            Console.Clear();
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Мiнi-бiблiотека — Новий список ===");
        Console.WriteLine("1. Сергiй Жадан — «Тамплiєри» (уривок)");
        Console.WriteLine("2. Юрiй Андрухович — «Самiйло» (уривок)");
        Console.WriteLine("3. Ернест Гемiнґвей — «Старий i море» — анотацiя");
        Console.WriteLine("4. Рей Бредберi — «451° за Фаренгейтом» — анотацiя");
        Console.WriteLine("5. Вихiд");
    }

    static void ShowWorkByNumber(int number)
    {
        switch (number)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Сергiй Жадан — «Тамплiєри» (уривок):");
                Console.WriteLine("I все, що ти знаєш про свiт — це його темнi столицi,");
                Console.WriteLine("I кожне повернення — це повернення пiсля облоги...");
                break;

            case 2:
                Console.Clear();
                Console.WriteLine("Юрiй Андрухович — «Самiйло» (уривок):");
                Console.WriteLine("Самiйло йшов крiзь нiч, немов крiзь власнi сни,");
                Console.WriteLine("Нiс у собi тишу i водночас — вiтри.");
                break;

            case 3:
                Console.Clear();
                Console.WriteLine("Ернест Гемiнґвей — «Старий i море» — коротка анотацiя:");
                Console.WriteLine("Повiсть про старого рибалку Сантьяго,");
                Console.WriteLine("який веде виснажливу боротьбу з великою рибою.");
                Console.WriteLine("Оповiдь про силу духу, самотнiсть i гiднiсть.");
                break;

            case 4:
                Console.Clear();
                Console.WriteLine("Рей Бредберi — «451° за Фаренгейтом» — анотацiя:");
                Console.WriteLine("Антиутопiя про суспiльство, де книги спалюють,");
                Console.WriteLine("а мислення — заборонено. Iсторiя пожежника,");
                Console.WriteLine("який раптом починає шукати сенс у забороненому.");
                break;

            default:
                Console.Clear();
                Console.WriteLine("Помилка: такого номера книги не iснує.");
                break;
        }
    }
}
