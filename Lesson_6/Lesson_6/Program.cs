using System;
using System.Diagnostics;
/*
*1. Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет завершить указанный процесс. Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса. В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.
*2. Напишите метод, на вход которого подаётся двумерный строковый массив размером 4х4,
при подаче массива другого размера необходимо бросить исключение MyArraySizeException.
Далее метод должен пройтись по всем элементам массива, преобразовать в int, и просуммировать.
Если в каком-то элементе массива преобразование не удалось
(например, в ячейке лежит символ или текст вместо числа), должно быть брошено исключение MyArrayDataException, с детализацией в какой именно ячейке лежат неверные данные.
В методе main() вызвать полученный метод, обработать возможные исключения MySizeArrayException и MyArrayDataException, и вывести результат расчета. 
Ilya Shorokhov 12/08/2021
*/

namespace Lesson_6
{
    class Program
    {
        static void Line(int maxLenghtStr)
        {
            for (int i = 0; i < maxLenghtStr; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        [Obsolete]
        static void TaskManager_New()
        {
            try
            {
                Process[] proc = Process.GetProcesses();
                int maxLenghtName = 0;
                int maxLenghtStr = 0;

                for (int i = 0; i < proc.Length; i++)
                {
                    if (maxLenghtName < proc[i].ProcessName.Length)
                    {
                        maxLenghtName = proc[i].ProcessName.Length;
                    }
                }

                Console.Clear();

                string formatString = string.Format("{0,-12:N0}|" + "{1,-" + $"{maxLenghtName}" + "}|" + "{2,-" + $"{maxLenghtName}" + ":N0}", "ID Процесса ", "Наименование процесса ", "Память выделенная под процесс ");

                Console.WriteLine(formatString);

                maxLenghtStr = formatString.Length;

                Line(maxLenghtStr);

                for (int i = 0; i < proc.Length; i++)
                {
                    Console.WriteLine("{0,-12:N0}|" + "{1,-" + $"{maxLenghtName}" + "}|" + "{2,-" + $"{maxLenghtName}" + ":N0}", proc[i].Id, proc[i].ProcessName, proc[i].PrivateMemorySize);
                }

                Line(maxLenghtStr);

                TackManagerMenu(maxLenghtStr);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }


        }

        static void TackManagerMenu(int maxLenghtStr)
        {
            string num;

            do
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Выбрать процесс по имени\n2 - Выбрать процесс по ID\n3 - Выход из диспетчера задач");

                Line(maxLenghtStr);

                num = Console.ReadLine();
                try
                {
                    switch (Convert.ToInt32(num))
                    {
                        case 1:
                            Console.WriteLine("Выбран поиск процесса по имени");
                            SearchProcforName(maxLenghtStr);
                            break;
                        case 2:
                            Console.WriteLine("Выбран поиск процесса по его ID");
                            SearchProcbyId(maxLenghtStr);
                            break;
                        case 3:
                            break;
                        default:
                            throw new ArgumentException("Такого пункта меню не существует", num);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Исключение: {ex.Message}");
                }
            }
            while (Convert.ToInt32(num) != 3);
        }

        static void SearchProcbyId(int maxLenghtStr)
        {
            try
            {
                string num_menu;

                Console.Write("Укажите ID процесса: ");

                int id_proc = Convert.ToInt32(Console.ReadLine());

                Process remoteById = Process.GetProcessById(id_proc, ".");

                Line(maxLenghtStr);

                Console.WriteLine("1 - Завершить процесс принудительно\n2 - Дождаться завершения процесса\n3 - Выход из диспетчера задач");

                Line(maxLenghtStr);


                Console.Write("Выбрать дальнейшее действие: ");

                num_menu = Console.ReadLine();

                switch (Convert.ToInt32(num_menu))
                {
                    case 1:
                        remoteById.Kill();
                        Console.WriteLine("Приложение было принудительно закрыто.");
                        Environment.Exit(0);
                        break;
                    case 2:
                        Console.WriteLine("Ждем завершения процесса...");
                        remoteById.WaitForExit();
                        Console.WriteLine("Процесс завершен");
                        Environment.Exit(0);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        throw new ArgumentException("Такого пункта меню не существует", num_menu);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }

        }

        static void SearchProcbyIdForOneMoreProc(int maxLenghtStr)
        {
            string num_menu;

            num_menu = Console.ReadLine();

            switch (Convert.ToInt32(num_menu))
            {
                case 1:
                    SearchProcbyId(maxLenghtStr);
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Такого пункта меню не существует", num_menu);
            }
        }

        static void SearchProcbyIdForOneProс(string nameProc, int maxLenghtStr)
        {
            string num_menu;

            Console.WriteLine("1 - Завершить процесс принудительно\n2 - Дождаться завершения процесса\n3 - Выход из диспетчера задач");

            Line(maxLenghtStr);

            Console.Write("Выбрать дальнейшее действие: ");
            try
            {
                num_menu = Console.ReadLine();

                switch (Convert.ToInt32(num_menu))
                {
                    case 1:
                        Process[] workers = Process.GetProcessesByName(nameProc);
                        foreach (Process nameProcforKill in workers)
                        {
                            nameProcforKill.Kill();
                            Console.WriteLine("Приложение было принудительно закрыто.");
                            Environment.Exit(0);
                        }
                        break;
                    case 2:
                        workers = Process.GetProcessesByName(nameProc);
                        foreach (Process nameProcforKill in workers)
                        {
                            Console.WriteLine("Ждем завершения процесса...");
                            nameProcforKill.WaitForExit();
                            Console.WriteLine("Процесс был завершен");
                            Environment.Exit(0);
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        throw new ArgumentException("Такого пункта меню не существует", num_menu);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }

        static void SearchProcforName(int maxLenghtStr)
        {
            Console.Write("Укажите название процесса:");

            string nameProc = Console.ReadLine();

            Line(maxLenghtStr);

            Console.WriteLine();

            Process[] remoteByName = Process.GetProcessesByName(nameProc, ".");

            try
            {
                if (remoteByName.Length != 0 && remoteByName.Length > 1)
                {
                    Console.WriteLine("Найденно несколько процессов с одинаковым именем:\n");

                    for (int i = 0; i < remoteByName.Length; i++)
                    {
                        Console.WriteLine("Выбран процесс:" + remoteByName[i].ProcessName + "\t " + " ID Процесса " + remoteByName[i].Id);
                    }

                    Line(maxLenghtStr);

                    Console.WriteLine("1 - Выбрать процесс по ID\n2 - Выйти из диспетчера задач");

                    Line(maxLenghtStr);

                    Console.Write("Выбрать дальнейшее действие: ");
                    SearchProcbyIdForOneMoreProc(maxLenghtStr);
                }
                else if (remoteByName.Length != 0 && remoteByName.Length == 1)
                {
                    Line(maxLenghtStr);

                    Console.WriteLine("Найденные процессы по имени:" + nameProc);

                    for (int i = 0; i < remoteByName.Length; i++)
                    {
                        Console.WriteLine("Выбран процесс:" + remoteByName[i].ProcessName + "\t " + " ID Процесса " + remoteByName[i].Id);
                    }

                    Line(maxLenghtStr);

                    SearchProcbyIdForOneProс(nameProc, maxLenghtStr);
                }
                else
                {
                    throw new ArgumentException("Такого процесса не существует", nameProc);
                }

                Line(maxLenghtStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }
        static void Array()
        {
            Console.WriteLine("Укажите размерность матрицы через пробел: ");
            Console.WriteLine("Укажите размерность по x: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Укажите размерность по y: ");
            int y = int.Parse(Console.ReadLine());

            int[,] array = new int[x, y];

            Console.WriteLine("Заполните матрицу целочисленными числами: ");

            int sum = 0;

            string[] num_new = Console.ReadLine().Split(' ');

            for (int i = 0; i < num_new.Length; i++)
            {
                try
                {
                    sum += Convert.ToInt32(num_new[i]);
                }

                catch
                {
                    throw new InvalidCastException("\nНевозможно коневертировать из string в int элемент массива: " + num_new[i].ToString());
                }
            }

            int count = 0;

            Console.WriteLine("Матрица которая получилась: ");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (num_new.Length < x * x)
                    {
                        throw new IndexOutOfRangeException("\nНевозможно добавить элемент в матрицу так как размерность матрицы не совпадает с количеством элементов");
                    }
                    array[i, j] = Convert.ToInt32(num_new[count]);
                    Console.Write(array[i, j]);
                    count += 1;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сумма элементов массива: " + sum);
        }

        [Obsolete]
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите номер задачи");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Console.WriteLine("Диспетчер задач:");
                        TaskManager_New();
                        break;
                    case 2:
                        Console.WriteLine("Задача №2: Написать программу, которая при старте дописывает текущее время в файл «startup.txt».");
                        Array();
                        break;
                    default:
                        Console.WriteLine("Не выбрана ни одна из существующих задач");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }

        }
    }
}
