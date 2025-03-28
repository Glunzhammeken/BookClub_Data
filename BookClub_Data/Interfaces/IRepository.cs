using System.Collections.Generic;

namespace BookClub_Data.Interfaces
{
    public interface IRepository<T> where T : class, IIdentifiable
    {
        Task<List<T>> GetList();
        Task<T> GetItemById(int id);
        Task<T> Add(T item);
        Task<T >Remove(int id);
        Task<T> Update(int id, T newData);
    }
}




