using Calculator.Presentation.ViewModels;
using Calculator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.UI.WinApp
{
    /// <summary>
    /// Служебный класс, помогающий работать с интерфейсом пользователя
    /// </summary>
    class ViewUI
    {
        #region Свойства

        private ComboBox operationTypeComboBox;
        private TextBox argument1TextBox;
        private TextBox argument2TextBox;
        private TextBox operationResultTextBox;
        private ListBox operationDescriptionListBox;

        #endregion

        #region Конструкторы

        public ViewUI(ComboBox operationTypeComboBox,
            TextBox argument1TextBox,
            TextBox argument2TextBox,
            TextBox operationResultTextBox,
            ListBox operationDescriptionListBox)
        {
            //Привязываемся к элементам формы
            this.argument1TextBox = argument1TextBox;
            this.argument2TextBox = argument2TextBox;
            this.operationTypeComboBox = operationTypeComboBox;
            this.operationResultTextBox = operationResultTextBox;
            this.operationDescriptionListBox = operationDescriptionListBox;

            //Подготавливаем внешний вид
            InitOperationTypeComboBox();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Отображает результатом вычисления на пользовательском интерфейсе
        /// </summary>
        /// <param name="text"></param>
        public void SetOperationResult(string text)
        {
            this.operationResultTextBox.Text = text;
        }

        /// <summary>
        /// Обновляет список "описаний оперции" в ListBox
        /// </summary>
        /// <param name="records"></param>
        public void ShowDataOperationDescriptionListBox(
            IEnumerable<OperationDescriptionViewModel> operationDescriptionViewModels)
        {
            this.operationDescriptionListBox.Items.Clear();

            this.operationDescriptionListBox.BeginUpdate();
            foreach (var operationDescriptionViewModel in operationDescriptionViewModels)
            {
                this.operationDescriptionListBox.Items.Add(
                    //время операции
                    operationDescriptionViewModel.OperationTime + 
                    //разделитель
                    " | " +
                    //аргумент 1
                    operationDescriptionViewModel.Argument1 +
                    //тип операции в виде символа (так от презентера пришло)
                    operationDescriptionViewModel.OperationType +
                    //аргумент 2
                    operationDescriptionViewModel.Argument2 +
                    " = " +
                    //результат операции
                    operationDescriptionViewModel.OperationResult
                    );
            }
            this.operationDescriptionListBox.EndUpdate();
        }

        public void LockControl(Control control)
        {
            control.Enabled = false;
        }

        public void UnlockControl(Control control)
        {
            control.Enabled = true;
        }

        public string GetArgument1()
        {
            return this.argument1TextBox.Text;
        }

        public string GetArgument2()
        {
            return this.argument2TextBox.Text;
        }

        public string GetOperationType()
        {
            return this.operationTypeComboBox.SelectedItem.ToString();
        }

        #region Приватные методы

        /// <summary>
        /// Подготавливает внешний вид элемента выбора типа операции
        /// </summary>
        private void InitOperationTypeComboBox()
        {
            this.operationTypeComboBox.BeginUpdate();

            //Сложение
            this.operationTypeComboBox.Items.Add("Сложение");
            //Вычитание
            this.operationTypeComboBox.Items.Add("Вычитание");
            //Умножение
            this.operationTypeComboBox.Items.Add("Умножение");
            //Деление
            this.operationTypeComboBox.Items.Add("Деление");

            this.operationTypeComboBox.EndUpdate();
            this.operationTypeComboBox.SelectedIndex = 0;
            this.operationTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        #endregion

        #endregion

    }
}
