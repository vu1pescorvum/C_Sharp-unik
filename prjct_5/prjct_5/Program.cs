using System;
using System.Linq;
using System.Threading;

namespace MagicAcademyLab5
{
    class Program
    {
        static Repository<Spell> spellRepo = new Repository<Spell>();

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
                        ShowSpellsByElement();       // Where
                        WaitForEnter();
                        break;
                    case "5":
                        ShowCheapSpells();           // Where з порогом
                        WaitForEnter();
                        break;
                    case "6":
                        SortByMana();                // OrderBy
                        WaitForEnter();
                        break;
                    case "7":
                        SortByPowerDesc();           // OrderByDescending
                        WaitForEnter();
                        break;
                    case "8":
                        ShowUltimateNames();         // Where + Select
                        WaitForEnter();
                        break;
                    case "9":
                        FindFirstByElement();        // FirstOrDefault
                        WaitForEnter();
                        break;
                    case "10":
                        ShowAveragePowerByElement(); // Average
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
            TypeEffect("👋 Дякуємо за роботу в магiчнiй лабораторiї LINQ!");
            TypeEffect("Натиснiть ENTER, щоб вийти.");
            Console.ReadLine();
        }


        static void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t++===================================================++");
            Console.WriteLine("\t||              Лабраторна робота 5                  ||");
            Console.WriteLine("\t++---------------------------------------------------++");
            Console.WriteLine("\t||      LINQ, лямбда та колекцiя заклять з Едосiком   ||");
            Console.WriteLine("\t++===================================================++");
            Console.WriteLine();
        }

        static void LoadingAnimation()
        {
            Console.Clear();
            Console.Write("Запуск системи");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(400);
                Console.Write(".");
            }
            Console.WriteLine("\nГотово!");
            Thread.Sleep(700);
        }

        static void IntroDialogue()
        {
            Console.Clear();
            TypeEffect("👋 Привiт, я Едосiк, твiй консольний помiчник!");
            Thread.Sleep(400);
            TypeEffect("✨ Сьогоднi ми тренуємося працювати з LINQ та лямбдами.");
            Thread.Sleep(600);
        }

        static void TypeEffect(string text, int delay = 40)
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
            Console.WriteLine("\t4. Фiльтр за елементом (Where)");
            Console.WriteLine("\t5. Закляття дешевше N мани (Where)");
            Console.WriteLine("\t6. Сортувати за мана-костом (OrderBy)");
            Console.WriteLine("\t7. Сортувати за силою (OrderByDescending)");
            Console.WriteLine("\t8. Назви ультимативних заклять (Where + Select)");
            Console.WriteLine("\t9. Перше закляття заданого елементу (FirstOrDefault)");
            Console.WriteLine("\t10. Середня сила заклять елементу (Average)");
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
                Power = 60,
                IsUltimate = false
            });

            spellRepo.Add(new Spell
            {
                Name = "Крижаний спис",
                Element = "Лiд",
                ManaCost = 30,
                Power = 55,
                IsUltimate = false
            });

            spellRepo.Add(new Spell
            {
                Name = "Пекельна буря",
                Element = "Вогонь",
                ManaCost = 70,
                Power = 95,
                IsUltimate = true
            });

            spellRepo.Add(new Spell
            {
                Name = "Тiньова хватка",
                Element = "Тьма",
                ManaCost = 35,
                Power = 65,
                IsUltimate = false
            });

            spellRepo.Add(new Spell
            {
                Name = "Свiтловий спалах",
                Element = "Свiтло",
                ManaCost = 20,
                Power = 40,
                IsUltimate = false
            });

            spellRepo.Add(new Spell
            {
                Name = "Армагеддон",
                Element = "Вогонь",
                ManaCost = 90,
                Power = 100,
                IsUltimate = true
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

            Console.Write("\tЕлемент (Вогонь/Лiд/Тьма/Свiтло тощо): ");
            string element = Console.ReadLine();

            Console.Write("\tВартiсть мани: ");
            int manaCost = ReadIntSafe();

            Console.Write("\tСила закляття (1-100): ");
            int power = ReadIntSafe();

            Console.Write("\tЧи ультимативне? (y/n): ");
            bool isUltimate = Console.ReadLine()?.Trim().ToLower() == "y";

            Spell spell = new Spell
            {
                Name = name,
                Element = element,
                ManaCost = manaCost,
                Power = power,
                IsUltimate = isUltimate
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

        // 4) Where: фiльтр за будь-яким елементом
        static void ShowSpellsByElement()
        {
            ShowHeader();
            Console.WriteLine("\t🔍 Фiльтр заклять за елементом (Where Element == ...)\n");

            Console.Write("\tВведiть елемент для пошуку (Вогонь/Лiд/Тьма/Свiтло тощо): ");
            string element = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(element))
            {
                TypeEffect("⚠ Ви не ввели назву елементу.");
                return;
            }

            var filteredSpells = spellRepo
                .GetAll()
                .Where(s => s.Element.Equals(element, StringComparison.OrdinalIgnoreCase));

            if (!filteredSpells.Any())
            {
                TypeEffect($"(❌ Заклять з елементом \"{element}\" не знайдено)");
                return;
            }

            Console.WriteLine($"\n\tЗакляття елементу: {element}\n");
            foreach (var spell in filteredSpells)
            {
                Console.WriteLine("\t" + spell);
            }
        }

        
        static void ShowCheapSpells()
        {
            ShowHeader();
            Console.WriteLine("\t💧 Закляття дешевше вказаної мани (Where ManaCost < N)\n");

            Console.Write("\tВведiть порiг мани N: ");
            int threshold = ReadIntSafe();

            var cheapSpells = spellRepo
                .GetAll()
                .Where(s => s.ManaCost < threshold);

            if (!cheapSpells.Any())
            {
                Console.WriteLine("\t(Немає заклять дешевше цього порогу)");
                return;
            }

            foreach (var spell in cheapSpells)
            {
                Console.WriteLine("\t" + spell);
            }
        }

       
        static void SortByMana()
        {
            ShowHeader();
            Console.WriteLine("\t📊 Сортування за мана-костом (OrderBy)\n");

            var sorted = spellRepo
                .GetAll()
                .OrderBy(s => s.ManaCost);

            foreach (var spell in sorted)
            {
                Console.WriteLine("\t" + spell);
            }
        }

        
        static void SortByPowerDesc()
        {
            ShowHeader();
            Console.WriteLine("\t⚡ Сортування за силою (OrderByDescending)\n");

            var sorted = spellRepo
                .GetAll()
                .OrderByDescending(s => s.Power);

            foreach (var spell in sorted)
            {
                Console.WriteLine("\t" + spell);
            }
        }

        
        static void ShowUltimateNames()
        {
            ShowHeader();
            Console.WriteLine("\t🌟 Назви ультимативних заклять (Where + Select)\n");

            var names = spellRepo
                .GetAll()
                .Where(s => s.IsUltimate)
                .Select(s => s.Name);

            if (!names.Any())
            {
                Console.WriteLine("\t(Ультимативних заклять немає)");
                return;
            }

            foreach (var name in names)
            {
                Console.WriteLine("\t- " + name);
            }
        }

        
        static void FindFirstByElement()
        {
            ShowHeader();
            Console.WriteLine("\t🔮 Пошук першого закляття за елементом (FirstOrDefault)\n");

            var spells = spellRepo.GetAll();
            if (spells.Count == 0)
            {
                TypeEffect("⚠ У базi поки немає жодного закляття.");
                return;
            }

            var allElements = spells
                .Select(s => s.Element)
                .Distinct()
                .OrderBy(e => e)
                .ToList();

            TypeEffect("\tДоступнi елементи у системi:");
            foreach (var el in allElements)
            {
                Console.WriteLine($"\t• {el}");
            }

            Console.WriteLine();
            Console.Write("\tВведiть елемент для пошуку: ");
            string element = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(element))
            {
                TypeEffect("⚠ Ви не ввели жодного елементу!");
                return;
            }

            var spell = spells
                .FirstOrDefault(s =>
                    s.Element.Equals(element, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine();
            if (spell == null)
            {
                TypeEffect($"❌ Закляття елементу \"{element}\" не знайдено.");
            }
            else
            {
                TypeEffect($"✅ Перше знайдене закляття елементу \"{element}\":");
                Console.WriteLine("\t" + spell);
            }
        }

        
        static void ShowAveragePowerByElement()
        {
            ShowHeader();
            Console.WriteLine("\t📈 Середня сила заклять за елементом (Average)\n");

            var spells = spellRepo.GetAll();
            if (spells.Count == 0)
            {
                TypeEffect("⚠ У базi поки немає жодного закляття.");
                return;
            }

            var elements = spells
                .Select(s => s.Element)
                .Distinct()
                .OrderBy(e => e)
                .ToList();

            TypeEffect("\tДоступнi елементи:");
            foreach (var el in elements)
            {
                Console.WriteLine($"\t• {el}");
            }

            Console.WriteLine();
            Console.Write("\tВведiть елемент: ");
            string element = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(element))
            {
                TypeEffect("⚠ Ви не ввели назву елементу.");
                return;
            }

            var filtered = spells
                .Where(s => s.Element.Equals(element, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filtered.Count == 0)
            {
                TypeEffect($"❌ Заклять елементу \"{element}\" не знайдено.");
                return;
            }

            double avgPower = filtered.Average(s => s.Power);

            TypeEffect($"✅ Середня сила заклять елементу \"{element}\": {avgPower:F2}");
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
