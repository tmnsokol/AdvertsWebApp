using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdApp.DAL.EF;
using AdApp.DAL.Entities;
using AdApp.DAL.Interfaces;

namespace AdApp.DAL.Repositories
{
    public class AdvertRepository : IRepository<Advert>
    {
        private readonly ApplicationContext _database;

        public AdvertRepository(ApplicationContext db)
        {
            _database = db;
        }

        public async Task<IEnumerable<Advert>> GetAll()
        {
            return await _database.Adverts.ToListAsync();
        }

        public async Task<Advert> Get(int id)
        {
            return await _database.Adverts.FindAsync(id);
        }

        public async Task<IEnumerable<Advert>> Find(Expression<Func<Advert, bool>> predicate)
        {
            return await _database.Adverts.Where(predicate).ToListAsync();
        }

        public async Task Create(Advert item)
        {
            _database.Adverts.Add(item);
            await _database.SaveChangesAsync();
        }

        public async Task Update(Advert advert)
        {
            _database.Entry(advert).State = EntityState.Modified;
            await _database.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entry = await _database.Adverts.FirstOrDefaultAsync(x => x.Id == id);
            if (entry == null)
            {
                throw new ArgumentException("Entry is null");
            }

            _database.Adverts.Remove(entry);
            await _database.SaveChangesAsync();
        }
    }
}