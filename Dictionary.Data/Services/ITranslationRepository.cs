using Dictionary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Data.Services
{
    public interface ITranslationRepository
    {
        IEnumerable<Translation> GetAll();
        Translation Get(int id);
        void Add(Translation translation);
        void Update(Translation translation);
        void Delete(int id);
    }
}
