using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Calculator.Tests.Domain
{
    /// <summary>
    /// Тестирование службы вычислений
    /// </summary>
    [TestClass]
    public class CalculationServiceTest
    {
        Calculator.Domain.Services.CalculationService calculationService;

        /// <summary>
        /// Создаем экземпляр службы вычислений, необходимый для дальнейших тестов
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            calculationService = new Calculator.Domain.Services.CalculationService();
        }

        #region Addition

        /// <summary>
        /// Операция сложения (аргумент1 = 1, аргумент2 = 2)
        /// </summary>
        [TestMethod]
        public void Addition_Arg1Equal1_Arg2Equal2_Expected_3()
        {
            //arrange

            //act
            var result = calculationService.Addition(1, 2);

            //assert
            Assert.AreEqual(3m, result);
        }

        /// <summary>
        /// Операция сложения (аргумент1 = MaxInt, аргумент2 = 2)
        /// </summary>
        [TestMethod]
        public void Addition_Arg1EqualMaxInt_Arg2Equal2_Expected_2147483649()
        {
            //arrange

            //act
            var result = calculationService.Addition(int.MaxValue, 2);

            //assert
            Assert.AreEqual(2147483649m, result);
        }

        #endregion


        #region Subtraction

        /// <summary>
        /// Операция вычитания (аргумент1 = 1, аргумент2 = 2)
        /// </summary>
        [TestMethod]
        public void Subtraction_Arg1Equal1_Arg2Equal2_Expected_Minus1()
        {
            //arrange

            //act
            var result = calculationService.Subtraction(1, 2);

            //assert
            Assert.AreEqual(-1m, result);
        }

        /// <summary>
        /// Операция вычитания (аргумент1 = MinInt, аргумент2 = 2)
        /// </summary>
        [TestMethod]
        public void Subtraction_Arg1EqualMinInt_Arg2Equal2_Expected_Minus2147483650()
        {
            //arrange

            //act
            var result = calculationService.Subtraction(int.MinValue, 2);

            //assert
            Assert.AreEqual(-2147483650m, result);
        }

        #endregion


        #region Multiplication

        /// <summary>
        /// Операция умножения (аргумент1 = 1, аргумент2 = 2)
        /// </summary>
        [TestMethod]
        public void Multiplication_Arg1Equal1_Arg2Equal2_Expected2()
        {
            //arrange

            //act
            var result = calculationService.Multiplication(1, 2);

            //assert
            Assert.AreEqual(2m, result);
        }

        /// <summary>
        /// Операция умножения (аргумент1 = MaxInt, аргумент2 = MinInt)
        /// </summary>
        [TestMethod]
        public void Multiplication_Arg1EqualMaxInt_Arg1EqualMinInt_Expected_Minus4611686016279904256()
        {
            //arrange

            //act
            var result = calculationService.Multiplication(int.MinValue, int.MaxValue);

            //assert
            Assert.AreEqual(-4611686016279904256m, result);
        }

        
        #endregion



        #region Division

        /// <summary>
        /// Операция деления (аргумент1 = 1, аргумент2 = 2)
        /// </summary>
        [TestMethod]
        public void Division_Arg1Equal1_Arg2Equal2_Expected_0Point5()
        {
            //arrange

            //act
            var result = calculationService.Division(1, 2);

            //assert
            Assert.AreEqual(0.5m, result);
        }

        /// <summary>
        /// Операция деления (аргумент1 = MinInt, аргумент2 = MaxInt)
        /// </summary>
        [TestMethod]
        public void Division_Arg1EqualMinInt_Arg2EqualMaxInt_Expected_Minus1Point0000000004656612875245796924()
        {
            //arrange

            //act
            var result = calculationService.Division(int.MinValue, int.MaxValue);

            //assert
            Assert.AreEqual(-1.0000000004656612875245796924m, result);
        }

        /// <summary>
        /// Операция деления (аргумент2 = 0). Ожидаем исключение.
        /// </summary>
        [TestMethod]
        public void Division_Arg1Equal5_Arg2Equal0_ExceptionExspected()
        {
            //arrange

            //act
            try
            {
                var result = calculationService.Division(5, 0);
                Assert.Fail("Ожидаемое исключение не было выброшено.");
            }
            catch (Exception e)
            {
                //assert
                Assert.AreEqual("Второй аргумент равен нулю", e.Message);
            }
        }

        #endregion
    }
}
