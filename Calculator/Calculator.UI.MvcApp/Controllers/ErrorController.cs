using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.UI.MvcApp.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ViewResult ShowError(string error)
        {
            return View(error);
        }

    }
}
