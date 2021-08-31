using System;
using System.Linq;
/*
 * Ilya Shorokhov. Спираль. 30.08.2021
 */

namespace Lesson_8
{
    class Program
    {
        static void Numbers()
        {
            Console.WriteLine("Укажите количество строк: ");
            int SIZE_X = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Укажите количество столбцов: ");
            int SIZE_Y = Convert.ToInt32(Console.ReadLine());

            int[,] mass = new int[SIZE_X, SIZE_Y];

            int s_x = SIZE_X;
            int s_y = SIZE_Y;

            int value = 1;
            int x = 0;
            int y = 0;
            int zero = 0;

            if (SIZE_X * SIZE_Y % 2 != 0)
            {
                if (mass.Length <= 9)
                {
                    int center = SIZE_X / 2;

                    while (y < SIZE_X - 1)
                    {
                        mass[x, y++] = value;
                        value++;
                    }

                    while (x < SIZE_X - 1)
                    {
                        mass[x++, y] = value;
                        value++;
                    }

                    while (y > zero)
                    {
                        mass[x, y--] = value;
                        value++;
                    }

                    while (x > zero)
                    {
                        mass[x--, y] = value;
                        value++;
                    }

                    mass[center, center] = value;
                }
                else
                {
                    int center = SIZE_X / 2;
                    do
                    {
                        while (y < SIZE_X - 1)
                        {
                            mass[x, y++] = value;
                            value++;
                        }

                        while (x < SIZE_X - 1)
                        {
                            mass[x++, y] = value;
                            value++;
                        }

                        while (y > zero)
                        {
                            mass[x, y--] = value;
                            value++;
                        }

                        while (x > zero)
                        {
                            mass[x--, y] = value;
                            value++;
                        }
                        x = x + 1;
                        y = y + 1;
                        SIZE_X = SIZE_X - 1;
                        SIZE_Y = SIZE_Y - 1;
                        zero = zero + 1;
                    }
                    while (value < mass.Length);
                    mass[center, center] = value;
                }

            }
            else
            {
                if (mass.Length <= 9)
                {
                    while (y < SIZE_X - 1)
                    {
                        mass[x, y++] = value;
                        value++;
                    }

                    while (x < SIZE_X - 1)
                    {
                        mass[x++, y] = value;
                        value++;
                    }

                    while (y > 0)
                    {
                        mass[x, y--] = value;
                        value++;
                    }

                    while (x > 0)
                    {
                        mass[x--, y] = value;
                        value++;
                    }
                }
                else
                {
                    do
                    {
                        while (y < SIZE_X - 1)
                        {
                            mass[x, y++] = value;
                            value++;
                        }

                        while (x < SIZE_X - 1)
                        {
                            mass[x++, y] = value;
                            value++;
                        }

                        while (y > zero)
                        {
                            mass[x, y--] = value;
                            value++;
                        }

                        while (x > zero)
                        {
                            mass[x--, y] = value;
                            value++;
                        }
                        x = x + 1;
                        y = y + 1;
                        SIZE_X = SIZE_X - 1;
                        SIZE_Y = SIZE_Y - 1;
                        zero = zero + 1;
                    }
                    while (value < mass.Length);
                }
            }





            //for (int i = x; i < SIZE_X; i++)
            //{
            //    for (int j = y; j < SIZE_Y; j++)
            //    {
            //        if (j == SIZE_Y - 1 && i != SIZE_X - 1)
            //        {
            //            mass[i, j] = value;
            //            y = SIZE_Y - 1;
            //            value++;
            //        }
            //        else if (j == SIZE_Y - 1 && i == SIZE_X - 1)
            //        {
            //            for (j = y; j >= 0; j--)
            //            {
            //                if (j == 0 && i == SIZE_X - 1)
            //                {
            //                    do
            //                    {
            //                            mass[y--, j] = value;
            //                            value++;
            //                    }
            //                    while (y != 0);
            //                }
            //                else
            //                {
            //                    mass[i, j] = value;
            //                    value++;
            //                }
            //            }
            //            break;
            //        }
            //        else
            //        {
            //            mass[i, j] = value;
            //            value++;
            //        }
            //    }
            //}

            for (int i = 0; i < s_x; i++)
            {
                for (int j = 0; j < s_y; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            Numbers();
        }
    }
}
