using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Тестовий інтерфейс для репозиторіїв. Експериментально.
    /// </summary>
    public interface IRepository
    {
        string Option { get; }

        IRetrivable Retrive(int Id);
    }
}
