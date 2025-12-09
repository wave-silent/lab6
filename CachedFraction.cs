using System;

namespace lab6
{
    /// <summary>
    /// Кеширующая обёртка для дроби, реализующая интерфейс <see cref="IFraction"/>.
    /// </summary>
    /// <remarks>
    /// Хранит десятичное значение дроби в кеше и пересчитывает его только при первом запросе
    /// или после изменения числителя/знаменателя. Повторные вызовы <see cref="GetDoubleValue"/>
    /// возвращают закешированное значение без пересчёта.
    /// </remarks>
    public class CachedFraction : IFraction
    {
        private Fraction _fraction;
        private double? _cachedValue;

        /// <summary>
        /// Создаёт новую кеширующую обёртку для указанной дроби.
        /// </summary>
        /// <param name="fr">Исходная дробь, которую нужно обернуть. Не может быть <c>null</c>.</param>
        /// <exception cref="ArgumentNullException">
        /// Выбрасывается, если <paramref name="fr"/> равен <c>null</c>.
        /// </exception>
        /// <remarks>
        /// После создания кеш инициализируется как пустой (<c>null</c>).
        /// </remarks>
        public CachedFraction(Fraction fr)
        {
            // чтобы избежать создания CachedFraction с null внутри, что привело бы к ошибкам при попытке доступа к _fraction.Numerator/Denominator.
            if (fr is null)
            {
                throw new ArgumentNullException(nameof(fr));
            }
            _fraction = fr;

            _cachedValue = null;
        }

        /// <summary>
        /// Возвращает десятичное значение дроби, используя кеширование.
        /// </summary>
        /// <returns>
        /// Десятичное значение дроби. При первом вызове вычисляется и сохраняется в кеш,
        /// при последующих — возвращается из кеша.
        /// </returns>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IFraction"/>.
        /// </remarks>
        public double GetDoubleValue()
        {
            {
                // Проверка на null
                if (!_cachedValue.HasValue)
                {
                    _cachedValue = (double)_fraction.Numerator / _fraction.Denominator;
                }
                // .Value — возвращает само значение типа double (если оно есть).
                return _cachedValue.Value;
            }
        }

        /// <summary>
        /// Устанавливает новый числитель для обёрнутой дроби и сбрасывает кеш.
        /// </summary>
        /// <param name="numerator">Новый числитель.</param>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IFraction"/>.
        /// После изменения числителя ранее закешированное значение становится невалидным.
        /// </remarks>
        public void SetNumerator(int numerator)
        {
            _fraction.Numerator = numerator;
            InvalidateCache();
        }

        /// <summary>
        /// Устанавливает новый знаменатель для обёрнутой дроби и сбрасывает кеш.
        /// </summary>
        /// <param name="denominator">Новый знаменатель. Не может быть нулём.</param>
        /// <remarks>
        /// Реализация метода интерфейса <see cref="IFraction"/>.
        /// После изменения знаменателя ранее закешированное значение становится невалидным.
        /// </remarks>
        public void SetDenominator(int denominator)
        {
            _fraction.Denominator = denominator;
            InvalidateCache();
        }

        // Метод для сброса кеша
        /// <summary>
        /// Сбрасывает кешированное значение дроби.
        /// </summary>
        /// <remarks>
        /// Вызывается автоматически при изменении числителя или знаменателя через
        /// <see cref="SetNumerator(int)"/> или <see cref="SetDenominator(int)"/>.
        /// </remarks>
        public void InvalidateCache()
        {
            _cachedValue = null;
        }
    }
}
