using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repositories
{
    internal abstract class BaseRepository
    {
        protected internal IEnumerable<BaseEntity> _list;

        internal abstract IEnumerable<BaseEntity> GetAll();
      

        internal abstract BaseEntity Get(int id);

        internal abstract void Save(BaseEntity newData);
      

        protected internal abstract void Add(BaseEntity objectToAdd);
   

        protected internal abstract void Update(BaseEntity objectToUpdate);


        protected internal abstract void Delete(BaseEntity objectToDelete);

        protected internal abstract void SaveTable();


    }
}
