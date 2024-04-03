using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_5_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var anketa = GetAnketa();
        }

        static (string Name, string LastName, int Age, string[] PetNames, string[] FavColors) GetAnketa() {

            // Создаём кортеж
            (string Name, string LastName, int Age, string[] PetNames, string[] FavColors) anketa;

            Console.Write("Введите имя: ");
            anketa.Name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            anketa.LastName = Console.ReadLine();


            string age;
            int intage;
            do
            {
                Console.Write("Введите возраст: ");
                age = Console.ReadLine();

            } while (CheckNum(age, out intage));
            anketa.Age = intage;

            // Есть ли животные, их количество и имена
            anketa.PetNames = Pets();

            // Количество любимых цветов и их список
            anketa.FavColors = Colors();

            // Вывод всех данных
            OutText(anketa.Name, anketa.LastName, anketa.Age, anketa.PetNames, anketa.FavColors);

            return anketa;
        }

        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;

                }
            }
                {
                    corrnumber = 0;
                    return true;
                }
        }

        // Запрос наличие питомца, их количество и список
        static string[] Pets()
        {
            Console.Write("У вас есть питомец? (Да/Нет): ");
            string YesNo = Console.ReadLine();
            if (YesNo == "Да" || YesNo == "да")
            {
                string pet;
                int inrage;
                do
                {
                    Console.Write("Введите количество питомцев: ");
                    pet = Console.ReadLine();
                } while (CheckNum(pet, out inrage));
                int petCount = inrage;
                if (petCount >= 1)
                {
                    string[] PetMassiv = new string[petCount];

                    for (int i = 0; i < PetMassiv.Length; i++)
                    {
                        Console.Write("Введите имя {0}-го питомца: ", i + 1);
                        PetMassiv[i] = Console.ReadLine();
                    }
                    return PetMassiv;
                }
                else
                    Console.WriteLine("Заведите себе зверушку)");
            }
            return null;
        }

        // Запрос кол-во любимых цветов и их заполнение
        static string[] Colors()
        {
            Console.Write("Введите количество любимых цветов: ");
            int colorsCount = int.Parse(Console.ReadLine());
            if (colorsCount >= 1)
            {
                string[] ColorMassiv = new string[colorsCount];

                for (int i = 0; i < ColorMassiv.Length; i++)
                {
                    Console.Write("Введите цвет под номером {0}: ", i + 1);
                    ColorMassiv[i] = Console.ReadLine();
                }
                return ColorMassiv;
            }
            return null;
        }

        // Вывод всех данных после заполнения
        static string OutText(string Name, string LastName, int Age, string[] PetNames, string[] FavColors)
        {
            Console.WriteLine("Добро пожаловать {0} {0}", Name, LastName);

            Console.WriteLine("На сегодняшний день вам {0} лет", Age);
            Console.WriteLine("Список ваших животных: ");
            for (int i = 0; i < PetNames.Length; i++)
            {
                Console.WriteLine(PetNames[i]);
            }

            Console.WriteLine("Список ваших любимых цветов: ");
            for (int i = 0; i < FavColors.Length; i++)
            {
                Console.WriteLine(FavColors[i]);
            }

            Console.ReadKey();


            return null;
        } 
    }
}
