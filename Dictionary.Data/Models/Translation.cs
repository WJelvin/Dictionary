using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Data.Models
{
    public class Translation
    {
        public int Id { get; set; }
        public string SwedishTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string SwedishPreamble { get; set; }
        public string EnglishPreamble { get; set; }
        public string SwedishText { get; set; }
        public string EnglishText { get; set; }
        public IEnumerable<string> Keywords { get; set; }
    }
}
