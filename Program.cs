using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Validator validator = new Validator();
            int num1;
            bool exitProgram = false;
            while (!exitProgram)
            {
                Console.Write("Введите номер задания из списка \"1 2\" (или 0 для выхода): ");
                num1 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                switch (num1)
                {
                    case 0:
                        {
                            exitProgram = true;
                            Console.WriteLine("Программа завершена. До свидания!");
                            break;
                        }

                    case 1:
                        {
                            Cat cat1 = new Cat("Барсик");
                            Console.WriteLine();
                            Console.WriteLine(cat1.Meow());
                            Console.WriteLine();
                            Console.WriteLine("Напишите, сколько нужно помяукать коту: ");
                            int a = Convert.ToInt32(validator.check_int(Console.ReadLine()));                         
                            Console.WriteLine(cat1.Meow(a));

                            Console.WriteLine();

                            // 2 задание
                            Cat cat2 = new Cat("Мурзик");
                            Cat cat3 = new Cat("Сэм");

                            FireCat fireCat1 = new FireCat("Дракоша");

                            List<IMeow> meowList = new List<IMeow> { cat1, cat2, cat3, fireCat1 };

                            Cat.MakeAllMeow(meowList);
                            Console.WriteLine();

                            // 3 задание 

                            Cat cat4 = new Cat("Барсик");
                            Cat cat5 = new Cat("Марс");

                            CountMeow countingCat1 = new CountMeow(cat4);
                            CountMeow countingCat2 = new CountMeow(cat5);

                            //List<IMeow> list = new List<IMeow> { countingCat1, countingCat2 };
                            //Cat.CountMeows(list);

                            List<IMeow> list = new List<IMeow> { countingCat1 };
                            Cat.CountMeows(list, 5);


                            Console.WriteLine();
                            Console.WriteLine("{0} мяукал {1} раз", cat4.Name, countingCat1.meowCount);
                            Console.WriteLine();
                            Console.WriteLine("{0} мяукал {1} раз", cat5.Name, countingCat2.meowCount);

                            break;
                        }


                    case 2:
                        {
                            Console.WriteLine("Введите числитель и знаменатель для 1 дроби\nЕсли вы хотите выполнить операцию с числом, то для знаменателя введите цифру 1: ");
                            Fraction fr1 = new Fraction(Convert.ToInt32(validator.check_int(Console.ReadLine())), Convert.ToInt32(validator.check_int(Console.ReadLine())));
                            Console.WriteLine("Введите числитель и знаменатель для 2 дроби\nЕсли вы хотите выполнить операцию с числом, то для знаменателя введите цифру 1: ");
                            Fraction fr2 = new Fraction(Convert.ToInt32(validator.check_int(Console.ReadLine())), Convert.ToInt32(validator.check_int(Console.ReadLine())));
                            Console.WriteLine("Введите числитель и знаменатель для 3 дроби\nЕсли вы хотите выполнить операцию с числом, то для знаменателя введите цифру 1: ");
                            Fraction fr3 = new Fraction(Convert.ToInt32(validator.check_int(Console.ReadLine())), Convert.ToInt32(validator.check_int(Console.ReadLine())));
                            Console.WriteLine("Введите числитель и знаменатель для 4 дроби\nЕсли вы хотите выполнить операцию с числом, то для знаменателя введите цифру 1: ");
                            Fraction fr4 = new Fraction(Convert.ToInt32(validator.check_int(Console.ReadLine())), Convert.ToInt32(validator.check_int(Console.ReadLine())));

                            Fraction fr5 = fr1 + fr2;
                            Console.WriteLine();
                            Console.WriteLine("Итоговый результат:");
                            Console.WriteLine("Сумма 1 и 2 дроби: " + fr1 + " + " + fr2 + " = " + fr5);
                            fr5 = fr2 - fr4;
                            Console.WriteLine();
                            Console.WriteLine("Разность 2 и 4 дроби: " + fr2 + " - " + fr4 + " = " + fr5);
                            fr5 = fr3 * fr1;
                            Console.WriteLine();
                            Console.WriteLine("Умножение 3 дроби на 1: " + fr3 + " * " + fr1 + " = " + fr5);
                            fr5 = fr4 / fr3;
                            Console.WriteLine();
                            Console.WriteLine("Деление 4 дроби на 3: " + fr4 + " / " + fr3 + " = " + fr5);
                            bool flag = fr1.Equals(fr2);
                            Console.WriteLine();
                            Console.WriteLine("Равны ли дроби 1 и 2: " + flag);
                            Console.WriteLine();

                            Fraction original = new Fraction(1, 2);
                            Fraction cloned = (Fraction)original.Clone();
                            // cloned — отдельный объект с теми же значениями полей

                            Console.WriteLine("Клон 1 дроби: " + cloned);

                            Console.WriteLine();

                            Fraction fr = new Fraction(1, 5);
                            CachedFraction cached = new CachedFraction(fr);
                            Console.WriteLine(cached.GetDoubleValue()); // Вычисляет и кеширует 0.2
                            Console.WriteLine(cached.GetDoubleValue()); // Берёт из кеша 0.2

                            fr.Numerator = 2; // Меняем дробь
                            cached.InvalidateCache(); // Сбрасываем кеш
                            Console.WriteLine(cached.GetDoubleValue()); // Вычисляет заново 0.4
                            break;
                        }

                    default:
                        Console.WriteLine("Неверный номер задания. Пожалуйста, выберите 1, 2 или 0 для выхода.");
                        break;
                }
            }
            if (!exitProgram)
            {
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}
