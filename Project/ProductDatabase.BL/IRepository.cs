using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    public interface IRepository
    {
        IEnumerable<IGetable> GetAll();
        IGetable Get(int id);
        IGetable Add(IGetable newObject);
        void SaveChanges();
    }
}
