using Dictionary.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Data.Services
{
    public class SqlTranslationData : ITranslationRepository
    {
        private readonly DictionaryDbContext db;

        public SqlTranslationData(DictionaryDbContext db)
        {
            this.db = db;
        }
        public void Add(Translation translation)
        {
            db.Translations.Add(translation);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var translation = db.Translations.Find(id);
            db.Translations.Remove(translation);
            db.SaveChanges();
        }

        public Translation Get(int id)
        {
            return db.Translations.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Translation> GetAll()
        {
            return from t in db.Translations
                   orderby t.SV_Text
                   select t;
        }

        public IEnumerable<Translation> Search(string searchString)
        {
            return from t in db.Translations
                   where t.SV_Text.Contains(searchString) ||
                   t.EN_Text.Contains(searchString) ||
                   t.TranslationKey.Contains(searchString) ||
                   t.CurrentView.Contains(searchString)
                   select t;
        }

        public void Update(Translation translation)
        {
            var entry = db.Entry(translation);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
