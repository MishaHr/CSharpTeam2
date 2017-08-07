using ProductDatabase.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Reposirories
{
    internal class MemoRepository
    {
        private string _option = "Memo";
        public List<Memo> _memoList;

        public MemoRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();
           
            //створюємо і повертаємо об’єкт
            _memoList = new List<Memo>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _memoList.Add(ObjectCreator.CreateMemo(retrivedData[index]));
            }

        }


        public IEnumerable<BaseEntity> GetAll()
        {
            List<Memo> memoList = _memoList;
            return memoList;
        }

        public BaseEntity Get(int id)
        {
            Memo memo = _memoList.FirstOrDefault(m => m.id == 1);
            return memo;
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
