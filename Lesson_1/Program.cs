using System;

/*Написать программу, выводящую в консоль текст: «Привет, % имя пользователя %, сегодня % дата %».
 *Имя пользователя сохранить из консоли в промежуточную переменную. 
 * Поставить точку останова и посмотреть значение этой переменной в режиме отладки.
 * 21.07.2021 Ilya Shorokhov
*/

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя?");
            string Name = Console.ReadLine();
            //вывод без приминения интерполяции
            Console.WriteLine("Здравствуйте, " + Name + ", " + "сегодня " + DateTime.Now);
            //вывод с приминением интерполяции
            Console.WriteLine($"Здравствуйте, {Name}, сегодня  {DateTime.Now}");
        }
    }
}
