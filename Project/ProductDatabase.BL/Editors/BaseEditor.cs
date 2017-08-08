using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public abstract class BaseEditor
    {
        public abstract void Add(string[] add);
        public abstract void Edit(string[] edit);
        public abstract void Delete(int id);
        internal abstract void SaveChanges(BaseEntity toSave);

        protected internal abstract int GetLastId();
        protected internal abstract void SaveLastId(int id);

    }
}
