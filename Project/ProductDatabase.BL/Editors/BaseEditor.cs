using ProductDatabase.BL.Entities;

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
