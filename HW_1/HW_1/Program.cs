using System;
using System.Threading;

class Program
{
    static void Main()
    {
        ShowHeader();
        WaitForEnter();
        Console.Clear();

        
        string name = "Кулага Едуард Вячеславович";
        int age = 24;
        string group = "КН-23";
        bool wasAtClass = true;  

     
        Console.WriteLine($"Привiт група. Мене звати {name}. Менi {age} роки. Я навчаюся в групi {group}. Я був на парi в цей четвер: {wasAtClass}.");

        Console.WriteLine();
        Console.WriteLine("Нaтиснiть будь-яку клавiшу, щоб вийти...");
        Console.ReadKey();
    }

    static void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("\t++===================================================++");
        Console.WriteLine("\t||                 Домашня робота 1                  ||");
        Console.WriteLine("\t++---------------------------------------------------++");
        Console.WriteLine("\t||         Звiт про присутнiсть вiд Едосiка          ||");
        Console.WriteLine("\t++===================================================++");
        Console.WriteLine();
    }

    static void WaitForEnter()
    {
        string text = "Нaтиснiть ENTER, щоб продовжити";
        Console.WriteLine(text);

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
        } while (key.Key != ConsoleKey.Enter);

        int lineTop = Console.CursorTop - 1;

        Thread.Sleep(200);

        for (int i = 0; i < text.Length; i++)
        {
            Console.SetCursorPosition(0, lineTop);
            string visible = new string(' ', i + 1) + text.Substring(i + 1);
            Console.Write(visible);
            Thread.Sleep(100);
        }

        Console.SetCursorPosition(0, lineTop + 1);
    }
}