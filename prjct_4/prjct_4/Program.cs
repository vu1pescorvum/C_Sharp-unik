// File: Program.cs
using System;
using System.Threading;

namespace MagicAcademyLab
{
    class Program
    {

        static Repository<Spell> spellRepo = new Repository<Spell>();
        static Repository<Mage> mageRepo = new Repository<Mage>();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            LoadingAnimation();
            IntroDialogue();
            WaitForEnter();

            SeedData(); 

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
                        ShowAllSpells();
                        WaitForEnter();
                        break;
                    case "2":
                        AddSpell();
                        WaitForEnter();
                        break;
                    case "3":
                        RemoveSpell();
                        WaitForEnter();
                        break;
                    case "4":
                        ShowAllMages();
                        WaitForEnter();
                        break;
                    case "5":
                        AddMage();
                        WaitForEnter();
                        break;
                    case "6":
                        RemoveMage();
                        WaitForEnter();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        TypeEffect("Невiдома команда. Спробуйте ще раз.");
                        WaitForEnter();
                        break;
                }
            }

            ShowHeader();
            TypeEffect("👋 Дякуємо за роботу в магiчнiй академiї!");
            TypeEffect("Натиснiть ENTER, щоб вийти.");
            Console.ReadLine();
        }


        static void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t++===================================================++");
            Console.WriteLine("\t||              Лабраторна робота 4                  ||");
            Console.WriteLine("\t++---------------------------------------------------++");
            Console.WriteLine("\t||        Працюємо  разом з Едосiком                 ||");
            Console.WriteLine("\t++===================================================++");
            Console.WriteLine();
        }

        static void LoadingAnimation()
        {
            Console.Clear();
            Console.Write("Запуск системи");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine("\nГотово!");
            Thread.Sleep(800);
        }

        static void IntroDialogue()
        {
            Console.Clear();
            TypeEffect("👋 Привiт, я Едосiк, твiй консольний помiчник!");
            Thread.Sleep(500);
            TypeEffect("🔧 Готую систему до запуску...");
            Thread.Sleep(700);

        }

        static void TypeEffect(string text, int delay = 50)
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

    
        static void ShowMenu()
        {
            Console.WriteLine("\t1. Показати всi закляття");
            Console.WriteLine("\t2. Додати нове закляття");
            Console.WriteLine("\t3. Видалити закляття");
            Console.WriteLine();
            Console.WriteLine("\t4. Показати всiх магiв");
            Console.WriteLine("\t5. Додати нового мага");
            Console.WriteLine("\t6. Видалити мага");
            Console.WriteLine();
            Console.WriteLine("\t0. Вихiд");
            Console.WriteLine();
        }

    
        static void SeedData()
        {
            spellRepo.Add(new Spell
            {
                Name = "Вогняна куля",
                Element = "Вогонь",
                ManaCost = 25,
                LevelRequired = 2
            });

            spellRepo.Add(new Spell
            {
                Name = "Крижаний спис",
                Element = "Лiд",
                ManaCost = 30,
                LevelRequired = 3
            });

            mageRepo.Add(new Mage
            {
                Name = "Артемiс",
                Rank = "Адепт",
                Specialization = "Бойова магiя"
            });

            mageRepo.Add(new Mage
            {
                Name = "Лiсса",
                Rank = "Учень",
                Specialization = "Зелена магiя"
            });
        }


        static void ShowAllSpells()
        {
            ShowHeader();
            Console.WriteLine("\t📜 Каталог заклять:\n");

            var spells = spellRepo.GetAll();
            if (spells.Count == 0)
            {
                Console.WriteLine("\t(Поки що немає жодного закляття)");
                return;
            }

            for (int i = 0; i < spells.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {spells[i]}");
            }
        }

        static void AddSpell()
        {
            ShowHeader();
            Console.WriteLine("\t➕ Додавання нового закляття\n");

            Console.Write("\tНазва: ");
            string name = Console.ReadLine();

            Console.Write("\tЕлемент (Вогонь/Лiд/Тьма тощо): ");
            string element = Console.ReadLine();

            Console.Write("\tВартiсть мани: ");
            int manaCost = ReadIntSafe();

            Console.Write("\tПотрiбний рiвень мага: ");
            int level = ReadIntSafe();

            Spell spell = new Spell
            {
                Name = name,
                Element = element,
                ManaCost = manaCost,
                LevelRequired = level
            };

            spellRepo.Add(spell);
            TypeEffect("✅ Закляття успiшно додано!");
        }

        static void RemoveSpell()
        {
            ShowAllSpells();
            Console.WriteLine();

            var spells = spellRepo.GetAll();
            if (spells.Count == 0)
            {
                return;
            }

            Console.Write("\tВведiть номер закляття для видалення: ");
            int index = ReadIntSafe();

            if (index < 1 || index > spells.Count)
            {
                TypeEffect("⚠ Невiрний номер закляття.");
                return;
            }

            Spell toRemove = spells[index - 1];
            spellRepo.Remove(toRemove);
            TypeEffect("🗑 Закляття видалено.");
        }


        static void ShowAllMages()
        {
            ShowHeader();
            Console.WriteLine("\t🧙‍♂️ Список магiв академiї:\n");

            var mages = mageRepo.GetAll();
            if (mages.Count == 0)
            {
                Console.WriteLine("\t(Поки що немає жодного мага)");
                return;
            }

            for (int i = 0; i < mages.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {mages[i]}");
            }
        }

        static void AddMage()
        {
            ShowHeader();
            Console.WriteLine("\t➕ Додавання нового мага\n");

            Console.Write("\tIм'я мага: ");
            string name = Console.ReadLine();

            Console.Write("\tРанг (Учень/Адепт/Архiмаг): ");
            string rank = Console.ReadLine();

            Console.Write("\tСпецiалiзацiя (Бойова магiя/Алхiмiя тощо): ");
            string specialization = Console.ReadLine();

            Mage mage = new Mage
            {
                Name = name,
                Rank = rank,
                Specialization = specialization
            };

            mageRepo.Add(mage);
            TypeEffect("✅ Мага успiшно додано!");
        }

        static void RemoveMage()
        {
            ShowAllMages();
            Console.WriteLine();

            var mages = mageRepo.GetAll();
            if (mages.Count == 0)
            {
                return;
            }

            Console.Write("\tВведiть номер мага для видалення: ");
            int index = ReadIntSafe();

            if (index < 1 || index > mages.Count)
            {
                TypeEffect("⚠ Невiрний номер мага.");
                return;
            }

            Mage toRemove = mages[index - 1];
            mageRepo.Remove(toRemove);
            TypeEffect("🗑 Мага видалено.");
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
    }
}
