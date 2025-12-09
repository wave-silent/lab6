using System;

namespace lab6
{
    /// <summary>
    /// Представляет огненного кота — специализированную версию кота с особым мяуканьем.
    /// </summary>
    /// <remarks>
    /// Наследует функциональность мяуканья от интерфейса <see cref="IMeow"/>,
    /// но выводит уникальное сообщение с упоминанием огня.
    /// </remarks>
    public class FireCat : IMeow
    {
        private string _name;

        /// <summary>
        /// Имя огненного кота. Не может быть пустым или null.
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
                        Console.WriteLine("У огненного кота не может не быть имени!");
                        Console.Write("Введите имя огненного кота: ");
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
        /// Создаёт нового огненного кота с указанным именем.
        /// </summary>
        /// <param name="name">Имя огненного кота. Не может быть пустым.</param>
        /// <exception cref="ArgumentNullException">
        /// Фактически не выбрасывается, но логика свойства <see cref="Name"/> обрабатывает пустые значения.
        /// </exception>
        public FireCat(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Издаёт огненное мяуканье, выводя в консоль сообщение с упоминанием огня.
        /// </summary>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IMeow"/>.
        /// </remarks>
        public void meow()
        {
            Console.WriteLine("{0}: огонек-мяу!", Name);
        }
    }
}
