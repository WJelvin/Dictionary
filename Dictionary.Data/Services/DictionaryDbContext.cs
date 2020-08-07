using Dictionary.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Data.Services
{
    public class DictionaryDbContext : DbContext
    {
        public DbSet<Translation> Translations { get; set; }
    }
}
