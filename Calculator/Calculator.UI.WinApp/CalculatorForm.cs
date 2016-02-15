using Calculator.Presentation.AbstractPresenters;
using Calculator.Presentation.Presenter;
using Calculator.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.UI.WinApp
{
    public partial class CalculatorForm : Form
    {

        #region Свойства

        private IPresenter presenter;

        private ViewUI viewUI;

        #endregion

        #region Конструкторы

        public CalculatorForm(IPresenter presenter)
        {
            InitializeComponent();

            this.presenter = presenter;

            this.viewUI = new ViewUI(
                list_OperationTypes,
                txt_Argument1,
                txt_Argument2,
                txt_OperationResult,
                list_OperationDescriptions);
        }

        #endregion

        #region Методы

        private void btn_Calculation_Click(object sender, EventArgs e)
        {
            //создаем модель и заполняем её аргументами
            var model = new CalculationViewModel
            {
                Argument1 = this.viewUI.GetArgument1(),
                Argument2 = this.viewUI.GetArgument2(),
                SelectedOperationType = this.viewUI.GetOperationType()
            };

            string operationResult = string.Empty;
            try
            {
                //получаем результат операции от презентера
                operationResult = this.presenter.Calculation(model);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            //отображаем результат операции
            this.viewUI.SetOperationResult(operationResult);
        }

        private void btn_OperationDescriptionListBox_Click(object sender, EventArgs e)
        {
            //блокируем кнопку
            var button = sender as Button;
            this.viewUI.LockControl(button);

            //получаем данные из презентера
            var operationDescriptions = this.presenter.Get5();
            //отображаем их в пользовательском интерфейсе
            this.viewUI.ShowDataOperationDescriptionListBox(operationDescriptions);

            //разблокируем кнопку
            this.viewUI.UnlockControl(button);
        }
        
        #region Приватные методы

        #endregion

        #endregion
    }
}
