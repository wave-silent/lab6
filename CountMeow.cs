using System;

namespace lab6
{
    /// <summary>
    /// Обёртка для подсчёта количества вызовов метода <see cref="meow"/>.
    /// </summary>
    /// <remarks>
    /// Реализует интерфейс <see cref="IMeow"/>, делегируя вызовы обёрнутому объекту
    /// и подсчитывая количество вызовов.
    /// Позволяет узнать, сколько раз конкретный объект мяукал, не изменяя исходный класс.
    /// </remarks>
    internal class CountMeow : IMeow
    {
        // readonly означает, что поле можно присвоить только в конструкторе (или при объявлении), а далее его нельзя изменить.
        private readonly IMeow _wrapped;
        private int _meowCount = 0;

        /// <summary>
        /// Возвращает или устанавливает количество произведённых мяуканий.
        /// </summary>
        /// <value>
        /// Целое число, представляющее количество вызовов <see cref="meow"/>.
        /// </value>
        public int meowCount
        {
            get { return _meowCount; }
            set { _meowCount = value; }
        }

        /// <summary>
        /// Создаёт новую обёртку для подсчёта мяуканий указанного объекта.
        /// </summary>
        /// <param name="meowable">Мяукающий объект, который нужно обернуть. Не может быть <c>null</c>.</param>
        /// <exception cref="ArgumentNullException">
        /// Выбрасывается, если <paramref name="meowable"/> равен <c>null</c>.
        /// </exception>
        /// <remarks>
        /// После создания обёртки все вызовы <see cref="meow"/> будут делегированы
        /// переданному объекту и учтены в счётчике.
        /// </remarks>
        public CountMeow(IMeow meowable)
        {
            if (meowable is null)
                throw new ArgumentNullException(nameof(meowable));

            _wrapped = meowable;
        }

        /// <summary>
        /// Вызывает мяуканье обёрнутого объекта и увеличивает счётчик вызовов.
        /// </summary>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IMeow"/>.
        /// </remarks>
        public void meow()
        {
            _wrapped.meow(); // вызываем оригинальный meow
            meowCount++;     // увеличиваем счётчик
        }
    }
}
