using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Dictionary.Web.Viewmodels
{
    public class TranslationListViewModel
    {
        public IEnumerable<TranslationViewmodel> Translations { get; set; }
        public IEnumerable<SelectListItem> Views { get; set; }
        public string SelectedView { get; set; }
    }
}