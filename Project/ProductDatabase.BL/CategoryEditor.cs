using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Reposirories;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL
{
    public static class CategoryEditor
    {

        public static void Add(string newName)
        {
            int newId = GetLastId() + 1;
            Category addedCategory = new Category(newId);
            addedCategory.IsNew = true;
            addedCategory.CategoryName = newName;
            SaveChanges(addedCategory);

        }

        public static void Edit(int id, string newName)
        {
            Category editedCategory = new Category(id);
            editedCategory.CategoryName = newName;
            editedCategory.IsChanged = true;
            SaveChanges(editedCategory);
            
        }

        public static void Delete(int id)
        {
            Category deleteCategory = new Category(id);
            deleteCategory.IsDeleted = true;
            SaveChanges(deleteCategory);
        }

        private static void SaveChanges(Category toSave)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.Save(toSave);
        }

        private static int GetLastId()
        {
            LastIdKeeperRepository lastIdKeeperRepository = new LastIdKeeperRepository();
            var lastId = (List<LastIdKeeper>) lastIdKeeperRepository.GetAll();
            return lastId[0].LastCategoryId;
        }

        private static void SaveLastId(int id)
        {
            LastIdKeeperRepository lastIdKeeperRepository = new LastIdKeeperRepository();
            lastIdKeeperRepository.SaveChanges();
        }
    }
}
