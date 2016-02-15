using Calculator.Domain.AbstractRepositories;
using Calculator.Domain.ValueObjects;
using Calculator.Presentation.Presenter.AbstractServices;
using Calculator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Services
{
    public class StorageService : IStorageService
    {
        #region Свойства

        /// <summary>
        /// хранилище
        /// </summary>
        IRepository repository;
        /// <summary>
        /// экземпляр утилитарного класса для получения текущего времени
        /// </summary>
        IDateTimeService dateTimeService;

        #endregion

        #region Конструкторы

        public StorageService(IRepository repository, IDateTimeService dateTimeService)
        {
            this.repository = repository;
            this.dateTimeService = dateTimeService;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Записывает "описание операции" в хранилище
        /// </summary>
        /// <param name="operationDescription">"описание операции"</param>
        public void Save(int argument1,
            int argument2,
            decimal operationResult,
            OperationTypes operationType)
        {
            var operationDescription = new OperationDescription
            {
                //аргумент 1
                Argument1 = argument1,
                //аргумент 2
                Argument2 = argument2,
                //тип операции
                OperationType = operationType,
                //результат операции
                OperationResult = operationResult,
                //время операции (проставляется текущее)
                OperationTime = dateTimeService.DateTimeNow()
            };

            //сохраняем "описание операции" в хранилище
            this.Save(operationDescription);
        }

        /// <summary>
        /// Получает из хранилища все "описания операции"
        /// </summary>
        /// <returns>список "описаний операций" (в виде списка словарей)</returns>
        public IEnumerable<Dictionary<string,string>> Get5()
        {
            //получили "описания операций" типизированные как набор OperationDescription
            var operationDescriptions = repository.Get5OperationDescription();

            //создали список пустых словарей для сохранения полученных 
            //данных в виде строк с целью последующей передачи этих 
            //данных презентеру
            var dictionaries = new List<Dictionary<string, string>>();

            //заполняем список словарей данными
            foreach (var operationDescription in operationDescriptions)
            {
                dictionaries.Add(new Dictionary<string, string>
                {
                    {"Argument1", operationDescription.Argument1.ToString()},
                    {"Argument2", operationDescription.Argument2.ToString()},
                    {"OperationResult", operationDescription.OperationResult.ToString()},
                    {"OperationType", operationDescription.OperationType.ToString()},
                    {"OperationTime", operationDescription.OperationTime.ToString()},
                });
            }

            return dictionaries;
        }

        /// <summary>
        /// Получает из хранилища несколько последний "описаний операций"
        /// </summary>
        /// <param name="n">количество последних "описаний операций"</param>
        /// <returns>список последних "описаний операций"</returns>
        //public IEnumerable<Presentation.Presenter.OperationDescription> GetN(int n)
        //{
        //    throw new NotImplementedException();
        //}

        #region Приватные методы

        /// <summary>
        /// Запуск операции сохранения в отдельном потоке
        /// </summary>
        /// <param name="operationDescription">"описание операции"</param>
        /// <returns></returns>
        private Task Save(OperationDescription operationDescription)
        {
            Task task = Task.Factory.StartNew(() => SaveAsync(operationDescription));
            return task;
        }

        /// <summary>
        /// Операция сохранения
        /// </summary>
        /// <param name="operationDescription">"описание операции"</param>
        private void SaveAsync(OperationDescription operationDescription)
        {
            //служба домена должна записать "описание операции" в хранилище
            this.repository.Save(operationDescription);
        }

        #endregion
        
        #endregion
    }
}
