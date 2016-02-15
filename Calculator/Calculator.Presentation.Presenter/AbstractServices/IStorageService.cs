using Calculator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presentation.Presenter.AbstractServices
{
    public interface IStorageService
    {
        /// <summary>
        /// Записывает "описание операции" в хранилище
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <param name="operationResult">результат операции</param>
        /// <param name="operationType">тип операции</param>
        void Save(int argument1,
            int argument2,
            decimal operationResult,
            OperationTypes operationType);

        /// <summary>
        /// Получает из хранилища все "описания операции"
        /// </summary>
        /// <returns>список "описаний операций"</returns>
        IEnumerable<Dictionary<string, string>> Get5();

        /// <summary>
        /// Получает из хранилища несколько последний "описаний операций"
        /// </summary>
        /// <param name="n">количество последних "описаний операций"</param>
        /// <returns>список последних "описаний операций"</returns>
        //IEnumerable<OperationDescription> GetN(int n);
    }
}
