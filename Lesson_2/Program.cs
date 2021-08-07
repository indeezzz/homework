using System;
/*
 * Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
 * Запросить у пользователя порядковый номер текущего месяца и вывести его название.
 * Определить, является ли введённое пользователем число чётным.
 * Для полного закрепления понимания простых типов найдите любой чек, либо фотографию этого чека в интернете и схематично нарисуйте его в консоли, только за место динамических, по вашему мнению, данных (это может быть дата, название магазина, сумма покупок) подставляйте переменные, которые были заранее заготовлены до вывода на консоль.
 * (*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
 * (*) Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру, чтобы описать работу какого либо офиса. Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает с понедельника до воскресенья и выведите его на экран консоли.
 * 25/07/2021 Ilya Shorokhov
*/

namespace Lesson_2
{
    class Program
    {
        enum Mounths
        {
            January = 0,
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
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите номер задачи:");
            Console.WriteLine("Укажите номер задачи:");
            int homework = Convert.ToInt32(Console.ReadLine());

            switch (homework)
            {
                case 0:
                    Console.WriteLine("Выбрана задача №1: Указать минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.");
                    Console.WriteLine("Укажите минимальную температуру за сутки");
                    int min_t = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Укажите максимальную температуру за сутки");
                    int max_t = Convert.ToInt32(Console.ReadLine());
                    float result_1 = (min_t + max_t) / 2;
                    Console.WriteLine("Среднесуточная температура за сутки: " + result_1);
                    break;
                case 1:
                    Console.WriteLine("Выбрана задача №2: Запросить у пользователя порядковый номер текущего месяца и вывести его название.");
                    Console.WriteLine("Укажите номер месяца:");
                    int mounth = Convert.ToInt32(Console.ReadLine());
                    Mounths name_mounth = (Mounths)Enum.GetValues(typeof(Mounths)).GetValue(mounth - 1);
                    Console.WriteLine("Название месяца: " + name_mounth);
                    //Через использование свича 
                    switch (mounth)
                    {
                        case 1:
                            Console.WriteLine("Название месяца: Январь");
                            break;
                        case 2:
                            Console.WriteLine("Название месяца: Февраль");
                            break;
                        case 3:
                            Console.WriteLine("Название месяца: Март");
                            break;
                        case 4:
                            Console.WriteLine("Название месяца: Апрель");
                            break;
                        case 5:
                            Console.WriteLine("Название месяца: Май");
                            break;
                        case 6:
                            Console.WriteLine("Название месяца: Июнь");
                            break;
                        case 7:
                            Console.WriteLine("Название месяца: Июль");
                            break;
                        case 8:
                            Console.WriteLine("Название месяца: Август");
                            break;
                        case 9:
                            Console.WriteLine("Название месяца: Сентябрь");
                            break;
                        case 10:
                            Console.WriteLine("Название месяца: Октябрь");
                            break;
                        case 11:
                            Console.WriteLine("Название месяца: Ноябрь");
                            break;
                        case 12:
                            Console.WriteLine("Название месяца: Декабрь");
                            break;
                        default:
                            Console.WriteLine("По данному номеру месяц не найден или его не существует");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Выбрана задача №3: Определить, является ли введённое пользователем число чётным.");
                    Console.WriteLine("Введите любое целое число:");
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (number % 2 == 0)
                    {
                        Console.WriteLine("Число является четным");
                    }
                    else
                    {
                        Console.WriteLine("Число является нечетным");
                    }
                    break;
                case 3:
                    string code_product_1 = "#467008394281#";
                    string code_product_2 = "#467008394266#";
                    string code_product_3 = "#467008394265#";
                    string code_product_4 = "#467008394263#";
                    double price_1 = 299;
                    double price_2 = 799;
                    double price_3 = 999;
                    string NameShop = "ТВОЕ";
                    DateTime date = DateTime.Now;
                    Console.WriteLine("Выбрана задача №4: Кассовый чек");
                    Console.WriteLine(NameShop);
                    Console.WriteLine("Добро пожаловать!");
                    Console.WriteLine("Кассовый чек");
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("1: Набор носков, 3 пары," + code_product_1 + " " + price_1 + " * " + 1 + " = " + price_1 * 1);
                    Console.WriteLine("2: Набор носков, 3 пары," + code_product_2 + " " + price_1 + " * " + 1 + " = " + price_1 * 1);
                    Console.WriteLine("3: Набор носков, 3 пары," + code_product_2 + " " + price_1 + " * " + 1 + " = " + price_1 * 1);
                    Console.WriteLine("4: Толстовка с капюшоном" + code_product_3 + " " + price_2 + " * " + 1 + " = " + price_2 * 1);
                    Console.WriteLine("5: Толстовка с капюшоном" + code_product_4 + " " + price_3 + " * " + 1 + " = " + price_3 * 1);
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    double sum = price_1 + price_1 + price_1 + price_2 + price_3;
                    double nds = sum * 0.20;
                    Console.WriteLine("Итого: " + sum);
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("Сумма с НДС 20%: " + nds);
                    Console.WriteLine("Безналичными: " + sum);
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("Дата: " + date);
                    break;
                case 4:
                    Console.WriteLine("Выбрана задача №5: Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».");
                    Console.WriteLine("Укажите месяц(словом): ");
                    string MounthName = Console.ReadLine();
                    Console.WriteLine("Укажите среднюю температуру: ");
                    int t = Convert.ToInt32(Console.ReadLine());
                    if ((MounthName == "Январь" || MounthName == "Декабрь" || MounthName == "Февраль") && t > 0)
                    {
                        Console.WriteLine("Дождливая зима");
                    }
                    else if ((MounthName == "Январь" || MounthName == "Декабрь" || MounthName == "Февраль") && t < 0)
                    {
                        Console.WriteLine("Зима как зима");
                    }
                    else
                    {
                        Console.WriteLine("Это точно не зима");
                    }
                    break;
                default:
                    Console.WriteLine("Не выбрана ни одна из существующих задач");
                    break;
            }
        }
    }
}