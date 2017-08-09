using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public class ShortDescriptionEditor:BaseEditor
    {
        public override void Add(string[] add)
        {
            int newId = GetLastId() + 1;
            ShortDescription added = new ShortDescription(newId);
            added.IsNew = true;
            added.DescriptionText = add[0];
            SaveChanges(added);
        }

        public override void Edit(string[] edit)
        {
            ShortDescription edited = ObjectCreator.CreateDescription(edit);
            edited.IsChanged = true;
            SaveChanges(edited);
        }

        public override void Delete(int id)
        {
            ShortDescription toDelete = new ShortDescription(id);
            toDelete.IsDeleted = true;
            SaveChanges(toDelete);
        }

        internal override void SaveChanges(BaseEntity toSave)
        {
            Repository<ShortDescription> manufacturerRepository = new Repository<ShortDescription>();
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
