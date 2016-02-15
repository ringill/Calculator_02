using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presentation.ViewModels
{
    public class CalculationViewModel
    {
        /// <summary>
        /// Типы операций
        /// </summary>
        public string[] OperationTypes { get { return new string[] { "Сложение", "Вычитание", "Умножение", "Деление" }; } }

        /// <summary>
        /// Выбранный тип операции
        /// </summary>
        public string SelectedOperationType { get; set; }

        /// <summary>
        /// Аргумент 1
        /// </summary>
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Недопустимое число")]
        [Required(ErrorMessage = "Поле должно содержать цифры")]
        [Display(Name = "Первый аргумент:")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Агрумент должен быть целым числом")]
        public string Argument1 { get; set; }

        /// <summary>
        /// Аргумент 2
        /// </summary>
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Недопустимое число")]
        [Required(ErrorMessage = "Поле должно содержать цифры (кроме 0)")]
        [Display(Name = "Второй аргумент:")]
        [RegularExpression(@"^[1-9]+$", ErrorMessage = "Агрумент должен быть целым числом (кроме нуля)")]
        public string Argument2 { get; set; }

        /// <summary>
        /// Результат операции
        /// </summary>
        [ReadOnly(true)]
        [Display(Name = "Результат:")]
        public string OperationResult { get; set; }
    }
}
