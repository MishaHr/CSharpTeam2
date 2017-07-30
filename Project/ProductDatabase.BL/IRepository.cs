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

        /// <summary>
        /// Метод добування об’экту з бази даних
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IRetrivable Retrive(int Id);
    }
}
