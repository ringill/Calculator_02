using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Presentation.Presenter.AbstractServices;
using Moq;
using Calculator.Presentation.ViewModels;

namespace Calculator.Tests.Presentation.Presenter
{
    [TestClass]
    public class PresenterTest
    {
        Calculator.Presentation.Presenter.Presenter presenter;

        /// <summary>
        /// 
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            //Создаем mock-объект для службы вычислений и описываем его поведение
            var calculationMock = new Mock<ICalculationService>();
            calculationMock.Setup(service => service.Addition(1, 2)).Returns(3m);
            calculationMock.Setup(service => service.Subtraction(1, 2)).Returns(-1m);
            calculationMock.Setup(service => service.Multiplication(1, 2)).Returns(2m);
            calculationMock.Setup(service => service.Division(1, 2)).Returns(0.5m);
            //mock-объект для службы хранилища
            var storageMock = new Mock<IStorageService>();

            //передаем mock-объект, имитирующий поведение службы, экземпляру презентера
            presenter = new Calculator.Presentation.Presenter.Presenter(calculationMock.Object, storageMock.Object);
        }

        #region Correct Model
        /// <summary>
        /// Вызываем метод Calculation
        /// передаем ему модель (экземпляр CalculationViewModel)
        /// с корректными аргументами
        /// выбранный тип операции = "Сложение".
        /// Ожидаем получить корректную модель 
        /// с корректным значением "результат операции"
        /// </summary>
        [TestMethod]
        public void InvokeCalculationMethod_WithCorrectModel_WithOperationType_Addition_ExpectedCorrectModel_WithCorrectOperationResult()
        {
            //arrange

            //модель, передаваемая в качестве аргумента
            var model = new CalculationViewModel
            {
                Argument1 = "1",
                Argument2 = "2",
                SelectedOperationType = "Сложение"
            };

            //act
            string operationResult = presenter.Calculation(model);

            //assert
            Assert.AreEqual("3", operationResult);
        }

        /// <summary>
        /// Вызываем метод Calculation
        /// передаем ему модель (экземпляр CalculationViewModel)
        /// с корректными аргументами
        /// выбранный тип операции = "Вычитание".
        /// Ожидаем получить корректную модель 
        /// с корректным значением "результат операции"
        /// </summary>
        [TestMethod]
        public void InvokeCalculationMethod_WithCorrectModel_WithOperationType_Substraction_ExpectedCorrectModel_WithCorrectOperationResult()
        {
            //arrange

            //модель, передаваемая в качестве аргумента
            var model = new CalculationViewModel
            {
                Argument1 = "1",
                Argument2 = "2",
                SelectedOperationType = "Вычитание"
            };

            //act
            string operationResult = presenter.Calculation(model);

            //assert
            Assert.AreEqual("-1", operationResult);
        }

        /// <summary>
        /// Вызываем метод Calculation
        /// передаем ему модель (экземпляр CalculationViewModel)
        /// с корректными аргументами
        /// выбранный тип операции = "Умножение".
        /// Ожидаем получить корректную модель 
        /// с корректным значением "результат операции"
        /// </summary>
        [TestMethod]
        public void InvokeCalculationMethod_WithCorrectModel_WithOperationType_Multiplication_ExpectedCorrectModel_WithCorrectOperationResult()
        {
            //arrange

            //модель, передаваемая в качестве аргумента
            var model = new CalculationViewModel
            {
                Argument1 = "1",
                Argument2 = "2",
                SelectedOperationType = "Умножение"
            };

            //act
            string operationResult = presenter.Calculation(model);

            //assert
            Assert.AreEqual("2", operationResult);
        }

        /// <summary>
        /// Вызываем метод Calculation
        /// передаем ему модель (экземпляр CalculationViewModel)
        /// с корректными аргументами
        /// выбранный тип операции = "Деление".
        /// Ожидаем получить корректную модель 
        /// с корректным значением "результат операции"
        /// </summary>
        [TestMethod]
        public void InvokeCalculationMethod_WithCorrectModel_WithOperationType_Division_ExpectedCorrectModel_WithCorrectOperationResult()
        {
            //arrange

            //модель, передаваемая в качестве аргумента
            var model = new CalculationViewModel
            {
                Argument1 = "1",
                Argument2 = "2",
                SelectedOperationType = "Деление"
            };

            //act
            string operationResult = presenter.Calculation(model);

            //assert
            Assert.AreEqual("0,5", operationResult);
        }

        #endregion

        #region Incorrect model

        /// <summary>
        /// Вызываем метод Calculation
        /// передаем ему пустую модель (экземпляр CalculationViewModel)
        /// Ожидаем получить исключение
        /// </summary>
        [TestMethod]
        public void InvokeCalculationMethod_WithViewModel_WithEmptyFields_ExpectedException()
        {
            //arrange

            //модель, передаваемая в качестве аргумента
            var model = new CalculationViewModel
            {

            };

            //act
            try
            {
                //act
                string operationResult = presenter.Calculation(model);
            }
            catch (Exception e)
            {
                //assert
                Assert.AreEqual("Недопустимое значение первого аргумента.", e.Message);
            }
        }

        /// <summary>
        /// Вызываем метод Calculation
        /// передаем ему модель (экземпляр CalculationViewModel)
        /// с неверными параметрами Argument1
        /// Ожидаем получить исключение
        /// </summary>
        [TestMethod]
        public void InvokeCalculationMethod_WithViewModel_WithIncorrectArgument1_ExpectedException()
        {
            //arrange

            //модель, передаваемая в качестве аргумента
            var model = new CalculationViewModel
            {
                Argument1 = "1asd",
            };

            //act
            try
            {
                string operationResult = presenter.Calculation(model);
            }
            catch (Exception e)
            {
                //assert
                Assert.AreEqual("Недопустимое значение первого аргумента.", e.Message);
            }
        }

        /// <summary>
        /// Вызываем метод Calculation
        /// передаем ему модель (экземпляр CalculationViewModel)
        /// с неверными параметрами Argument2
        /// Ожидаем получить исключение
        /// </summary>
        [TestMethod]
        public void InvokeCalculationMethod_WithViewModel_WithIncorrectArgument2_ExpectedException()
        {
            //arrange

            //модель, передаваемая в качестве аргумента
            var model = new CalculationViewModel
            {
                Argument1 = "1",
                Argument2 = "2asd",
            };

            //act
            try
            {
                string operationResult = presenter.Calculation(model);
            }
            catch (Exception e)
            {
                //assert
                Assert.AreEqual("Недопустимое значение второго аргумента.", e.Message);
            }
        }

        /// <summary>
        /// Вызываем метод Calculation
        /// передаем ему модель (экземпляр CalculationViewModel)
        /// с неверными параметрами SelectedOperationType
        /// Ожидаем получить исключение
        /// </summary>
        [TestMethod]
        public void InvokeCalculationMethod_WithViewModel_WithIncorrectOperationType_ExpectedException()
        {
            //arrange

            //модель, передаваемая в качестве аргумента
            var model = new CalculationViewModel
            {
                Argument1 = "1",
                Argument2 = "2",
                SelectedOperationType = "12Умновычитание"
            };

            //act
            try
            {
                string operationResult = presenter.Calculation(model);
            }
            catch (Exception e)
            {
                //assert
                Assert.AreEqual("Не выбран тип операции.", e.Message);
            }
        }

        #endregion

    }
}
