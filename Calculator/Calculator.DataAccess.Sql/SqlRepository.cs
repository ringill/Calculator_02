using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Domain.AbstractRepositories;
using System.Data.SqlClient;
using System.Data;
using Calculator.Domain.ValueObjects;
using Calculator.Utils;

namespace Calculator.DataAccess.Sql
{
    public class SqlRepository : IRepository
    {
        #region Свойства



        #endregion

        #region Конструкторы

        public SqlRepository()
        {
            
        }

        #endregion

        #region Методы

        /// <summary>
        /// Сохраняем "описание операции" в базу данных
        /// </summary>
        /// <param name="operationDescription">"описание операции"</param>
        public void Save(OperationDescription operationDescription)
        {
            using (var _connection = new SqlConnection(Settings.Settings.SqlConnectionStringSettings.ConnectionString))
            {
                _connection.Open();
                using (SqlTransaction transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO OperationDescriptions" +
                        "(Argument1, Argument2, OperationResult, OperationType, OperationTime)" +
                        "VALUES" +
                        "(@Argument1, @Argument2, @OperationResult, @OperationType, @OperationTime) " +
                        "SET @OperationDescriptionId = SCOPE_IDENTITY()",
                        _connection))
                    {
                        command.Transaction = transaction;

                        command.Parameters.Add("@OperationDescriptionId", SqlDbType.Int);
                        command.Parameters["@OperationDescriptionId"].Direction = ParameterDirection.Output;

                        command.Parameters.Add("@Argument1", SqlDbType.Int);
                        command.Parameters["@Argument1"].Value = operationDescription.Argument1;

                        command.Parameters.Add("@Argument2", SqlDbType.Int);
                        command.Parameters["@Argument2"].Value = operationDescription.Argument2;

                        command.Parameters.Add("@OperationResult", SqlDbType.Decimal);
                        command.Parameters["@OperationResult"].Value = operationDescription.OperationResult;

                        command.Parameters.Add("@OperationType", SqlDbType.NVarChar, 15);
                        command.Parameters["@OperationType"].Value = operationDescription.OperationType.ToString();

                        command.Parameters.Add("@OperationTime", SqlDbType.DateTime2);
                        command.Parameters["@OperationTime"].Value = operationDescription.OperationTime;

                        command.ExecuteNonQuery();

                        //var id = command.Parameters["@OperationDescriptionId"].Value;
                    }
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Получение последних "описаний операций"
        /// </summary>
        /// <param name="n">количество последних "описаний операций"</param>
        /// <returns>список последних "описаний операций"</returns>
        public IEnumerable<OperationDescription> Get5OperationDescription()
        {
            //пустой список "описания операций"
            var operationDescriptions = new List<OperationDescription>();

            using (var _connection = new SqlConnection(Settings.Settings.SqlConnectionStringSettings.ConnectionString))
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    using (var command = new SqlCommand("[dbo].[sp_GetLast5OperationDescriptions]", _connection))
                    {
                        command.Transaction = transaction;
                        command.CommandType = CommandType.StoredProcedure;
                        //читаем данные из базы в список
                        operationDescriptions = GetOperationDescriptions(command);
                    }

                    transaction.Commit();
                }
            }

            return operationDescriptions;
        }

        #region Приватные методы

        private List<OperationDescription> GetOperationDescriptions(SqlCommand command)
        {
            //пустой список "описания операций"
            var operationDescriptions = new List<OperationDescription>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    //заполняем список "описания операций"
                    while (reader.Read())
                    {
                        operationDescriptions.Add(new OperationDescription
                        {
                            Argument1 = reader.GetInt32(1),
                            Argument2 = reader.GetInt32(2),
                            //сразу преобразовываем в строготипизированный тип операции
                            OperationType = Converter.OperationTypeFromStringEnglish(reader.GetString(3),
                                "Ошибка получения типа операции из хранилища"),
                            OperationResult = reader.GetDecimal(4),
                            OperationTime = reader.GetDateTime(5)
                        });
                    }
                }
            }

            return operationDescriptions;
        }

        #endregion

        #endregion
    }
}
