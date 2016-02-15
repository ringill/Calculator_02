using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presentation.ViewModels
{
    /// <summary>
    /// Описание операции
    /// </summary>
    public class OperationDescriptionViewModel
    {
        /// <summary>
        /// Время операции
        /// </summary>
        public string OperationTime { get; set; }

        /// <summary>
        /// Аргумент 1
        /// </summary>
        public string Argument1 { get; set; }

        /// <summary>
        /// Аргумент 2
        /// </summary>
        public string Argument2 { get; set; }

        /// <summary>
        /// Результат операции
        /// </summary>
        public string OperationResult { get; set; }

        /// <summary>
        /// Тип операции
        /// </summary>
        public string OperationType { get; set; }

    }
}
