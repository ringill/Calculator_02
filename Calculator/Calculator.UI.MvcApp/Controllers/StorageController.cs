using Calculator.Presentation.AbstractPresenters;
using Calculator.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.UI.MvcApp.Controllers
{
    public class StorageController : Controller
    {
        #region Свойства

        private IPresenter presenter;

        #endregion

        #region Конструкторы

        public StorageController(IPresenter presenter)
        {
            this.presenter = presenter;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Основная страничка истории
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            //если false, то Partial фрагмент не встроится в представление
            //и данные НЕ будут подкачиваться из хранилища и отображаться
            bool model = false;
            //bool model = true;
            try
            {
                return View(model);
            }
            catch (Exception e)
            {
                //выводим сообщение об ошибке
                return RedirectToAction("ShowError", "Error", e.Message);
            }

        }

        /// <summary>
        /// Реакция на кнопку "Обновить"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Get(bool model)
        {
            //если true, то Partial фрагмент встроится в представление
            //и данные БУДУТ подкачиваться из хранилища и отображаться
            model = true;
            return View(model);
        }

        /// <summary>
        /// Partial кусочек, который заполняется данными и встраивается в форму через AJAX
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetPartial()
        {
            IEnumerable<OperationDescriptionViewModel> operationDescriptionViewModels;

            operationDescriptionViewModels = presenter.Get5();

            return PartialView(operationDescriptionViewModels);
        }

        #endregion
    }
}
