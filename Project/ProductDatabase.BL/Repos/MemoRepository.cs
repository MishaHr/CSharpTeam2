using ProductDatabase.BL.Main_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repos
{
    public class MemoRepository:IRepository
    {
        private string _option = "Memo";
        public List<Memo> _memoList;

        public MemoRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator(_option);
            _memoList = new List<Memo>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _memoList.Add(itemCreator.CreateMemo(retrivedData[index]));
            }

        }


        public IEnumerable<IGetable> GetAll()
        {
            List<Memo> memoList = _memoList;
            return memoList;
        }

        public IGetable Get(int id)
        {
            Memo memo = _memoList.FirstOrDefault(m => m.ProductId == 1);
            return memo;
        }

        public IGetable Add(IGetable newObject)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
