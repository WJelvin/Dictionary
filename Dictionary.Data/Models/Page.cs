using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Data.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public IEnumerable<Translation> Translations { get; set; }
    }
}
