using System;
using Calculator.Utils;

namespace Calculator.Domain.ValueObjects
{
        /// <summary>
        /// Описание операции
        /// </summary>
        public class OperationDescription
        {
            /// <summary>
            /// Аргумент 1
            /// </summary>
            public int Argument1 { get; set; }

            /// <summary>
            /// Аргумент 2
            /// </summary>
            public int Argument2 { get; set; }

            /// <summary>
            /// Тип операции
            /// </summary>
            public OperationTypes OperationType { get; set; }

            /// <summary>
            /// Результат операции
            /// </summary>
            public decimal OperationResult { get; set; }

            /// <summary>
            /// Время операции
            /// </summary>
            public DateTime OperationTime { get; set; }
        }
}
