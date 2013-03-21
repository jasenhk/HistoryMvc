using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HistoryMvc.Models;

namespace HistoryMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new PageViewModel
            {
                IsAjax = false,
                ActionName = "Home/Index"
            };

            if (Request.IsAjaxRequest())
            {
                model.IsAjax = true;
                return PartialView("_Index", model);
            }

            return View(model);

        }
    }
}
