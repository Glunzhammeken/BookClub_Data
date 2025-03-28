using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClub_Data.Interfaces;

namespace BookClub_Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IIdentifiable
    {
        private readonly BookClubDbContext _context;

        public Repository(BookClubDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetList()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetItemById(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            if (item == null)
            {
                throw new ArgumentNullException("item is not in the list");
            }
            return item;
        }

        public async Task<T> Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item is null");
            }
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Remove(int id)
        {
            var item = await GetItemById(id);
            if (item == null)
            {
                throw new ArgumentNullException("item is null");
            }
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Update(int id, T newData)
        {
            var existingItem = await _context.Set<T>().FindAsync(id);
            if (existingItem == null)
            {
                throw new ArgumentNullException("item is null");
            }

            // Use reflection to update properties dynamically
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.CanWrite) // Ensure property is writable
                {
                    var newValue = prop.GetValue(newData);
                    if (newValue != null) // Avoid overwriting with null
                    {
                        prop.SetValue(existingItem, newValue);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return existingItem;
        }

        
    }
}



