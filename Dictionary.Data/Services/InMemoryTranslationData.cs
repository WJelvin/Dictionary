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
                new Translation { Id = 1, SwedishTitle = "Rubrik", EnglishTitle = "Headline", SwedishPreamble = "En ingress", EnglishPreamble = "A preamble", EnglishText = "Main text", SwedishText = "Huvudtext", Keywords = new List<string>() { "text", "english", "swedish"} },
                new Translation { Id = 2, SwedishTitle = "Rubrik 2", EnglishTitle = "Headline 2", SwedishPreamble = "En ingress 2", EnglishPreamble = "A preamble 2", EnglishText = "Main text 2", SwedishText = "Huvudtext 2", Keywords = new List<string>() { "text2", "english", "swedish"} },
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

        public IEnumerable<Translation> GetByKeyword(string keyword)
        {
            return db.FindAll(t => t.Keywords.Contains(keyword.ToLower().Trim()));
        }

        public void Update(Translation translation)
        {
            var existing = Get(translation.Id);
            if (existing != null)
            {
                existing.SwedishTitle = translation.SwedishTitle;
                existing.EnglishTitle = translation.EnglishTitle;
                existing.SwedishPreamble = translation.SwedishPreamble;
                existing.EnglishPreamble = translation.EnglishPreamble;
                existing.SwedishText = translation.SwedishText;
                existing.EnglishText = translation.EnglishText;
                existing.Keywords = translation.Keywords;
            }
        }
    }
}
