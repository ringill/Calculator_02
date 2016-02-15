using Calculator.Presentation.Presenter.AbstractServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Services
{
    /// <summary>
    /// Сервис вычислений
    /// </summary>
    public class CalculationService : ICalculationService
    {
        /// <summary>
        /// Операция сложения
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <returns>результат операции</returns>
        public decimal Addition(int argument1, int argument2)
        {
            return Calculation.Addition(argument1, argument2);
        }

        /// <summary>
        /// Операция вычитания
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <returns>результат операции</returns>
        public decimal Subtraction(int argument1, int argument2)
        {
            return Calculation.Subtraction(argument1, argument2);
        }

        /// <summary>
        /// Операция умножения
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <returns>результат операции</returns>
        public decimal Multiplication(int argument1, int argument2)
        {
            return Calculation.Multiplication(argument1, argument2);
        }

        /// <summary>
        /// Операция деления
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <returns>результат операции</returns>
        public decimal Division(int argument1, int argument2)
        {
            return Calculation.Division(argument1, argument2);
        }
    }
}
