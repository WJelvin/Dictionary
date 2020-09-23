using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dictionary.Data.Models;
using Dictionary.Data.Services;
using Dictionary.Web.Viewmodels;
using Microsoft.Ajax.Utilities;

namespace Dictionary.Web.Controllers
{
    public class TranslationsController : Controller
    {
        private readonly ITranslationRepository db;

        public TranslationsController(ITranslationRepository db)
        {
            this.db = db;
        }

        private TranslationViewmodel MapModelToViewmodel(Translation translationModel)
        {
            var viewmodel = new TranslationViewmodel
            {
                Id = translationModel.Id,
                CurrentView = translationModel.CurrentView,
                TranslationKey = translationModel.TranslationKey,
                SV_Text = translationModel.SV_Text,
                EN_Text = translationModel.EN_Text
            };

            return viewmodel;
        }

        private Translation MapViewmodelToModel(TranslationViewmodel translationViewmodel)
        {
            var viewmodel = new Translation
            {
                Id = translationViewmodel.Id,
                CurrentView = translationViewmodel.CurrentView,
                TranslationKey = translationViewmodel.TranslationKey,
                SV_Text = translationViewmodel.SV_Text,
                EN_Text = translationViewmodel.EN_Text
            };

            return viewmodel;
        }

        [HttpGet]
        public ActionResult Index()
        {
            
            var models = db.GetAll();
            List<TranslationViewmodel> vmmodels = new List<TranslationViewmodel>();
            foreach (var model in models)
            {
                vmmodels.Add(MapModelToViewmodel(model));
            }
            return View(vmmodels);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            var viewmodel = MapModelToViewmodel(model);
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TranslationViewmodel translationViewmodel)
        {
            if (ModelState.IsValid)
            {
                var model = MapViewmodelToModel(translationViewmodel);
                db.Add(model);
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            var viewmodel = MapModelToViewmodel(model);
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TranslationViewmodel translationViewmodel)
        {
            if (ModelState.IsValid)
            {
                var model = MapViewmodelToModel(translationViewmodel);
                db.Update(model);
                TempData["Message"] = "Du har sparat översättningen!";
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(translationViewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }

            var viewmodel = MapModelToViewmodel(model);

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Browse(string views = null)
        {
            var models = db.GetAll();
            var dbViews = from n in models select n.CurrentView;
            dbViews = dbViews.Distinct();
            ViewBag.dbViews = dbViews;
            if (!views.IsNullOrWhiteSpace())
            {
                models =  models.Where(t => t.CurrentView == views);
            }

            var vmmodels = new List<TranslationViewmodel>();
            foreach (var translation in models)
            {
                vmmodels.Add(MapModelToViewmodel(translation));
            }
            var viewmodel = new TranslationListViewModel();
            viewmodel.Translations = vmmodels;


            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult BrowseResults(TranslationListViewModel model)
        {
            if(model != null)
            {
                return View("Browse", model);
            }

            return View("Search");
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {

            var models = db.Search(searchString);
            var dbViews = from n in models select n.CurrentView;
            dbViews = dbViews.Distinct();
            ViewBag.dbViews = dbViews;
            List<TranslationViewmodel> vmmodels = new List<TranslationViewmodel>();
            foreach (var model in models)
            {
                vmmodels.Add(MapModelToViewmodel(model));
            }
            var vm = new TranslationListViewModel();
            vm.Translations = vmmodels;
            return View("Browse", vm);
        }
    }
}