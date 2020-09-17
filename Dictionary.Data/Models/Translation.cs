using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Data.Models
{
    public class Translation
    {
        public int Id { get; set; }
        [Display(Name = "TranslationKey")]
        public string TranslationKey { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Svensk text")]
        public string SV_Text { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Engelsk text")]
        public string EN_Text { get; set; }
        [Display(Name = "Current view")]
        public string CurrentView { get; set; }
    }
}
