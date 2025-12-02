using System;
using System.Collections.Generic;
using System.Threading;

namespace RpgLab
{
    class Program
    {
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
            Console.WriteLine("\t||               Лабораторная работа 3               ||");
            Console.WriteLine("\t++---------------------------------------------------++");
            Console.WriteLine("\t||      RPG-битва (ООП: наследование, интерфейсы)    ||");
            Console.WriteLine("\t++===================================================++");
            Console.WriteLine();
        }

        static void WaitForEnter()
        {
            string text = "Нажмите ENTER, чтобы продолжить";
            Console.WriteLine(text);

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine("Пожалуйста, нажмите только клавишу ENTER, чтобы начать...");
                }
            } while (key.Key != ConsoleKey.Enter);

            int lineTop = Console.CursorTop - 1;
            Thread.Sleep(300);

            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(0, lineTop);
                string visible = new string(' ', i + 1) + text.Substring(i + 1);
                Console.Write(visible);
                Thread.Sleep(40);
            }

            Console.SetCursorPosition(0, lineTop + 1);
        }

        // ────────────────────────────────────────────────
        // MAIN MENU
        // ────────────────────────────────────────────────

        static void MenuLoop()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("===== ГЛАВНОЕ МЕНЮ =====");
                Console.WriteLine("1 - Начать битву");
                Console.WriteLine("0 - Выход");
                Console.WriteLine();
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartBattle();
                        break;
                    case "0":
                        running = false;
                        Console.Clear();
                        Console.WriteLine("До встречи! Хорошего дня :)");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка: неверный пункт меню. Попробуйте снова.");
                        Thread.Sleep(1200);
                        break;
                }
            }
        }

        // ────────────────────────────────────────────────
        // BATTLE LOGIC
        // ────────────────────────────────────────────────

        static void StartBattle()
        {
            Console.Clear();

            // создаем доступных персонажей
            List<Character> allCharacters = new List<Character>
            {
                new Warrior("Thorin", 120, 20),
                new Mage("Gandalf", 80, 50, 25),
                new Archer("Legolas", 90, 18, 0.3)
            };

            Console.WriteLine("===== RPG БИТВА =====\n");
            Console.WriteLine("Доступные персонажи:");
            for (int i = 0; i < allCharacters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allCharacters[i]}");
            }

            Console.WriteLine();

            // выбор бойцов
            Character fighter1 = ChooseCharacter(allCharacters, "Выберите первого бойца (введите номер): ");
            Character fighter2;

            while (true)
            {
                fighter2 = ChooseCharacter(allCharacters, "Выберите второго бойца (введите номер): ");
                if (!ReferenceEquals(fighter1, fighter2))
                    break;
                Console.WriteLine("Нельзя выбрать одного и того же персонажа дважды. Попробуйте другого.");
            }

            Console.Clear();
            Console.WriteLine($"{fighter1.Name} VS {fighter2.Name}");
            Console.WriteLine("Битва начинается!");
            Console.WriteLine("--------------------------------------");

            Character current = fighter1;
            Character other = fighter2;

            while (fighter1.IsAlive && fighter2.IsAlive)
            {
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("===== ХОД БИТВЫ =====");
                Console.WriteLine($"Ходит: {current.Name}");
                Console.WriteLine($"Противник: {other.Name}");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Меню действий:");
                Console.WriteLine("0 - Пропустить ход");
                Console.WriteLine("1 - Атака");
                Console.WriteLine("2 - Защита");
                Console.Write("Ваш выбор: ");

                int choice = ReadIntFromConsole(0, 2);

                Console.Clear();

                switch (choice)
                {
                    case 0:
                        Console.WriteLine($"{current.Name} пропускает ход.");
                        break;
                    case 1:
                        if (current is IAttackable attacker)
                            attacker.Attack(other);
                        else
                            Console.WriteLine($"{current.Name} не может атаковать.");
                        break;
                    case 2:
                        current.Defend();
                        break;
                }

                if (!other.IsAlive || !current.IsAlive)
                    break;

                Thread.Sleep(1000);

                // меняем ход
                Character temp = current;
                current = other;
                other = temp;
            }

            Console.WriteLine();
            Console.WriteLine("=== Битва завершена ===");
            Console.WriteLine(fighter1);
            Console.WriteLine(fighter2);
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }

        // ────────────────────────────────────────────────
        // HELPERS
        // ────────────────────────────────────────────────

        static Character ChooseCharacter(List<Character> characters, string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                int index = ReadIntFromConsole(1, characters.Count);
                return characters[index - 1];
            }
        }

        static int ReadIntFromConsole(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    if (value >= min && value <= max)
                        return value;
                }

                Console.Clear();
                Console.WriteLine($"Ошибка ввода! Введите число от {min} до {max}: ");
            }
        }
    }
}