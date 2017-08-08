using System;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public class ProductEditor:BaseEditor
    {
        public override void Add(string[] newValues)
        {
            int newId = GetLastId() + 1;
            Product added = new Product(newId);
            added.CategoryId = Convert.ToInt32(newValues[0]);
            added.ManufacrirerId = Convert.ToInt32(newValues[1]);
            added.ProductModel = newValues[2];
            added.ProductionDate = DateTime.Parse(newValues[3]);
            added.ExpirationDate = newValues[4];
            added.IsNew = true;
            SaveLastId(newId);
            SaveChanges(added);


        }

        public override void Edit(string[] newValues)
        {
            Product edited = ObjectCreator.CreateProduct(newValues);
            edited.IsChanged = true;
            SaveChanges(edited);

        }

        public override void Delete(int id)
        {
            Product delete = new Product(id);
            delete.IsDeleted = true;
            SaveChanges(delete);
        }

        internal override void SaveChanges(BaseEntity toSave)
        {
            Repository<Product> repository = new Repository<Product>();
            repository.Save(toSave);
        }

        protected internal override int GetLastId()
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            var lastId = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            return lastId.LastCategoryId;
        }

        protected internal override void SaveLastId(int id)
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            var lastId = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            lastId.LastProductId = id;
            lastId.IsChanged = true;
            LastIdKeeperEditor.Edit(lastId);
        }

    }
}

