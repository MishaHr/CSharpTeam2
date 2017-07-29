using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Тестовий клас (для експериментів). Пізніше спробую реалізувати репозиторії за допомогу абстрактного класу (або інтерфейсів)
    /// </summary>
    public abstract class AbstractRepository
    {
      public abstract IRetrivable Retrive(int id);

   
    }
}
