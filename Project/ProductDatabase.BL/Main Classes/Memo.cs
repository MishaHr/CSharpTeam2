using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Main_Classes
{
    public class Memo:ISaveable,IGetable 
    {
        public int ProductId { get; private set; }
        public string MemoText { get; set; }

        public Memo(int productId)
        {
            ProductId = productId;
        }

        public override string ToString()
        {
            return string.Format($"{ProductId};{MemoText}");
        }
    }
}
