using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Entities
{
    public class ShortDescription: ISaveable,IGetable
    {
        /// <summary>
        /// Клас який містить коротку інформацію про кожен товар
        /// </summary>
        public int ProductId { get; private set; }
        public string DescriptionText { get; set; }

        public ShortDescription(int productId)
        {
            ProductId = productId;
        }

        public override string ToString()
        {
            return string.Format($"{ProductId};{DescriptionText}");
        }
    }
}
