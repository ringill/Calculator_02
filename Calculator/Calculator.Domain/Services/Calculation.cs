using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Services
{
    /// <summary>
    /// Статический класс, занимающийся вычислениями
    /// </summary>
    static class Calculation
    {
        /// <summary>
        /// Операция сложения
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <returns>результат операции</returns>
        public static decimal Addition(int argument1, int argument2)
        {
            return (decimal)argument1 + (decimal)argument2;
        }

        /// <summary>
        /// Операция вычитания
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <returns>результат операции</returns>
        public static decimal Subtraction(int argument1, int argument2)
        {
            return (decimal)argument1 - (decimal)argument2;
        }

        /// <summary>
        /// Операция умножения
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <returns>результат операции</returns>
        public static decimal Multiplication(int argument1, int argument2)
        {
            return (decimal)argument1 * (decimal)argument2;
        }

        /// <summary>
        /// Операция деления
        /// </summary>
        /// <param name="argument1">аргумент 1</param>
        /// <param name="argument2">аргумент 2</param>
        /// <returns>результат операции</returns>
        public static decimal Division(int argument1, int argument2)
        {
            //деление на ноль недопустимо
            if (argument2 == 0) throw new System.ArgumentException("Второй аргумент равен нулю");

            return (decimal)argument1 / (decimal)argument2;
        }
    }
}
