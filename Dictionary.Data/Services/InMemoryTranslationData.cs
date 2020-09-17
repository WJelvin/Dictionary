using Dictionary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Data.Services
{
    public class InMemoryTranslationData : ITranslationRepository
    {
        List<Translation> db = new List<Translation>()
            {
                new Translation { Id = 1, TranslationKey = "frontpage-some-text", CurrentView = "Frontpage", EN_Text = "Main text", SV_Text = "Huvudtext" },
                new Translation { Id = 2, TranslationKey = "librispage-search-text", CurrentView = "Librispage", EN_Text = "Main text 2", SV_Text = "Huvudtext 2" },
            };

        public InMemoryTranslationData()
        {

        }

        public void Add(Translation translation)
        {
            db.Add(translation);
        }

        public void Delete(int id)
        {
            var translation = Get(id);
            if (translation != null)
            {
                db.Remove(translation);
            }
        }

        public Translation Get(int id)
        {
            return db.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Translation> GetAll()
        {
            return db.OrderBy(t => t.Id);
        }

        public IEnumerable<Translation> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Translation translation)
        {
            var existing = Get(translation.Id);
            if (existing != null)
            {
                existing.TranslationKey = translation.TranslationKey;
                existing.CurrentView = translation.CurrentView;
                existing.SV_Text = translation.SV_Text;
                existing.EN_Text = translation.EN_Text;
            }
        }
    }
}
