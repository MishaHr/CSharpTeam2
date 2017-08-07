using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Reposirories
{
    /// <summary>
    /// Клас для добування всіх записів з файлу Коротких приміток
    /// </summary>
    internal class ShortDescriptionRepository
    {
        private string _option = "ShortDescription";
        public List<ShortDescription> _shortDescriptions;


        /// <summary>
        /// Конструктор, в якому завантажуються всі дані з файла і з них формується Ліст об’єктів
        /// </summary>
        public ShortDescriptionRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            
            _shortDescriptions = new List<ShortDescription>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _shortDescriptions.Add(ObjectCreator.CreateDescription(retrivedData[index]));
            }
        }


        public IEnumerable<BaseEntity> GetAll()
        {
            List<ShortDescription> descriptions = _shortDescriptions;
            return descriptions;
        }

        public BaseEntity Get(int id)
        {
            ShortDescription description = _shortDescriptions.FirstOrDefault(d => d.id == id);
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
