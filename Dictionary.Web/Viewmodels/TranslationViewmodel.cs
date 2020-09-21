using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Dictionary.Web.Viewmodels
{
    public class TranslationViewmodel
    {
        public int Id { get; set; }
        [Display(Name = "TranslationKey")]
        public string TranslationKey { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "Svensk text")]
        public string SV_Text { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "Engelsk text")]
        public string EN_Text { get; set; }
        [Display(Name = "Current view")]
        public string CurrentView { get; set; }
        public string SelectedView { get; set; }
    }
}