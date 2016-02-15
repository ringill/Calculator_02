using Calculator.Domain.AbstractRepositories;
using Calculator.Domain.ValueObjects;
using Calculator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calculator.DataAccess.Xml
{
    public class XmlRepository : IRepository
    {
        #region Свойства

        /// <summary>
        /// путь к xml файлу
        /// </summary>
        private string _fileName;
        /// <summary>
        /// сам xml документ
        /// </summary>
        private XDocument _document;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализируем хранилище
        /// </summary>
        public XmlRepository()
        {
            //Получаем путь к xml файлу
            _fileName = Settings.Settings.XmlFilePath;

            //Если xml файла нет, то выбрасываем исключение
            var file = new FileInfo(_fileName);
            if (file.Exists)
            {
                //подключаемся к хранилищу
                _document = XDocument.Load(_fileName);
            }
            else
            {
                //Пытаемся создать xml файл
                try
                {
                    CreateXmlStorage();
                }
                catch (Exception exception)
                {
                    throw new Exception("Ошибка обращения к хранилищу данных (не найден xml файл)");
                }
            }

        }

        #endregion

        #region Методы

        /// <summary>
        /// Сохранение "описания операции" в хранилище
        /// </summary>
        /// <param name="operationDescription">"описание операции"</param>
        public void Save(OperationDescription operationDescription)
        {
            this.SaveFields(operationDescription);
            this.SaveChanges();
        }

        /// <summary>
        /// Получить 5 последних записей из хранилища
        /// </summary>
        /// <returns>список "описаний операции"</returns>
        public IEnumerable<OperationDescription> Get5OperationDescription()
        {
            //получение последних 5 "описаний операций" из хранилища и приведение их к строгому типу
            //получили все записи из хранилища
            var elements = _document.Root.Elements();
            //перевернули их
            elements = elements.Reverse();
            //взяли первые 5
            elements = elements.Take(5);
            //и привели к строгой типизации
            var operationDescriptions = elements
                .Select(xmlElement => new OperationDescription
                    {
                        Argument1 = Converter.IntFromString(xmlElement.Attribute("Argument1").Value,
                            "Ошибка получения значения из хранилища"),
                        Argument2 = Converter.IntFromString(xmlElement.Attribute("Argument2").Value,
                            "Ошибка получения значения из хранилища"),
                        OperationResult = Converter.DecimalFromString(xmlElement.Attribute("OperationResult").Value,
                            "Ошибка получения значения из хранилища"),
                        OperationType = Converter.OperationTypeFromStringEnglish(xmlElement.Attribute("OperationType").Value,
                            "Ошибка получения значения из хранилища"),
                        OperationTime = Converter.DateTimeFromString(xmlElement.Attribute("OperationTime").Value,
                            "Ошибка получения значения из хранилища"),
                    });
            var z = operationDescriptions.ToList();
            return operationDescriptions;
        }

        #region Приватные методы

        /// <summary>
        /// Подготовка полей для сохранения
        /// </summary>
        /// <param name="operationDescription">"описание операции"</param>
        private void SaveFields(OperationDescription operationDescription)
        {
            XElement element = new XElement("OperationDescription");
            element.Add(new XAttribute("Argument1", operationDescription.Argument1.ToString()));
            element.Add(new XAttribute("Argument2", operationDescription.Argument2.ToString()));
            element.Add(new XAttribute("OperationType", operationDescription.OperationType.ToString()));
            element.Add(new XAttribute("OperationResult", operationDescription.OperationResult.ToString()));
            element.Add(new XAttribute("OperationTime", operationDescription.OperationTime.ToString()));
            _document.Root.Add(element);
        }

        /// <summary>
        /// Сохранение изменений в хранилище
        /// </summary>
        private void SaveChanges()
        {
            _document.Save(_fileName);
        }

        /// <summary>
        /// Создаем XML файл
        /// </summary>
        public void CreateXmlStorage()
        {
            _document = new XDocument();
            XElement element = new XElement("OperationDescriptions");
            _document.Add(element);
            _document.Save(_fileName);
        }


        #endregion

        #endregion
    }
}
