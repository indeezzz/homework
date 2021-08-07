using System;
/*
 * 1. Написать программу, выводящую элементы двумерного массива по диагонали.
 * 2. Написать программу «Телефонный справочник»: создать двумерный массив 5х2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/email.
 * 3. Написать программу, выводящую введённую пользователем строку в обратном порядке (olleH вместо Hello).
 * *«Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
 * 29/07/2021 Shorokhov Ilya
 */
namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите номер задачи");
            int number = Convert.ToInt32(Console.ReadLine());а

            switch (number)
            {
                case 1:
                    int[,] arr = new int[5, 5];
                    Console.WriteLine("Задача №1:Написать программу, выводящую элементы двумерного массива по диагонали.");
                    Console.WriteLine("Матрица:");
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (i == j)
                            {
                                arr[i, j] = i + 1;
                                Console.Write($"{arr[i, j]}");
                            }
                            else
                            {
                                Console.Write($"{arr[i, j]}");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Диагональ матрицы:");
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (arr[i, j] != 0)
                            {
                                Console.Write($"{arr[i, j]}");
                            }
                        }
                    }

                    break;
                case 2:
                    Console.WriteLine("Задача №2: Написать программу «Телефонный справочник»: создать двумерный массив 5х2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/email.");
                    string[,] arr_1 = new string[6, 2];
                    arr_1[0, 0] = "Имя";
                    arr_1[0, 1] = "Номер телефона";
                    for (int i = 1; i < arr_1.GetLength(0); i++)
                    {
                        Console.WriteLine("Укажите имя");
                        string name = Console.ReadLine();
                        arr_1[i, 0] = name;
                        for (int j = 0; j < arr_1.GetLength(1); j++)
                        {
                            Console.WriteLine("Укажите номер телефона / email");
                            string phone = Console.ReadLine();
                            arr_1[i, j + 1] = phone;
                            break;
                        }
                    }
                    for (int i = 0; i < arr_1.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr_1.GetLength(1); j++)
                        {
                            Console.Write($"{ arr_1[i, j]}" + "\t");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.WriteLine("Задача №3:Написать программу, выводящую введённую пользователем строку в обратном порядке (olleH вместо Hello).");
                    Console.WriteLine("Укажите слово:");
                    string str = Console.ReadLine();
                    for (int i = str.Length - 1; i >= 0; i--)
                    {
                        Console.Write(str[i]);
                    }
                    break;
                case 4:
                    Console.WriteLine("Морской бой");
                    Console.WriteLine("1-Начать игру" + "\t" + "2 - Выход из игры");
                    int game = Convert.ToInt32(Console.ReadLine());

                    switch (game)
                    {
                        case 1:
                            int[,] arr_3 = new int[11, 11];
                            for (int i = 0; i < arr_3.GetLength(0); i++)
                            {
                                for (int j = 0; j < arr_3.GetLength(1); j++)
                                {
                                    arr_3[i, j] = 0;
                                    Console.Write(arr_3[i, j]);
                                }
                                Console.WriteLine();
                            }
                            break;
                        case 2:

                            break;
                    }

                    break;
                default:
                    Console.WriteLine("Не выбрана ни одна из существующих задач");
                    break;

            }
        }
    }
}