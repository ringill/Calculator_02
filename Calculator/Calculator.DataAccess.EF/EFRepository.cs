using Calculator.Domain.AbstractRepositories;
using Calculator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DataAccess.EF
{
    public class EFRepository : IRepository
    {
        #region Свойства

        private DefaultConnection _db;

        #endregion

        #region Конструкторы

        public EFRepository()
        {
            _db = new DefaultConnection();
        }

        #endregion

        #region Методы

        public void Save(Domain.ValueObjects.OperationDescription operationDescription)
        {
            _db.OperationDescriptions.Add(new EF.OperationDescription
                {
                    Argument1 = operationDescription.Argument1,
                    Argument2 = operationDescription.Argument2,
                    OperationType = operationDescription.OperationType.ToString(),
                    OperationResult = operationDescription.OperationResult,
                    OperationTime = operationDescription.OperationTime
                });

            _db.SaveChanges();
        }

        public IEnumerable<Domain.ValueObjects.OperationDescription> Get5OperationDescription()
        {
            var last5OperationDescriptions = _db.OperationDescriptions
                .OrderBy(rec => rec.OperationDescriptionId)
                .Skip(Math.Max(0, _db.OperationDescriptions.Count() - 5))
                .Take(5);

            var result = new List<Domain.ValueObjects.OperationDescription>();

            foreach (var efOperationDescription in last5OperationDescriptions)
            {
                var operationDescription = new Domain.ValueObjects.OperationDescription();

                operationDescription.Argument1 = efOperationDescription.Argument1;
                operationDescription.Argument2 = efOperationDescription.Argument2;
                operationDescription.OperationType = Converter.OperationTypeFromStringEnglish(
                    efOperationDescription.OperationType, "Не удалось получить тип операции.");
                operationDescription.OperationResult = efOperationDescription.OperationResult;
                operationDescription.OperationTime = efOperationDescription.OperationTime;

                result.Add(operationDescription);
            }

            result.Reverse();

            return result;
        }

        #region Приватные методы



        #endregion

        #endregion

    }
}
