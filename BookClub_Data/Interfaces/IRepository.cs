using System.Collections.Generic;

namespace BookClub_Data.Interfaces
{
    public interface IRepository<T> where T : class, IIdentifiable
    {
        List<T> GetList();
        T GetItemById(int id);
        T Add(T item);
        T Remove(int id);
        T Update(int id, T newData);
    }
}




