using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    /// <summary>
    /// Интерфейс для объектов, способных издавать звук мяуканья.
    /// </summary>
    /// <remarks>
    /// Реализуется классами <see cref="Cat"/>, <see cref="FireCat"/>, <see cref="CountMeow"/>
    /// и другими потенциальными "мяукающими" сущностями.
    /// Позволяет работать с разными типами мяукающих объектов единообразно.
    /// </remarks>
    public interface IMeow
    {
        /// <summary>
        /// Издаёт звук мяуканья (обычно выводя его в консоль).
        /// </summary>
        /// <remarks>
        /// Конкретная реализация может варьировать текст и формат вывода.
        /// </remarks>
        void meow();
    }
}
