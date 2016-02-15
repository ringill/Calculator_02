using Calculator.Presentation.AbstractPresenters;
using Calculator.Presentation.Presenter.AbstractServices;
using Calculator.Presentation.ViewModels;
using Calculator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presentation.Presenter
{
    public class Presenter : IPresenter
    {
        #region Свойства

        /// <summary>
        /// служба, делающая расчет
        /// </summary>
        private ICalculationService calculationService;

        /// <summary>
        /// служба работы с хранилищем
        /// </summary>
        private IStorageService storageService;

        #endregion

        #region Конструкторы

        public Presenter(ICalculationService calculationService, IStorageService storageService)
        {
            this.calculationService = calculationService;
            this.storageService = storageService;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Вычисление
        /// </summary>
        /// <param name="model">ViewModel для presenter</param>
        /// <returns>результат операции (строка)</returns>
        public string Calculation(CalculationViewModel model)
        {
            //проверили и типизировали данные из модели
            var argument1 = Converter.IntFromString(model.Argument1,
                "Недопустимое значение первого аргумента.");
            var argument2 = Converter.IntFromString(model.Argument2,
                "Недопустимое значение второго аргумента.");
            var operationType = Converter.OperationTypeFromString(model.SelectedOperationType,
                "Не выбран тип операции.");
            //вызвали службу и заполнили модель результатом операции
            decimal operationResult;
            switch (operationType)
            {
                //Сложение
                case OperationTypes.Addition:
                    operationResult = calculationService.Addition(argument1, argument2);
                    break;
                //Вычитание
                case OperationTypes.Subtraction:
                    operationResult = calculationService.Subtraction(argument1, argument2);
                    break;
                //Умножение
                case OperationTypes.Multiplication:
                    operationResult = calculationService.Multiplication(argument1, argument2);
                    break;
                //Деление
                case OperationTypes.Division:
                    operationResult = calculationService.Division(argument1, argument2);
                    break;
                default:
                    operationResult = 0;
                    throw new Exception("Не удалось получить результат");
            }

            //Сохранение
            storageService.Save(argument1,
                    argument2,
                    operationResult,
                    operationType);
            //возвращаем результат операции
            return operationResult.ToString();
        }

        /// <summary>
        /// Возвращает список представлений ("описание операций")
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OperationDescriptionViewModel> Get5()
        {
            //получаем данные из хранилища в виде набора словарей
            var dictionaries = storageService.Get5();

            //создаем пустой список "описаний операций" (ViewModel)
            var ListOperationDescriptionViewModel = new List<OperationDescriptionViewModel>();

            //проходим через все наборы словарей, полученных из хранилища
            //и заполняем список "описаний операций" (ViewModel) данными
            foreach (var dictionary in dictionaries)
            {
                ListOperationDescriptionViewModel.Add(new OperationDescriptionViewModel
                {
                    Argument1 = dictionary["Argument1"],
                    Argument2 = dictionary["Argument2"],
                    OperationResult = dictionary["OperationResult"],
                    //тип операции сразу преобразовываем в его знаковое представление
                    OperationType = Converter.SymbolFromOperationTypeStringEnglish(
                        dictionary["OperationType"],
                        "Ошибка преобразования названия типа операции в символ типа операции"),
                    OperationTime = dictionary["OperationTime"]
                });
            }

            return ListOperationDescriptionViewModel;
        }    

        #region Приватные методы



        #endregion

        #endregion
    }
}
