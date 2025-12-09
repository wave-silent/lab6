using System;

namespace lab6
{
    /// <summary>
    /// Представляет математическую дробь с целыми числителем и знаменателем.
    /// </summary>
    /// <remarks>
    /// Поддерживает арифметические операции (+, -, *, /), сравнение, клонирование,
    /// а также реализует интерфейсы <see cref="ICloneable"/> и <see cref="IFraction"/>.
    /// Знаменатель не может быть равен нулю.
    /// </remarks>
    public class Fraction : ICloneable, IFraction
    {
        private int _numerator;
        private int _denominator;

        /// <summary>
        /// Числитель дроби.
        /// </summary>
        /// <value>Целое число (может быть отрицательным).</value>
        public int Numerator
        {
            get
            {
                return _numerator;
            }
            set
            {
                _numerator = value;
            }
        }

        /// <summary>
        /// Знаменатель дроби.
        /// </summary>
        /// <value>
        /// Целое число, не равное нулю. При попытке установки нуля запрашивает новое значение у пользователя.
        /// </value>
        /// <exception cref="DivideByZeroException">
        /// Фактически не выбрасывается, но логика свойства обрабатывает нулевое значение через пользовательский ввод.
        /// </exception>
        public int Denominator
        {
            get
            {
                return _denominator;
            }
            set
            {

                if (value != 0)
                {
                    _denominator = value;
                }
                else
                {
                    Validator validator = new Validator();
                    bool flag = true;
                    while (flag)
                    {
                        Console.WriteLine("Знаменатель не может быть равен нулю, так как делить на ноль нельзя!");
                        Console.Write("Введите число: ");
                        value = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        Console.WriteLine();
                        if (value != 0)
                        {
                            _denominator = value;
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
        /// Создаёт новую дробь с указанными числителем и знаменателем.
        /// </summary>
        /// <param name="numerator">Числитель дроби.</param>
        /// <param name="denominator">Знаменатель дроби. Не может быть нулём.</param>
        /// <remarks>
        /// Если знаменатель равен нулю, будет запрошен новый через свойство <see cref="Denominator"/>.
        /// </remarks>
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }


        /// <summary>
        /// Возвращает десятичное значение дроби.
        /// </summary>
        /// <returns>Десятичное число, полученное делением числителя на знаменатель.</returns>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IFraction"/>.
        /// </remarks>
        public double GetDoubleValue()
        {
            return (double)Numerator / Denominator;
        }

        /// <summary>
        /// Устанавливает новое значение числителя.
        /// </summary>
        /// <param name="numerator">Новый числитель.</param>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IFraction"/>.
        /// </remarks>
        public void SetNumerator(int numerator)
        {
            Numerator = numerator;
        }

        /// <summary>
        /// Устанавливает новое значение знаменателя.
        /// </summary>
        /// <param name="denominator">Новый знаменатель. Не может быть нулём.</param>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IFraction"/>.
        /// Если передано нулевое значение, будет запрошен новый знаменатель у пользователя.
        /// </remarks>
        public void SetDenominator(int denominator)
        {
            Denominator = denominator;
        }

        /// <summary>
        /// Создаёт и возвращает копию текущей дроби.
        /// </summary>
        /// <returns>Новый объект <see cref="Fraction"/> с такими же значениями числителя и знаменателя.</returns>
        /// <remarks>
        /// Реализация интерфейса <see cref="ICloneable"/>.
        /// </remarks>
        public object Clone()
        {
            return new Fraction(this.Numerator, this.Denominator);
        }

        /// <summary>
        /// Возвращает строковое представление дроби.
        /// </summary>
        /// <returns>
        /// Строка в одном из форматов:
        /// "0" — если числитель равен 0;
        /// "{числитель}" — если знаменатель равен 1;
        /// "{числитель}/{знаменатель}" — в остальных случаях.
        /// </returns>
        public string View_representation_fraction()
        {
            if (Numerator == 0)
            {
                return "0";
            }
            if (Denominator == 1)
            {
                return Convert.ToString(Numerator);
            }
            else
            {
                return Numerator + "/" + Denominator;
            }
        }

        /// <summary>
        /// Складывает две дроби или дробь с целым числом.
        /// </summary>
        /// <param name="fr1">Первая дробь.</param>
        /// <param name="fr2">Вторая дробь (может иметь знаменатель 1 для представления целого числа).</param>
        /// <returns>Новая дробь — результат сложения.</returns>
        /// <remarks>
        /// Поддерживает случаи:
        /// - Одна из дробей равна нулю.
        /// - Дроби с одинаковым знаменателем.
        /// - Дроби с разными знаменателями (приводит к общему знаменателю).
        /// </remarks>
        public static Fraction operator +(Fraction fr1, Fraction fr2)
        {
            if (fr2.Denominator == 1)
            {
                if (fr2.Numerator == 0 && fr1.Numerator != 0)
                {
                    return new Fraction(fr1.Numerator, fr1.Denominator);
                }
                else if (fr2.Numerator == 0 && fr1.Numerator == 0)
                {
                    return new Fraction(0, 1); 
                }
                else
                {
                    int summary_numerator = fr1.Numerator + (fr2.Numerator * fr1.Denominator);
                    int summary_denominator = fr1.Denominator;
                    return new Fraction(summary_numerator, summary_denominator);
                }
            }
            else
            {
                if (fr1.Numerator == 0)
                {
                    return new Fraction(fr2.Numerator, fr2.Denominator);
                }
                else if (fr1.Denominator == fr2.Denominator)
                {
                    int summary_numerator = fr1.Numerator + fr2.Numerator;
                    int summary_denominator = fr2.Denominator;
                    return new Fraction(summary_numerator, summary_denominator);
                }
                else
                {
                    int max_denominator;
                    int min_denominator;
                    int total;
                    max_denominator = Math.Max(fr1.Denominator, fr2.Denominator);
                    min_denominator = Math.Min(fr1.Denominator, fr2.Denominator);

                    if (max_denominator % min_denominator == 0 && max_denominator == fr1.Denominator)
                    {
                        int summary_numerator = fr1.Numerator + fr2.Numerator * (max_denominator / min_denominator);
                        int summary_denominator = max_denominator;
                        return new Fraction(summary_numerator, summary_denominator);
                    }

                    else if (max_denominator % min_denominator == 0 && max_denominator == fr2.Denominator)
                    {
                        int summary_numerator = fr1.Numerator * (max_denominator / min_denominator) + fr2.Numerator;
                        int summary_denominator = max_denominator;
                        return new Fraction(summary_numerator, summary_denominator);
                    }
                    else if (max_denominator % min_denominator != 0 && max_denominator == fr1.Denominator)
                    {
                        total = max_denominator * min_denominator;
                        int summary_numerator = fr1.Numerator * (total / max_denominator) + fr2.Numerator * (total / min_denominator);
                        int summary_denominator = total;
                        return new Fraction(summary_numerator, summary_denominator);
                    }
                    else
                    {
                        total = max_denominator * min_denominator;
                        int summary_numerator = fr1.Numerator * (total / min_denominator) + fr2.Numerator * (total / max_denominator);
                        int summary_denominator = total;
                        return new Fraction(summary_numerator, summary_denominator);
                    }
                }
            }
        }

        /// <summary>
        /// Вычитает одну дробь из другой или вычитает целое число из дроби.
        /// </summary>
        /// <param name="fr1">Уменьшаемая дробь.</param>
        /// <param name="fr2">Вычитаемая дробь (может иметь знаменатель 1 для представления целого числа).</param>
        /// <returns>Новая дробь — результат вычитания.</returns>
        /// <remarks>
        /// Логика аналогична сложению, но с операцией вычитания.
        /// </remarks>
        public static Fraction operator -(Fraction fr1, Fraction fr2)
        {
            if (fr2.Denominator == 1)
            {
                if (fr2.Numerator == 0 && fr1.Numerator != 0)
                {
                    return new Fraction(fr1.Numerator, fr1.Denominator);
                }
                else if (fr2.Numerator == 0 && fr1.Numerator == 0)
                {
                    return new Fraction(0, 1);
                }
                else
                {
                    int summary_numerator = fr1.Numerator - (fr2.Numerator * fr1.Denominator);
                    int summary_denominator = fr1.Denominator;
                    return new Fraction(summary_numerator, summary_denominator);
                }
            }
            else
            {
                if (fr1.Numerator == 0)
                {
                    return new Fraction(-fr2.Numerator, fr2.Denominator);
                }
                else if (fr1.Denominator == fr2.Denominator)
                {
                    int summary_numerator = fr1.Numerator - fr2.Numerator;
                    int summary_denominator = fr2.Denominator;
                    return new Fraction(summary_numerator, summary_denominator);
                }
                else
                {
                    int max_denominator;
                    int min_denominator;
                    int total;
                    max_denominator = Math.Max(fr1.Denominator, fr2.Denominator);
                    min_denominator = Math.Min(fr1.Denominator, fr2.Denominator);

                    if (max_denominator % min_denominator == 0 && max_denominator == fr1.Denominator)
                    {
                        int summary_numerator = fr1.Numerator - fr2.Numerator * (max_denominator / min_denominator);
                        int summary_denominator = max_denominator;
                        return new Fraction(summary_numerator, summary_denominator);
                    }

                    else if (max_denominator % min_denominator == 0 && max_denominator == fr2.Denominator)
                    {
                        int summary_numerator = fr1.Numerator * (max_denominator / min_denominator) - fr2.Numerator;
                        int summary_denominator = max_denominator;
                        return new Fraction(summary_numerator, summary_denominator);
                    }
                    else if (max_denominator % min_denominator != 0 && max_denominator == fr1.Denominator)
                    {
                        total = max_denominator * min_denominator;
                        int summary_numerator = fr1.Numerator * (total / max_denominator) - fr2.Numerator * (total / min_denominator);
                        int summary_denominator = total;
                        return new Fraction(summary_numerator, summary_denominator);
                    }
                    else
                    {
                        total = max_denominator * min_denominator;
                        int summary_numerator = fr1.Numerator * (total / min_denominator) - fr2.Numerator * (total / max_denominator);
                        int summary_denominator = total;
                        return new Fraction(summary_numerator, summary_denominator);
                    }
                }
            }
        }

        /// <summary>
        /// Умножает дробь на целое число.
        /// </summary>
        /// <param name="fr1">Дробь.</param>
        /// <param name="n">Целое число.</param>
        /// <returns>
        /// Новая дробь — результат умножения.
        /// Если <paramref name="n"/> равен 0, возвращается дробь 0/1.
        /// </returns>
        public static Fraction operator *(Fraction fr1, int n)
        {
            if (n == 0)
            {
                return new Fraction(0, 1);
            }
            else
            {
                int summary_numerator = fr1.Numerator * n;
                int summary_denominator = fr1.Denominator * 1;
                if (summary_numerator == 0)
                {
                    return new Fraction(0, 1);
                }
                else
                {
                    return new Fraction(summary_numerator, summary_denominator);
                }
            }
        }

        /// <summary>
        /// Умножает целое число на дробь (коммутативная операция).
        /// </summary>
        /// <param name="n">Целое число.</param>
        /// <param name="fr1">Дробь.</param>
        /// <returns>
        /// Новая дробь — результат умножения.
        /// Если <paramref name="n"/> равен 0, возвращается дробь 0/1.
        /// </returns>
        /// <remarks>
        /// Реализует коммутативность умножения.
        /// </remarks>
        public static Fraction operator *(int n, Fraction fr1)
        {
            if (n == 0)
            {
                return new Fraction(0, 1);
            }
            else
            {
                int summary_numerator = fr1.Numerator * n;
                int summary_denominator = fr1.Denominator * 1;
                if (summary_numerator == 0)
                {
                    return new Fraction(0, 1);
                }
                else
                {
                    return new Fraction(summary_numerator, summary_denominator);
                }
            }
        }

         /// <summary>
        /// Умножает две дроби.
        /// </summary>
        /// <param name="fr1">Первая дробь.</param>
        /// <param name="fr2">Вторая дробь.</param>
        /// <returns>Новая дробь — результат умножения.</returns>
        /// <remarks>
        /// Если результат умножения числителей равен 0, возвращается дробь 0/1.
        /// </remarks>
        public static Fraction operator *(Fraction fr1, Fraction fr2)
        {
            int summary_numerator = fr1.Numerator * fr2.Numerator;
            int summary_denominator = fr1.Denominator * fr2.Denominator;
            if (summary_numerator == 0)
            {
                return new Fraction(0, 1);
            }
            else
            {
                return new Fraction(summary_numerator, summary_denominator);
            }
        }

        /// <summary>
        /// Делит дробь на целое число.
        /// </summary>
        /// <param name="fr1">Делимая дробь.</param>
        /// <param name="n">Делитель (целое число).</param>
        /// <returns>Новая дробь — результат деления.</returns>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если <paramref name="n"/> равен 0.
        /// </exception>
        public static Fraction operator /(Fraction fr1, int n)
        {
            if (n == 0)
            {
                throw new ArgumentException("Denominator must not be zero.", nameof(n));
            }
            else
            {
                int summary_numerator = fr1.Numerator * 1;
                int summary_denominator = fr1.Denominator * n;
                if (summary_numerator == 0)
                {
                    return new Fraction(0, 1);
                }
                else
                {
                    return new Fraction(summary_numerator, summary_denominator);
                }
            }
        }

        /// <summary>
        /// Делит целое число на дробь.
        /// </summary>
        /// <param name="n">Делимое (целое число).</param>
        /// <param name="fr1">Делитель (дробь).</param>
        /// <returns>Новая дробь — результат деления.</returns>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если <paramref name="n"/> равен 0 (фактически — если дробь равна 0, но здесь проверяется n).
        /// </exception>
        /// <remarks>
        /// Операция нестандартная; возможно, в задании требуется для симметрии.
        /// </remarks>
        public static Fraction operator /(int n, Fraction fr1)
        {
            if (n == 0)
            {
                throw new ArgumentException("Denominator must not be zero.", nameof(n));
            }
            else
            {
                int summary_numerator = fr1.Numerator * 1;
                int summary_denominator = fr1.Denominator * n;
                if (summary_numerator == 0)
                {
                    return new Fraction(0, 1);
                }
                else
                {
                    return new Fraction(summary_numerator, summary_denominator);
                }
            }
        }

        /// <summary>
        /// Делит одну дробь на другую.
        /// </summary>
        /// <param name="fr1">Делимая дробь.</param>
        /// <param name="fr2">Делитель (дробь).</param>
        /// <returns>Новая дробь — результат деления.</returns>
        /// <remarks>
        /// Выполняется как умножение первой дроби на перевёрнутую вторую.
        /// </remarks>
        public static Fraction operator /(Fraction fr1, Fraction fr2)
        {
            int summary_numerator = fr1.Numerator * fr2.Denominator;
            int summary_denominator = fr1.Denominator * fr2.Numerator;
            if (summary_numerator == 0)
            {
                return new Fraction(0, 1);
            }
            else
            {
                return new Fraction(summary_numerator, summary_denominator);
            }
        }


        /// <summary>
        /// Определяет, равны ли две дроби по значению.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>
        /// <c>true</c>, если <paramref name="obj"/> является дробью с одинаковыми числителем и знаменателем; иначе <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Переопределяет метод <see cref="object.Equals(object)"/>.
        /// </remarks>
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this.Numerator == other.Numerator && this.Denominator == other.Denominator;
            }
            return false;
        }

        /// <summary>
        /// Возвращает хеш-код дроби.
        /// </summary>
        /// <returns>Хеш-код, вычисленный на основе числителя и знаменателя.</returns>
        /// <remarks>
        /// Переопределяет метод <see cref="object.GetHashCode"/>.
        /// Использует оператор XOR (^) для объединения хешей числителя и знаменателя.
        /// </remarks>
        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }

        /// <summary>
        /// Возвращает строковое представление дроби.
        /// </summary>
        /// <returns>Строковое представление, полученное через <see cref="View_representation_fraction"/>.</returns>
        /// <remarks>
        /// Переопределяет метод <see cref="object.ToString"/>.
        /// </remarks>
        public override string ToString()
        {
            return View_representation_fraction();
        }
    }
}

