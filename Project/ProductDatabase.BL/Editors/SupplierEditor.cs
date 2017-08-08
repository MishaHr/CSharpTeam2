using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public class SupplierEditor:BaseEditor
    {

            public override void Add(string [] add)
            {
                int newId = GetLastId() + 1;
                Supplier added = new Supplier(newId);
                added.IsNew = true;
                added.SupplierName = add[0];
                added.SupplierPhoneNumber = add[1];
                SaveLastId(newId);
                SaveChanges(added);


            }

            public override void Edit(string [] edit)
            {
                Supplier edited = ObjectCreator.CreateSupplier(edit);
                edited.IsChanged = true;
                SaveChanges(edited);

            }

            public override void Delete(int id)
            {
                Supplier delete = new Supplier(id);
                delete.IsDeleted = true;
                SaveChanges(delete);
            }

            internal override void SaveChanges(BaseEntity toSave)
            {
                Repository<Supplier> repository = new Repository<Supplier>();
                repository.Save(toSave);
            }

            protected internal override int GetLastId()
            {
                Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
                var lastId = (LastIdKeeper) lastIdKeeperRepository.Get(1);
                return lastId.LastSupplierId;
            }

            protected internal override void SaveLastId(int id)
            {
                Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
                var lastId = (LastIdKeeper) lastIdKeeperRepository.Get(1);
                lastId.LastSupplierId = id;
                lastId.IsChanged = true;
                LastIdKeeperEditor.Edit(lastId);
            }

    }
}
