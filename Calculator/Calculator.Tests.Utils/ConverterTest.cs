using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Utils;

namespace Calculator.Tests.Utils
{
    [TestClass]
    public class ConverterTest
    {
        #region IntFromString

        /// <summary>
        /// Вызываем метод преобразования строкового представления числа
        /// в строготипизированное представление Int32.
        /// Передаем подходящую строку, получаем правильное число.
        /// Проверяем, что полученное число - правильное.
        /// </summary>
        [TestMethod]
        public void Convert_StringNumber_Into_IntNumber_ExpectedIntNumber()
        {
            //arrange

            //act
            int result = Converter.IntFromString("123","errorMessage");

            //assert
            Assert.AreEqual(123, result);
        }

        /// <summary>
        /// Вызываем метод преобразования строкового представления числа
        /// в строготипизированное представление Int32.
        /// Передаем некорректную строку, получаем исключение,
        /// проверяем правильность сообщения в исключении.
        /// </summary>
        [TestMethod]
        public void Try_Convert_StringNumber_Into_IntNumber_ExpectedException()
        {
            //arrange

            //act
            try
            {
                int result = Converter.IntFromString("errorNumber", "errorMessage");
            }
            catch (Exception e)
            {
                //assert
                Assert.AreEqual("errorMessage", e.Message);
            }
        }

        #endregion

        #region OperationTypeFromString

        /// <summary>
        /// Вызываем метод преобразования строкового представления типа операции
        /// в строготипизированное представление enum.
        /// Передаем некорректную строку, получаем исключение,
        /// проверяем правильность сообщения в исключении.
        /// </summary>
        [TestMethod]
        public void Try_Convert_StringOperationType_Into_EnumOperationType_ExpectedException()
        {
            //arrange

            //act
            try
            {
                OperationTypes result = Converter.OperationTypeFromString("errorOperation", "errorMessage");
            }
            catch (Exception e)
            {
                //assert
                Assert.AreEqual("errorMessage", e.Message);
            }
        }

        /// <summary>
        /// Вызываем метод преобразования строкового представления типа операции
        /// "Сложение"
        /// в строготипизированное представление enum.
        /// Проверяем, что полученный строготипизированный тип операции - ожидаемый. 
        /// </summary>
        [TestMethod]
        public void Convert_StringOperationType_Addition_Into_EnumOperationType()
        {
            //arrange

            //act
            OperationTypes result = Converter.OperationTypeFromString("СлОжЕнИе", "errorMessage"); 

            //assert
            Assert.AreEqual(OperationTypes.Addition, result);
        }

        /// <summary>
        /// Вызываем метод преобразования строкового представления типа операции
        /// "Вычитание"
        /// в строготипизированное представление enum.
        /// Проверяем, что полученный строготипизированный тип операции - ожидаемый. 
        /// </summary>
        [TestMethod]
        public void Convert_StringOperationType_Subtraction_Into_EnumOperationType()
        {
            //arrange

            //act
            OperationTypes result = Converter.OperationTypeFromString("Вычитание", "errorMessage");

            //assert
            Assert.AreEqual(OperationTypes.Subtraction, result);
        }

        /// <summary>
        /// Вызываем метод преобразования строкового представления типа операции
        /// "Умножение"
        /// в строготипизированное представление enum.
        /// Проверяем, что полученный строготипизированный тип операции - ожидаемый. 
        /// </summary>
        [TestMethod]
        public void Convert_StringOperationType_Multiplication_Into_EnumOperationType()
        {
            //arrange

            //act
            OperationTypes result = Converter.OperationTypeFromString("Умножение", "errorMessage");

            //assert
            Assert.AreEqual(OperationTypes.Multiplication, result);
        }

        /// <summary>
        /// Вызываем метод преобразования строкового представления типа операции
        /// "Деление"
        /// в строготипизированное представление enum.
        /// Проверяем, что полученный строготипизированный тип операции - ожидаемый. 
        /// </summary>
        [TestMethod]
        public void Convert_StringOperationType_Division_Into_EnumOperationType()
        {
            //arrange

            //act
            OperationTypes result = Converter.OperationTypeFromString("Деление", "errorMessage");

            //assert
            Assert.AreEqual(OperationTypes.Division, result);
        }

        #endregion

        #region DateTimeFromString

        /// <summary>
        /// Вызываем метод преобразования строкового представления даты-времени
        /// в строготипизированное представление DateTime.
        /// Передаем подходящую строку, получаем правильное значение даты-времени.
        /// Проверяем, что полученное значение - корректно.
        /// </summary>
        [TestMethod]
        public void Convert_StringDateTime_Into_StrongTypedDateTime_ExpectedDateTime()
        {
            //arrange

            //act
            DateTime result = Converter.DateTimeFromString("22.08.2013 15:42:59", "errorMessage");

            //assert
            Assert.AreEqual(new DateTime(2013,08,22,15,42,59), result);
        }

        /// <summary>
        /// Вызываем метод преобразования строкового представления даты-времени
        /// в строготипизированное представление DateTime.
        /// Передаем некорректную строку, получаем исключение,
        /// проверяем правильность сообщения в исключении.
        /// </summary>
        [TestMethod]
        public void Try_Convert_StringDateTime_Into_StrongTypedDateTime_ExpectedException()
        {
            //arrange

            //act
            try
            {
                int result = Converter.IntFromString("errorDateTime", "errorMessage");
            }
            catch (Exception e)
            {
                //assert
                Assert.AreEqual("errorMessage", e.Message);
            }
        }

        #endregion
    }
}
