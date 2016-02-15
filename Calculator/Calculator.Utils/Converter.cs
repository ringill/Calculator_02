using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utils
{
    /// <summary>
    /// Статический класс для конвертации строк в строгую типизацию
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Получаем int из string
        /// </summary>
        /// <param name="argument">строковое представление числа</param>
        /// <param name="message">сообщение в случае неудачной конвертации</param>
        /// <returns>строготипизированное представление числа</returns>
        public static int IntFromString(string argument, string message)
        {
            int number;
            
            //попытка получить число из строки
            bool result = int.TryParse(argument, out number);
            //если неудачно, то выкидываем исключение
            if (!result) throw new Exception(message);

            return number;
        }

        /// <summary>
        /// Получаем decimal из string
        /// </summary>
        /// <param name="argument">строковое представление числа</param>
        /// <param name="message">сообщение в случае неудачной конвертации</param>
        /// <returns>строготипизированное представление числа</returns>
        public static decimal DecimalFromString(string argument, string message)
        {
            decimal number;

            //попытка получить число из строки
            bool result = decimal.TryParse(argument, out number);
            //если неудачно, то выкидываем исключение
            if (!result) throw new Exception(message);

            return number;
        }

        /// <summary>
        /// Получаем строготипизированный типо операции из string
        /// </summary>
        /// <param name="argument">строковое представление типа операции</param>
        /// <param name="message">сообщение в случае неудачной конвертации</param>
        /// <returns>строготипизированное представление типа операции</returns>
        public static OperationTypes OperationTypeFromString(string argument, string message)
        {
            OperationTypes operationType;
            //отвязываемся от зависимости регистра
            argument = argument.ToLower();

            switch (argument)
            {
                //Сложение
                case "сложение":
                    operationType = OperationTypes.Addition;
                    break;
                //Вычитание
                case "вычитание":
                    operationType = OperationTypes.Subtraction;
                    break;
                //Умножение
                case "умножение":
                    operationType = OperationTypes.Multiplication;
                    break;
                //Деление
                case "деление":
                    operationType = OperationTypes.Division;
                    break;
                default:
                    throw new Exception(message);
            }

            return operationType;
        }

        /// <summary>
        /// Получаем строготипизированный "тип операции" из имени типа операции
        /// (на английском)
        /// </summary>
        /// <param name="argument">строковое представление типа операции</param>
        /// <param name="message">сообщение в случае неудачной конвертации</param>
        /// <returns>строготипизированное представление типа операции</returns>
        public static OperationTypes OperationTypeFromStringEnglish(string argument, string message)
        {
            OperationTypes operationType;
            //отвязываемся от зависимости регистра
            argument = argument.ToLower();

            switch (argument)
            {
                //Сложение
                case "addition":
                    operationType = OperationTypes.Addition;
                    break;
                //Вычитание
                case "subtraction":
                    operationType = OperationTypes.Subtraction;
                    break;
                //Умножение
                case "multiplication":
                    operationType = OperationTypes.Multiplication;
                    break;
                //Деление
                case "division":
                    operationType = OperationTypes.Division;
                    break;
                default:
                    throw new Exception(message);
            }

            return operationType;
        }

        /// <summary>
        /// Преобразуем строковое представление типа операции 
        /// в символьное представление типа операции
        /// </summary>
        /// <param name="argument">строковое представление типа операции</param>
        /// <param name="message">сообщение в случае неудачной конвертации</param>
        /// <returns>символьное представление типа операции</returns>
        public static string SymbolFromOperationTypeStringEnglish(string argument, string message)
        {
            string operationSymbol;

            //отвязываемся от зависимости регистра
            var operationTypeName = argument.ToLower();

            switch (operationTypeName)
            {
                //Сложение
                case "addition":
                    operationSymbol = "+";
                    break;
                //Вычитание
                case "subtraction":
                    operationSymbol = "-";
                    break;
                //Умножение
                case "multiplication":
                    operationSymbol = "*";
                    break;
                //Деление
                case "division":
                    operationSymbol = "/";
                    break;
                default:
                    throw new Exception(message);
            }

            return operationSymbol;
        }

        /// <summary>
        /// Получаем DateTime из string
        /// </summary>
        /// <param name="argument">строковое представление даты-времени</param>
        /// <param name="message">сообщение в случае неудачной конвертации</param>
        /// <returns>строготипизированное представление даты-времени</returns>
        public static DateTime DateTimeFromString(string argument, string message)
        {
            DateTime dateTime;

            //попытка получить дату-время из строки
            bool result = DateTime.TryParse(argument, out dateTime);
            //если неудачно, то выкидываем исключение
            if (!result) throw new Exception(message);

            return dateTime;
        }
    }
}
