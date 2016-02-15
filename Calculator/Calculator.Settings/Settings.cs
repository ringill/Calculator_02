using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Calculator.Settings
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public static class Settings
    {
        #region Свойства

        private static string _xmlFilePath = string.Empty;

        private static ConnectionStringSettings _sqlConnectionString = null;

        /// <summary>
        /// Путь к xml файлу хранилища
        /// </summary>
        public static string XmlFilePath
        {
            get
            {
                if (_xmlFilePath == string.Empty) throw new Exception("Не найден путь к хранилищу (xml файл)");
                return _xmlFilePath;
            }
            private set
            {
                _xmlFilePath = value;
            }
        }

        /// <summary>
        /// Строка соединения с базой данных хранилища
        /// </summary>
        public static ConnectionStringSettings SqlConnectionStringSettings
        {
            get
            {
                if (_sqlConnectionString == null) throw new Exception("Не найден путь к хранилищу (строка подключения к базе данных)");
                return _sqlConnectionString;
            }
            private set
            {
                _sqlConnectionString = value;
            }
        }

        #endregion

        #region Конструкторы

        static Settings()
        {
            _xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];
            _sqlConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
        }
        //Data Source=(localdb)\Projects;Initial Catalog=Calculator.Infrastructure.SqlDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False
        #endregion
    }
}
