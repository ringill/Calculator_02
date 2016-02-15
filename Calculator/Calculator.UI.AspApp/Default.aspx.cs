using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calculator.Presentation.AbstractPresenters;
using Ninject;

namespace Calculator.UI.AspApp
{
    public partial class _Default : Page
    {
        #region Свойства

        [Inject]
        public IPresenter Presenter { get; set; }

        #endregion

        #region Методы

        protected void Page_Load(object sender, EventArgs e)
        {
            var z = this.Presenter.Get5();
        }

        #endregion
    }
}