using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repos
{
    public class ShortDescriptionRepository:IRepository
    {
        private string _option = "ShortDescription";
        public List<ShortDescription> _shortDescriptions;


        public ShortDescriptionRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator(_option);
            _shortDescriptions = new List<ShortDescription>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _shortDescriptions.Add(itemCreator.CreateDescription(retrivedData[index]));
            }
        }

        public IEnumerable<IGetable> GetAll()
        {
            List<ShortDescription> descriptions = _shortDescriptions;
            return descriptions;
        }

        public IGetable Get(int id)
        {
            ShortDescription description = _shortDescriptions.FirstOrDefault(d => d.ProductId == id);
            return description;
        }

        public void Add(IGetable newObject)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
