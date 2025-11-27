using System;
using System.Collections.Generic;
using System.Threading; // додав для Thread.Sleep

class TaskItem
{
    public string Description { get; set; }
    public int Priority { get; set; }   // 1..5
    public bool IsDone { get; set; }

    public TaskItem(string description, int priority)
    {
        Description = description;
        Priority = priority;
        IsDone = false;
    }
}

class Program
{
    static List<TaskItem> tasks = new List<TaskItem>();

    static void Main()
    {
        ShowHeader();
        WaitForEnter();
        MenuLoop();
    }

    static void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("\t++===================================================++");
        Console.WriteLine("\t||              Лабраторна робота 2                  ||");
        Console.WriteLine("\t++---------------------------------------------------++");
        Console.WriteLine("\t||        створюємо (To-Do) разом з Едосiком         ||");
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

    static void MenuLoop()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("===== Список справ (To-Do) =====");
            Console.WriteLine("1 - Додати завдання");
            Console.WriteLine("2 - Показати всi завдання");
            Console.WriteLine("3 - Показати тiльки невиконанi");
            Console.WriteLine("4 - Вiдмiтити завдання як виконане");
            Console.WriteLine("5 - Видалити завдання");
            Console.WriteLine("0 - Вихiд");
            Console.WriteLine();

            Console.Write("Ваш вибiр: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ShowAllTasks();
                    break;
                case "3":
                    ShowPendingTasks();
                    break;
                case "4":
                    MarkTaskDone();
                    break;
                case "5":
                    RemoveTask();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Помилка: невiрний пункт меню.");
                    Pause();
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("До побачення! Гарного дня :)");
    }

    static void AddTask()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Додати завдання ===");
            Console.WriteLine("0 - Назад у головне меню");
            Console.WriteLine();

            Console.Write("Введiть опис завдання: ");
            string description = Console.ReadLine();
            if (description == "0") return;

            bool success = false;
            int priority = 0;

            while (!success)
            {
                Console.WriteLine();
                Console.Write("Введiть прiоритет (1-5) або 0 для повернення: ");
                string priorityString = Console.ReadLine();
                if (priorityString == "0") return;

                success = int.TryParse(priorityString, out priority);

                if (!success || priority < 1 || priority > 5)
                {
                    success = false;
                    Console.Clear();
                    Console.WriteLine("Помилка: потрiбно ввести цiле число в дiапазонi 1-5.");
                    Console.WriteLine("Спробуйте ще раз.");
                    Console.WriteLine();
                }
            }

            try
            {
                TaskItem task = new TaskItem(description, priority);
                tasks.Add(task);
                Console.Clear();
                Console.WriteLine("Завдання успiшно додано!");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Сталася помилка при додаваннi завдання:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Операцiю додавання завершено (finally).");
            }

            Pause();
            return;
        }
    }

    static void ShowAllTasks()
    {
        Console.Clear();
        Console.WriteLine("=== Вci завдання ===");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Список порожнiй.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                TaskItem t = tasks[i];
                string status = t.IsDone ? "[OK]" : "[  ]";
                Console.WriteLine($"{i + 1}. {status} (прiоритет {t.Priority}) - {t.Description}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("0 - Назад у головне меню");
        Console.ReadLine();
    }

    static void ShowPendingTasks()
    {
        Console.Clear();
        Console.WriteLine("=== Невиконанi завдання ===");

        bool any = false;
        for (int i = 0; i < tasks.Count; i++)
        {
            TaskItem t = tasks[i];
            if (!t.IsDone)
            {
                any = true;
                Console.WriteLine($"{i + 1}. (прiоритет {t.Priority}) - {t.Description}");
            }
        }

        if (!any)
        {
            Console.WriteLine("Всi завдання вже виконано, молодець!");
        }

        Console.WriteLine();
        Console.WriteLine("0 - Назад у головне меню");
        Console.ReadLine();
    }

    static void MarkTaskDone()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Вiдмiтити завдання як виконане ===");
            Console.WriteLine("0 - Назад у головне меню");
            Console.WriteLine();

            if (tasks.Count == 0)
            {
                Console.WriteLine("Список порожнiй, немає що вiдмiчати.");
                Pause();
                return;
            }

            ShowTasksShort();
            Console.WriteLine();

            bool success = false;
            int number = 0;

            while (!success)
            {
                Console.Write("Введiть номер завдання або 0 для виходу: ");
                string numberString = Console.ReadLine();

                if (numberString == "0") return;

                success = int.TryParse(numberString, out number);

                if (!success || number < 1 || number > tasks.Count)
                {
                    success = false;
                    Console.Clear();
                    ShowTasksShort();
                    Console.WriteLine();
                    Console.WriteLine("Помилка: введiть коректний номер завдання.");
                    Console.WriteLine("Спробуйте ще раз.");
                    Console.WriteLine();
                }
            }

            try
            {
                Console.Clear();
                tasks[number - 1].IsDone = true;
                Console.WriteLine("Завдання позначено як виконане!");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Помилка:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Операцiю завершено (finally).");
            }

            Pause();
            return;
        }
    }

    static void RemoveTask()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Видалити завдання ===");
            Console.WriteLine("0 - Назад у головне меню");
            Console.WriteLine();

            if (tasks.Count == 0)
            {
                Console.WriteLine("Список порожнiй, немає що видаляти.");
                Pause();
                return;
            }

            ShowTasksShort();
            Console.WriteLine();

            bool success = false;
            int number = 0;

            while (!success)
            {
                Console.Write("Введiть номер завдання або 0 для виходу: ");
                string numberString = Console.ReadLine();
                if (numberString == "0") return;

                success = int.TryParse(numberString, out number);

                if (!success || number < 1 || number > tasks.Count)
                {
                    success = false;
                    Console.Clear();
                    ShowTasksShort();
                    Console.WriteLine();
                    Console.WriteLine("Помилка: потрiбно ввести iснуючий номер завдання.");
                    Console.WriteLine("Спробуйте ще раз.");
                    Console.WriteLine();
                }
            }

            try
            {
                Console.Clear();
                tasks.RemoveAt(number - 1);
                Console.WriteLine("Завдання успiшно видалено!");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Помилка:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Операцiю видалення завершено (finally).");
            }

            Pause();
            return;
        }
    }

    static void ShowTasksShort()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            TaskItem t = tasks[i];
            string status = t.IsDone ? "[OK]" : "[  ]";
            Console.WriteLine($"{i + 1}. {status} - {t.Description}");
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Нaтиснiть ENTER, щоб продовжити...");
        Console.ReadLine();
    }
}
