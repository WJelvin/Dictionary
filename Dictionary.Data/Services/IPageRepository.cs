using Dictionary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Data.Services
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAll();
        Page Get(int id);
        void Add(Page page);
        void Update(Page page);
        void Delete(int id);
    }
}
