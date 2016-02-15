using Calculator.Presentation.AbstractPresenters;
using Calculator.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.UI.MvcApp.Controllers
{
    public class CalculationController : Controller
    {
        #region Свойства

        private IPresenter presenter;

        #endregion
        public CalculationController(IPresenter presenter)
        {
            this.presenter = presenter;
        }

        /// <summary>
        /// Отображает основную форму для вычислений
        /// </summary>
        /// <returns></returns>
        public ActionResult CalculationForm()
        {
            var model = new CalculationViewModel();
            return View(model);
        }

        /// <summary>
        /// Вычисляет и отображает результат
        /// в другом потоке пишет результат в лог
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CalculationForm(CalculationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Передаем ViewModel в презентер и получаем измененную ViewModel
                    model.OperationResult = presenter.Calculation(model); 
                }
                catch (Exception e)
                {
                    //выводим сообщение об ошибке
                    return RedirectToAction("ShowError","Error", e.Message);
                }
            }
            
            return View(model);
        }

    }
}
