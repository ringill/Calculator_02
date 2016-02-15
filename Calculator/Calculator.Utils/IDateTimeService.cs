using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utils
{
    /// <summary>
    /// Интерфейс необходим для упрощения юнит-тестирования
    /// методов служб, внутри которых используется DateTime.Now
    /// </summary>
    public interface IDateTimeService
    {
        DateTime DateTimeNow();
    }
}
