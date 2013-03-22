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
            var model = new PlanetPageViewModel
            {
                IsAjax = Request.IsAjaxRequest(),
                ActionName = "Planet/Index",
                SearchForm = new PlanetSearch()
            };

            if (Request.IsAjaxRequest())
            {                
                return PartialView("_Index", model);
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var planet = planetRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Details", planet);
            }

            return View(planet);
        }

        public ActionResult List()
        {
            var planets = planetRepository.GetAll();

            var model = new PlanetPageViewModel
            {
                IsAjax = Request.IsAjaxRequest(),
                ActionName = "Planet/List",
                Planets = planets,
                SearchForm = new PlanetSearch()
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_List", model);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Search(PlanetSearch search)
        {
            Planet planet = null;

            if (search.Id.HasValue)
            {
                planet = planetRepository.GetAll().Where(p => p.Id == search.Id.GetValueOrDefault(0)).FirstOrDefault();
            }
            else
            {
                var name = (search.Name ?? "").Trim().ToUpper();
                planet = planetRepository.GetAll().Where(p => p.Name.ToUpper() == name).FirstOrDefault();
            }
            var searchResults = new List<Planet>() { };

            if (planet != null)
            {
                searchResults.Add(planet);
            }

            var model = new PlanetPageViewModel
            {
                IsAjax = Request.IsAjaxRequest(),
                ActionName = "Planet/Search",
                Planets = searchResults,
                SearchForm = search
            };

            var result = new AjaxifiedResult(model: model, fullView: "Search", partialView: "_List");
            // return AjaxifiedResult(model: model, fullView: "Search", partialView: "_List");

            if (Request.IsAjaxRequest())
            {
                return PartialView("_List", model);
            }
            return View(model);
        }

    }

    public class AjaxifiedResult : ActionResult
    {
        public AjaxifiedResult(IAjaxifiedModel model, string fullView, string partialView)
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class AjaxifiedJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context);
        }
    }
}
