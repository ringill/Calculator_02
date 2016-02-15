using Calculator.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presentation.AbstractPresenters
{
    public interface IPresenter
    {
        /// <summary>
        /// Вычисление
        /// </summary>
        /// <param name="model">ViewModel с данными полученным от UI</param>
        /// <returns>результат операции (строка)</returns>
        string Calculation(CalculationViewModel model);

        /// <summary>
        /// Получение "описаний операций"
        /// </summary>
        /// <returns>список ViewModel с "описаниями операций"</returns>
        IEnumerable<OperationDescriptionViewModel> Get5();
    }
}
