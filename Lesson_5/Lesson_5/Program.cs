using System;
using System.IO;
using System.Linq;
/*
* 1. Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
* 2. Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
* 3. Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
* 4. Создать класс "Сотрудник" с полями: ФИО, должность, email, телефон, зарплата, возраст;
* Ilya Shorokhov 06/08/2021
*/

namespace Lesson_5
{
    class Program
    {
        class Person
        {
            public int Age { get; set; }
            public string Fio { get; set; }
            public string Position { get; set; }
            public string Email { get; set; }
            public string Num { get; set; }
            public int Salary { get; set; }

            public Person(string fio, string position, string email, string num, int salary, int age)
            {
                Fio = fio;
                Position = position;
                Email = email;
                Num = num;
                Salary = salary;
                Age = age;
            }

            public void Info()
            {
                Console.Write($"{Fio} {Position} {Email} {Num} {Salary} {Age}");
            }
        }

        static void PersonInfo()
        {
            Person[] persArray = new Person[6]; // Вначале объявляем массив объектов
            persArray[0] = new Person("Ivanov Ivan", "Engineer", "ivivan@mailbox.com", "892312312", 30000, 41);
            persArray[1] = new Person("Sidorov Artem", "Engineer", "ivivan@mailbox.com", "892312313", 30000, 25);
            persArray[2] = new Person("Trubin Matvey", "Engineer", "ivivan@mailbox.com", "892312314", 30000, 30);
            persArray[3] = new Person("Shorokhov Ilya", "Engineer", "ivivan@mailbox.com", "892312315", 30000, 41);
            persArray[4] = new Person("Nadeev Alex", "Engineer", "ivivan@mailbox.com", "892312316", 30000, 27);
            persArray[5] = new Person("Malsa Olga", "Engineer", "ivivan@mailbox.com", "892312317", 30000, 40);

            for (int i = 0; i < persArray.Length; i++)
            {
                if (persArray[i].Age > 40)
                {
                    persArray[i].Info();
                    Console.WriteLine();
                }
            }
        }

        static void StrTxt()
        {
            bool quit = true;
            while (quit)
            {
                Console.WriteLine("Напишите текст,который хотите сохранить в текстовом файле? Для выхода напиши quit");
                string str = Console.ReadLine();
                if (str != "quit")
                {
                    string filename = "text.txt";
                    File.WriteAllText(filename, str); // записываем в файл строку
                }
                else
                {
                    quit = false;
                }
            }
        }
        static void StrTxtDateTime()
        {
            bool quit = true;
            while (quit)
            {
                Console.WriteLine("Напишите текст,который хотите сохранить в текстовом файле? Для выхода напиши quit");
                string str = Console.ReadLine();
                if (str != "quit")
                {
                    string filename = "startup.txt";
                    File.WriteAllText(filename, str); // записываем в файл строку
                    File.AppendAllText(filename, Environment.NewLine); // вставляем перенос строки
                    File.AppendAllLines(filename, new[] { DateTime.Now.ToString() }); // добавляем еще одну строку

                }
                else
                {
                    quit = false;
                }
            }
        }
        static void binNum()
        {
            bool quit = true;
            while (quit)
            {
                Console.WriteLine("Ввести с клавиатуры произвольный набор чисел (0...255). Для выхода нажмите ENTER");
                int[] num = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
                byte[] num_byte = new byte[num.Length];
                if (num.Length != 0)
                {
                    for (int i = 0; i < num.Length; i++)
                    {
                        if (num[i] < 0 || num[i] > 255)
                        {
                            Console.WriteLine("Ошибка. Одно из чисeл выходит за рамки диапозона: " + num[i] + " оно будет записанно, как 0");
                        }
                        else
                        {
                            num_byte[i] = Convert.ToByte(num[i]);
                        }
                    }
                    File.WriteAllBytes("bytes.bin", num_byte);
                    byte[] fromFile = File.ReadAllBytes("bytes.bin");
                    Console.WriteLine("Проверим что все числа записались в файл:");
                    for (int j = 0; j < fromFile.Length; j++)
                    {
                        Console.WriteLine(fromFile[j].ToString());
                    }
                }
                else
                {
                    quit = false;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите номер задачи");
            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Console.WriteLine("Задача №1: Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.");
                    StrTxt();
                    break;
                case 2:
                    Console.WriteLine("Задача №2: Написать программу, которая при старте дописывает текущее время в файл «startup.txt».");
                    StrTxtDateTime();
                    break;
                case 3:
                    Console.WriteLine("Задача №3: Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл");
                    binNum();
                    break;
                case 4:
                    Console.WriteLine("Задача №4: Создать класс Сотрудник с полями: ФИО, должность, email, телефон, зарплата, возраст;");
                    PersonInfo();
                    break;
                default:
                    Console.WriteLine("Не выбрана ни одна из существующих задач");
                    break;

            }
        }
    }
}
