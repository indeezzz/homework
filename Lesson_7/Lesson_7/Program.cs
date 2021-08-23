using System;
/*
1. Написать любое приложение, произвести его сборку с помощью MSBuild, осуществить декомпиляцию с помощью dotPeek, внести правки в программный код и пересобрать приложение.
2. Переделать проверку победы, чтобы она не была реализована просто набором условий, например, с использованием циклов.
3. * Попробовать переписать логику проверки победы, чтобы она работала для поля 5х5 и количества фишек 4. Очень желательно не делать это просто набором условий для каждой из возможных ситуаций;
4. *** Доработать искусственный интеллект, чтобы он мог блокировать ходы игрока
Ilya Shorokhov 15/08/2021
 */

namespace Lesson_7
{
    class Cross
    {
        static int SIZE_X = 5;
        static int SIZE_Y = 5;

        static char[,] field = new char[SIZE_Y, SIZE_X];

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();

        private static void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("-----------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------");
        }

        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }

        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void playerMove()
        {
            int x, y;
            do
            {
                Console.WriteLine("Координат по строке ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_Y);
                x = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Координат по столбцу ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_X);
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static bool CheckWin(char sym)
        {
            int count = 0;
            //Проверка горизонтали
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    if (field[i, j] == sym)
                        count++;
                    if (count >= 4)
                        return true;
                }
                count = 0;
            }
            count = 0;
            //Проверка вертикали
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[j, i] == sym)
                        count++;
                    if (count >= 4)
                        return true;
                }
                count = 0;
            }
            count = 0;
            //Проверка дигонали
            int d = 0;
            while (d < SIZE_X)
            {
                for (int i = 0; i < SIZE_X; i++)
                {
                    for (int j = 0; j < SIZE_Y; j++)
                    {
                        if (
                            (i + 1) < SIZE_X //проверка на вхождение в диапазон
                            &&
                            (j + 1) < SIZE_Y //проверка на вхождение в диапазон
                            &&
                            field[i, j] == field[i + 1, j + 1] && field[i, j] == sym  //ищем появление комбинации в диагонали
                            &&
                            ((j - i) == d || (i - j) == d)//проверяем, что на одной диагонали
                            )
                            count++;
                        if (count >= 4)
                            return true;
                    }
                }
                d++;//переход на диагональ
                count = 0;//обнуления счетчика для проверки по диагонали
            }
            return false;
        }

        private static void AiMove(char sym)
        {
            int x, y;
            do
            {
                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(x, y, AI_DOT);
        }


        static void Main(string[] args)
        {
            InitField();
            PrintField();
            do
            {
                playerMove();
                Console.WriteLine("Ваш ход на поле");
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                AiMove(PLAYER_DOT);
                Console.WriteLine("Ход Компа на поле");
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
            Console.WriteLine("!Конец игры!");
        }
    }
}
