using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public class ManufacturerEditor:BaseEditor
    {
        public override void Add(string[] add)
        {
            int newId = GetLastId() + 1;
            Manufacturer manufacturer = new Manufacturer(newId);
            manufacturer.IsNew = true;
            manufacturer.ManufacturerName = add[0];
            SaveLastId(newId);
            SaveChanges(manufacturer);
        }

        public override void Edit(string [] edit)
        {
            Manufacturer edited= ObjectCreator.CreateManufacturer(edit);
            edited.IsChanged = true;
            SaveChanges(edited);

        }

        public  override void Delete(int id)
        {
            Manufacturer toDelete = new Manufacturer(id);
            toDelete.IsDeleted = true;
            SaveChanges(toDelete);
        }

        internal override void SaveChanges(BaseEntity toSave)
        {
            Repository<Manufacturer> manufacturerRepository = new Repository<Manufacturer>();
            manufacturerRepository.Save(toSave);
        }

        protected internal override int GetLastId()
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            var lastIdKeeper = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            int lastId = lastIdKeeper.LastManufacturerId;
            return lastId;
        }

        protected internal override void SaveLastId(int id)
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            var lastId = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            lastId.LastManufacturerId = id;
            lastId.IsChanged = true;
            LastIdKeeperEditor.Edit(lastId);
        }
    }
}
