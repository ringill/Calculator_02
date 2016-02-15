using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presentation.Presenter.AbstractServices
{
    public interface ICalculationService
    {
        /// <summary>
        /// Операция сложения
        /// </summary>
        /// <param name="a">аргумент 1</param>
        /// <param name="b">аргумент 2</param>
        /// <returns>результат операции</returns>
        decimal Addition(int a, int b);
        
        /// <summary>
        /// Операция вычитания
        /// </summary>
        /// <param name="a">аргумент 1</param>
        /// <param name="b">аргумент 2</param>
        /// <returns>результат операции</returns>
        decimal Subtraction(int a, int b);
        
        /// <summary>
        /// Операция умножения
        /// </summary>
        /// <param name="a">аргумент 1</param>
        /// <param name="b">аргумент 2</param>
        /// <returns>результат операции</returns>
        decimal Multiplication(int a, int b);
       
        /// <summary>
        /// Операция деления
        /// </summary>
        /// <param name="a">аргумент 1</param>
        /// <param name="b">аргумент 2</param>
        /// <returns>результат операции</returns>
        decimal Division(int a, int b);
    }
}
