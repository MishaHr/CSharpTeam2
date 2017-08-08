using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public class WarehouseRecordEditor:BaseEditor
    {
        public override void Add(string[] add)
        {
            int newId = GetLastId() + 1;
            WarehouseRecord added = new WarehouseRecord(newId);
            added.WarehouseNumber = Convert.ToInt32(add[0]);
            added.Ammount = Convert.ToInt32(add[1]);
            added.Price = Convert.ToDouble(add[2]);
            added.DeliveryDate = DateTime.Parse(add[3]);
            added.SupplierId = Convert.ToInt32(add[4]);
            added.IsNew = true;
            SaveChanges(added);
        }

        public override void Edit(string[] edit)
        {
            WarehouseRecord edited = ObjectCreator.CreateWarehouseRecord(edit);
            edited.IsChanged = true;
            SaveChanges(edited);
        }

        public override void Delete(int id)
        {
            WarehouseRecord delete = new WarehouseRecord(id);
            delete.IsDeleted = true;
            SaveChanges(delete);
        }

        internal override void SaveChanges(BaseEntity toSave)
        {
            Repository<WarehouseRecord> repository = new Repository<WarehouseRecord>();
            repository.Save(toSave);
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
