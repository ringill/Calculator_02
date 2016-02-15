using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utils
{
    /// <summary>
    /// Класс дающий информацию о текущем времени
    /// </summary>
    public class DateTimeService : IDateTimeService
    {
        /// <summary>
        /// Отвечает на вопрос "сколько сейчас времени"
        /// </summary>
        /// <returns>текущее дата-время</returns>
        public DateTime DateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
