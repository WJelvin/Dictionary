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
        [Required]
        [Display(Name = "Svensk titel")]
        public string SwedishTitle { get; set; }
        [Required]
        [Display(Name = "Engelsk titel")]
        public string EnglishTitle { get; set; }
        [DisplayFormat(NullDisplayText = "Inte angiven")]
        [Display(Name = "Svensk ingress")]
        public string SwedishPreamble { get; set; }
        [DisplayFormat(NullDisplayText = "Inte angiven")]
        [Display(Name = "Engelsk ingress")]
        public string EnglishPreamble { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Svensk huvudtext")]
        public string SwedishText { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Engelsk huvudtext")]
        public string EnglishText { get; set; }
    }
}
