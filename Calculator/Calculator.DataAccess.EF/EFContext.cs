using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DataAccess.EF
{
    public class DefaultConnection : DbContext
    {
        public DbSet<EF.OperationDescription> OperationDescriptions { get; set; }
    }

    public class OperationDescription
    {
        /// <summary>
        /// Идентифкатор "описания операции"
        /// </summary>
        public int OperationDescriptionId { get; set; }

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
        public string OperationType { get; set; }

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
