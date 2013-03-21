using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HistoryMvc.Common;
using HistoryMvc.Models;

namespace HistoryMvc.Controllers
{
    public class PlanetController : Controller
    {
        private IPlanetRepository planetRepository;

        public PlanetController(IPlanetRepository planetRepository)
        {
            this.planetRepository = planetRepository;
        }

        //
        // GET: /Planet/
        public ActionResult Index()
        {
            var model = new PageViewModel
            {
                IsAjax = false,
                ActionName = "Planet/Index"
            };

            if (Request.IsAjaxRequest())
            {
                model.IsAjax = true;
                
                return PartialView("_Index", model);
            }

            return View(model);
        }

        public ActionResult Details(int planetId)
        {
            return View();
        }

        public ActionResult List()
        {
            var planets = planetRepository.GetAll();

            var model = new PageViewModel
            {
                IsAjax = false,
                ActionName = "Planet/List",
                Planets = planets
            };

            if (Request.IsAjaxRequest())
            {
                model.IsAjax = true;
                return PartialView("_List", model);
            }

            return View(model);
        }

        public ActionResult Search(PlanetSearch search)
        {
            Planet planet = null;

            if (search.Id.HasValue)
            {
                planet = planetRepository.GetAll().Where(p => p.Id == search.Id.GetValueOrDefault(0)).FirstOrDefault();
            }
            else
            {
                var name = search.Name.Trim().ToUpper();
                planet = planetRepository.GetAll().Where(p => p.Name.ToUpper() == name).FirstOrDefault();
            }

            return View(planet);
        }

    }
}
