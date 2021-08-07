using System;
using System.Linq;
/*
* 1. Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
* 2. Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести результат на экран.
* 3. Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца. На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn. Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень). Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года. Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
* 4. (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.
* 5. (**) Есть предложение String str1 = " Предложение один Теперь предложение два Предложение три"; нужно превести строку к нормально виду " Предложение один. Теперь предложение два. Предложение три";
*/

namespace Lesson_4
{
    class Program
    {
        enum Mounths
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            Jule,
            August,
            September,
            October,
            November,
            December
        }
        static int Fib(int n)
        {
            return n <= 1 ? n : Fib(n - 1) + Fib(n - 2);
        }
        static void getSeason()
        {
            bool quit = true;
            while (quit)
            {
                Console.WriteLine("Укажите номер месяца числом? Для выхода нажмите 0");
                int mounth = Convert.ToInt32(Console.ReadLine());
                Mounths name_mounth = (Mounths)Enum.GetValues(typeof(Mounths)).GetValue(mounth - 1);
                if (mounth != 0)
                {
                    if (mounth == 1 || mounth == 2 || mounth == 12)
                    {
                        Console.WriteLine("Зимний месяц:" + name_mounth);
                        Console.WriteLine();
                    }
                    else if (mounth == 3 || mounth == 4 || mounth == 5)
                    {
                        Console.WriteLine("Весений месяц:" + name_mounth);
                        Console.WriteLine();
                    }
                    else if (mounth == 6 || mounth == 7 || mounth == 8)
                    {
                        Console.WriteLine("Летний месяц:" + name_mounth);
                        Console.WriteLine();
                    }
                    else if (mounth == 9 || mounth == 10 || mounth == 11)
                    {
                        Console.WriteLine("Осенний месяц:" + name_mounth);
                        Console.WriteLine();
                    }
                }
                else
                {
                    quit = false;
                }
            }

        }
        static void StrSplit()
        {
            bool quit = true;
            while (quit)
            {
                Console.WriteLine("1 - для продолжения 0 - для выхода из задачи");
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer != 0)
                {
                    Console.WriteLine("Введите текст без точек, но с заглавынми буквами:");
                    string[] str = Console.ReadLine().Split(new string[] { "?<=[A-Za-z0-9])[A-Z]" }, StringSplitOptions.RemoveEmptyEntries);
                    //string str = Console.ReadLine();
                    //str = str.Replace("(?<=[A-Za-z0-9])[A-Z]", ".");
                    Console.WriteLine(str.ToString());
                }
                else
                {
                    quit = false;
                }
            }
        }
        static void CreateUser()
        {
            bool quit = true;
            while (quit)
            {
                Console.WriteLine("Начать заполнение формы? Yes/No");
                string answer = Console.ReadLine();
                if (answer == "Yes")
                {
                    Console.WriteLine("Укажите ваше имя:");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Укажите вашу фамилию:");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("Укажите ваше отчество:");
                    string patronymic = Console.ReadLine();
                    GetFullName(firstname, lastname, patronymic);
                }
                else
                {
                    quit = false;
                }
            }
        }

        static void Numbers()
        {
            bool quit = true;
            while (quit)
            {
                Console.WriteLine("Начать заполнение числовго ряда? Yes/No");
                string answer = Console.ReadLine();
                if (answer == "Yes")
                {
                    Console.WriteLine("Укажите цифры через пробел,чтобы посчитать их сумму:");
                    int[] values = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
                    int sum = Sum(values);
                    Console.WriteLine("Сумма = " + sum);
                }
                else
                {
                    quit = false;
                }
            }
        }
        static int Sum(params int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;

        }

        static void GetFullName(string firstname, string lastname, string patronymic)
        {
            Console.WriteLine($"{lastname} {firstname} {patronymic}");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выьерите одну из существующих задач:");
                int number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        Numbers();
                        break;
                    case 3:
                        getSeason();
                        break;
                    case 4:
                        Console.WriteLine("Вычисли число Фибоначчи для n = ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Число Фибоначчи= " + Fib(n));
                        break;
                    case 5:
                        StrSplit();
                        break;
                    default:
                        Console.WriteLine("Не выбрана ни одна из существующих задач");
                        break;
                }
            }
        }
    }
}