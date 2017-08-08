using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public class MemoEditor:BaseEditor
    {
        public override void Add(string[] add)
        {
            int newId = GetLastId() + 1;
            Memo added = new Memo(newId);
            added.IsNew = true;
            added.MemoText = add[0];
            SaveChanges(added);
        }

        public override void Edit(string[] edit)
        {
            Memo edited = ObjectCreator.CreateMemo(edit);
            edited.IsChanged = true;
            SaveChanges(edited);
        }

        public override void Delete(int id)
        {
            Memo toDelete = new Memo(id);
            toDelete.IsDeleted = true;
            SaveChanges(toDelete);
        }

        internal override void SaveChanges(BaseEntity toSave)
        {
            Repository<Memo> manufacturerRepository = new Repository<Memo>();
            manufacturerRepository.Save(toSave);
        }

        protected internal override int GetLastId()
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            var lastIdKeeper = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            int lastId = lastIdKeeper.LastProductId;
            return lastId;
        }

        protected internal override void SaveLastId(int id)
        {
            
        }
    }
}
