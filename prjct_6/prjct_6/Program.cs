using System;
using System.Threading;

namespace NullableLab
{
    class Program
    {
        static UserProfile profile = new UserProfile();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            LoadingAnimation();
            IntroDialogue();
            WaitForEnter();

            bool exit = false;
            while (!exit)
            {
                ShowHeader();
                ShowMenu();

                Console.Write("\tВаш вибiр: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowProfile();
                        WaitForEnter();
                        break;

                    case "2":
                        FillProfileQuick();
                        WaitForEnter();
                        break;

                    case "3":
                        FillSingleField();
                        WaitForEnter();
                        break;

                    case "4":
                        ClearSingleField();
                        WaitForEnter();
                        break;

                    case "5":
                        ClearAll();
                        WaitForEnter();
                        break;

                    case "6":
                        DemoSafeReading();
                        WaitForEnter();
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        TypeEffect("⚠ Невiдома команда. Спробуйте ще раз.");
                        WaitForEnter();
                        break;
                }
            }

            ShowHeader();
            TypeEffect("👋 Дякуємо! Лаба завершена.");
            TypeEffect("Натиснiть ENTER, щоб вийти.");
            Console.ReadLine();
        }

     

        static void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t++===================================================++");
            Console.WriteLine("\t||              Лабораторна робота: Nullable         ||");
            Console.WriteLine("\t++---------------------------------------------------++");
            Console.WriteLine("\t||   Анкета користувача: null до/пiсля присвоєння    ||");
            Console.WriteLine("\t++===================================================++");
            Console.WriteLine();
        }

        static void ShowMenu()
        {
            Console.WriteLine("\t1. Показати анкету (вивiд всiх полiв)");
            Console.WriteLine("\t2. Швидко заповнити анкету (demo)");
            Console.WriteLine("\t3. Заповнити одне поле вручну");
            Console.WriteLine("\t4. Очистити одне поле (зробити null)");
            Console.WriteLine("\t5. Очистити всю анкету (все null)");
            Console.WriteLine("\t6. Demo: безпечне читання (HasValue, ??, switch)");
            Console.WriteLine();
            Console.WriteLine("\t0. Вихiд");
            Console.WriteLine();
        }

        static void LoadingAnimation()
        {
            Console.Clear();
            Console.Write("Запуск системи");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(350);
                Console.Write(".");
            }
            Console.WriteLine("\nГотово!");
            Thread.Sleep(600);
        }

        static void IntroDialogue()
        {
            Console.Clear();
            TypeEffect("👋 Привiт! Я Едосiк (ну майже).");
            Thread.Sleep(350);
            TypeEffect("✨ Сьогоднi тренуємо nullable-поля: як виводити null i значення.");
            Thread.Sleep(450);
        }

        static void TypeEffect(string text, int delay = 35)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        static void WaitForEnter()
        {
            TypeEffect("Натиснiть ENTER, щоб продовжити");
            ConsoleKeyInfo key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Натиснiть ENTER, щоб продовжити");
                key = Console.ReadKey(true);
            }
        }

       

        static void ShowProfile()
        {
            ShowHeader();
            profile.Print("📄 Поточний стан анкети");
        }

        static void FillProfileQuick()
        {
            ShowHeader();
            TypeEffect("➕ Швидке заповнення анкети (demo)...");
            Thread.Sleep(200);

            profile.Age = 19;
            profile.BirthDate = new DateTime(2006, 3, 14);
            profile.Email = "student@uni.edu";
            profile.Phone = "+380501234567";
            profile.IsStudent = true;

            TypeEffect("✅ Готово! Данi присвоєно.");
            Console.WriteLine();
            profile.Print("📄 Анкета пiсля заповнення");
        }

        static void FillSingleField()
        {
            ShowHeader();
            TypeEffect("✍ Заповнення одного поля\n");

            PrintFieldMenu();
            Console.Write("\tОберiть поле (1-5): ");
            int field = ReadIntSafe();

            switch (field)
            {
                case 1:
                    Console.Write("\tВведiть Age (цiле число): ");
                    profile.Age = ReadIntSafe();
                    TypeEffect("✅ Age присвоєно.");
                    break;

                case 2:
                    Console.Write("\tВведiть BirthDate (yyyy-mm-dd): ");
                    profile.BirthDate = ReadDateSafe();
                    TypeEffect("✅ BirthDate присвоєно.");
                    break;

                case 3:
                    Console.Write("\tВведiть Email: ");
                    profile.Email = Console.ReadLine();
                    TypeEffect("✅ Email присвоєно.");
                    break;

                case 4:
                    Console.Write("\tВведiть Phone: ");
                    profile.Phone = Console.ReadLine();
                    TypeEffect("✅ Phone присвоєно.");
                    break;

                case 5:
                    Console.Write("\tIsStudent (y/n): ");
                    profile.IsStudent = ReadBoolNullableSafe();
                    TypeEffect("✅ IsStudent присвоєно.");
                    break;

                default:
                    TypeEffect("⚠ Невiрний номер поля.");
                    break;
            }

            Console.WriteLine();
            profile.Print("📄 Анкета пiсля змiни поля");
        }

        static void ClearSingleField()
        {
            ShowHeader();
            TypeEffect("🧹 Очистити одне поле (зробити null)\n");

            PrintFieldMenu();
            Console.Write("\tОберiть поле для очищення (1-5): ");
            int field = ReadIntSafe();

            switch (field)
            {
                case 1: profile.Age = null; TypeEffect("✅ Age = null"); break;
                case 2: profile.BirthDate = null; TypeEffect("✅ BirthDate = null"); break;
                case 3: profile.Email = null; TypeEffect("✅ Email = null"); break;
                case 4: profile.Phone = null; TypeEffect("✅ Phone = null"); break;
                case 5: profile.IsStudent = null; TypeEffect("✅ IsStudent = null"); break;
                default: TypeEffect("⚠ Невiрний номер поля."); break;
            }

            Console.WriteLine();
            profile.Print("📄 Анкета пiсля очищення поля");
        }

        static void ClearAll()
        {
            ShowHeader();
            profile.ClearAll();
            TypeEffect("✅ Всi поля очищено (все стало null).");
            Console.WriteLine();
            profile.Print("📄 Анкета пiсля повного очищення");
        }

        static void DemoSafeReading()
        {
            ShowHeader();
            TypeEffect("🧪 Demo: безпечне читання nullable-полiв\n");

            // Age: ??
            int safeAge = profile.Age ?? 0;
            TypeEffect($"Age ?? 0  => {safeAge}");

            // BirthDate: HasValue
            if (profile.BirthDate.HasValue)
                TypeEffect($"BirthDate.HasValue => так, дата: {profile.BirthDate.Value:yyyy-MM-dd}");
            else
                TypeEffect("BirthDate.HasValue => нi (null)");

            // Email: ??
            string safeEmail = profile.Email ?? "немає email";
            TypeEffect($"Email ?? \"немає email\" => {safeEmail}");

            // bool? через switch
            string studentText = profile.IsStudent switch
            {
                true => "студент: так",
                false => "студент: нi",
                null => "студент: <null>"
            };
            TypeEffect(studentText);

            Console.WriteLine();
            profile.Print("📄 Поточний стан анкети (для порiвняння)");
        }

        static void PrintFieldMenu()
        {
            Console.WriteLine("\t1) Age (int?)");
            Console.WriteLine("\t2) BirthDate (DateTime?)");
            Console.WriteLine("\t3) Email (string?)");
            Console.WriteLine("\t4) Phone (string?)");
            Console.WriteLine("\t5) IsStudent (bool?)");
            Console.WriteLine();
        }

      

        static int ReadIntSafe()
        {
            int value;
            string input = Console.ReadLine();

            while (!int.TryParse(input, out value))
            {
                Console.Write("\tВведiть цiле число: ");
                input = Console.ReadLine();
            }

            return value;
        }

        static DateTime ReadDateSafe()
        {
            DateTime value;
            string input = Console.ReadLine();

            while (!DateTime.TryParse(input, out value))
            {
                Console.Write("\tНевiрний формат. Введiть дату (yyyy-mm-dd): ");
                input = Console.ReadLine();
            }

            return value;
        }

      
        static bool? ReadBoolNullableSafe()
        {
            while (true)
            {
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                    return null;

                if (input == "y" || input == "yes" || input == "так" || input == "t" || input == "true")
                    return true;

                if (input == "n" || input == "no" || input == "нi" || input == "ні" || input == "f" || input == "false")
                    return false;

                Console.Write("\tВведiть y / n (або просто Enter = null): ");
            }
        }
    }
}
