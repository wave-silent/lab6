using System;
using System.Collections.Generic;

namespace lab6
{
    /// <summary>
    /// Представляет кота с именем и возможностью мяукать.
    /// </summary>
    internal class Cat : IMeow
    {
        private string _name;

        /// <summary>
        /// Имя кота. Не может быть пустым или null.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != "" && value != null && string.IsNullOrEmpty(value) == false)
                {
                    _name = value;
                }
                else
                {
                    bool flag = true;
                    while (flag)
                    {
                        Console.WriteLine("У кота не может не быть имени!");
                        Console.Write("Введите имя кота: ");
                        value = Console.ReadLine();
                        if (value != "" && value != null && string.IsNullOrEmpty(value) == false)
                        {
                            _name = value;
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Создает нового кота с указанным именем.
        /// </summary>
        /// <param name="name">Имя кота</param>
        public Cat(string name)
        {
            Name = name;
        }

        // Реализация интерфейса 
        /// <summary>
        /// Мяукает один раз, выводя сообщение в консоль в формате "{Имя}: мяу!".
        /// </summary>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IMeow"/>.
        /// </remarks>
        public void meow()
        {
            Console.WriteLine("{0}: мяу!", Name);
        }

        /// <summary>
        /// Возвращает строковое представление кота в формате “кот: Имя”
        /// </summary>
        /// <returns>
        /// Строка с именем кота и префиксом "Кот:".
        /// </returns>
        public string View_representation_cat()
        {
            return "Кот: " + Name;
        }

        /// <summary>
        /// Возвращает строку с однократным мяуканьем кота.
        /// </summary>
        /// <returns>Строка в формате "Имя: мяу!".</returns>
        public string Meow()
        {
            return Name + ": мяу!";
        }

        /// <summary>
        /// Возвращает строку с мяуканьем кота указанное количество раз.
        /// </summary>
        /// <param name="n">Количество повторений "мяу". Должно быть положительным.</param>
        /// <returns>Строка вида "Имя: мяу-мяу-...-мяу!" с n повторений.</returns>
        public string Meow(int n)
        {
            string result = Name + ": ";
            for (int i = 0; i < n; i++)
            {
                if (i == (n-1))
                {
                    result += "мяу!";
                }
                else 
                {
                    result += "мяу-";
                }     
            }

            return result;
        }

        // IEnumerable<T> — это обобщённый интерфейс, который представляют последовательность элементов типа T
        /// <summary>
        /// Вызывает мяуканье у всех объектов, реализующих интерфейс <see cref="IMeow"/>, в переданной коллекции.
        /// </summary>
        /// <param name="meowers">
        /// Коллекция мяукающих объектов (<see cref="IEnumerable{T}"/> где T — <see cref="IMeow"/>).
        /// </param>
        /// <remarks>
        /// Использует интерфейс <see cref="IEnumerable{T}"/> для работы с любыми коллекциями (массив, список и т.д.).
        /// </remarks>
        public static void MakeAllMeow(IEnumerable<IMeow> meowers)
        {
            foreach (IMeow meower in meowers)
            {
                meower.meow();
            }
        }

        // 3 задание
        // Но этот метод не считает по каждому коту отдельно, а только общее количество вызовов.
        // По заданию нужно знать, сколько раз мяукал конкретный кот.
        /// <summary>
        /// Вызывает мяуканье у каждого объекта в коллекции один раз и возвращает общее количество вызовов.
        /// </summary>
        /// <param name="meowers">Коллекция мяукающих объектов.</param>
        /// <returns>Общее количество произведённых мяуканий (равно количеству объектов в коллекции).</returns>
        /// <remarks>
        /// Не считает мяуканья для каждого объекта отдельно, только общую сумму.
        /// </remarks>
        public static int CountMeows(IEnumerable<IMeow> meowers)
        {
            int total = 0;
            foreach (var meower in meowers)
            {
                meower.meow();
                total++;
            }
            return total;
        }

        /// <summary>
        /// Вызывает мяуканье у каждого объекта в коллекции заданное количество раз и возвращает общее количество вызовов.
        /// </summary>
        /// <param name="meowers">Коллекция мяукающих объектов.</param>
        /// <param name="timesPerMeower">Количество мяуканий для каждого объекта.</param>
        /// <returns>Общее количество произведённых мяуканий (равно количеству объектов × timesPerMeower).</returns>
        public static int CountMeows(IEnumerable<IMeow> meowers, int timesPerMeower)
        {
            int total = 0;
            foreach (var meower in meowers)
            {
                for (int i = 0; i < timesPerMeower; i++)
                {
                    meower.meow();
                    total++;
                }
            }
            return total;
        }

        /// <summary>
        /// Возвращает строковое представление кота.
        /// </summary>
        /// <returns>Строка в формате "Кот: {Имя}".</returns>
        /// <remarks>
        /// Использует метод <see cref="View_representation_cat"/>.
        /// </remarks>
        public override string ToString()
        {
            return View_representation_cat();
        }



    }
}
