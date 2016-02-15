using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Domain.ValueObjects;

namespace Calculator.Domain.AbstractRepositories
{
    public interface IRepository
    {
        /// <summary>
        /// Записывает "описание операции" в хранилище
        /// </summary>
        /// <param name="operationDescription">"описание операции"</param>
        void Save(OperationDescription operationDescription);

        /// <summary>
        /// Получает из хранилища 5 последний "описаний операций"
        /// </summary>
        /// <returns>список 5и последних "описаний операций"</returns>
        IEnumerable<OperationDescription> Get5OperationDescription();
    }
}
