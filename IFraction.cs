using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    /// <summary>
    /// Интерфейс для работы с дробями, поддерживающий получение десятичного значения
    /// и изменение числителя/знаменателя.
    /// </summary>
    /// <remarks>
    /// Реализуется классами <see cref="Fraction"/> и <see cref="CachedFraction"/>.
    /// Позволяет единообразно работать с разными реализациями дробей.
    /// </remarks>
    public interface IFraction
    {
        /// <summary>
        /// Возвращает десятичное значение дроби.
        /// </summary>
        /// <returns>Десятичное число, полученное делением числителя на знаменатель.</returns>
        /// <remarks>
        /// В зависимости от реализации может использовать кеширование.
        /// </remarks>
        double GetDoubleValue();

        /// <summary>
        /// Устанавливает новое значение числителя.
        /// </summary>
        /// <param name="numerator">Новый числитель.</param>
        /// <remarks>
        /// После изменения числителя ранее вычисленное значение (например, в кеше) должно считаться невалидным.
        /// </remarks>
        void SetNumerator(int numerator);

        /// <summary>
        /// Устанавливает новое значение знаменателя.
        /// </summary>
        /// <param name="denominator">Новый знаменатель. Не должен быть равен нулю.</param>
        /// <remarks>
        /// После изменения знаменателя ранее вычисленное значение (например, в кеше) должно считаться невалидным.
        /// </remarks>
        void SetDenominator(int denominator);
    }
}
