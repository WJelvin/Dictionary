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
        public string TranslationKey { get; set; }
        public string SV_Text { get; set; }
        public string EN_Text { get; set; }
        public string CurrentView { get; set; }
    }
}
