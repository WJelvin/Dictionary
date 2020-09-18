using Dictionary.Data.Models;
using Dictionary.Data.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dictionary.Web.Viewmodels;

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
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [ValidateInput(false)] //Ska bytas ut mot AllowHtml i viewmodel när vi har en
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Translation translation)
        {
            if (ModelState.IsValid)
            {
                db.Add(translation);
                return RedirectToAction("Details", new { id = translation.Id });
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
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] //Ska bytas ut mot AllowHtml i viewmodel när vi har en
        public ActionResult Edit(Translation translation)
        {
            if (ModelState.IsValid)
            {
                db.Update(translation);
                TempData["Message"] = "Du har sparat översättningen!";
                return RedirectToAction("Details", new { id = translation.Id });
            }
            return View(translation);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Browse()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult BrowseResults(IEnumerable<Translation> model)
        {
            if(model != null)
            {
                return View("Browse", model);
            } else
            {
                return View("Search");
            }
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] //Ska bytas ut mot AllowHtml i viewmodel när vi har en
        public ActionResult Search(string searchString)
        {
            var model = db.Search(searchString);
            return View("Browse", model);
        }
    }
}