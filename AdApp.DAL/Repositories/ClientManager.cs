using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AdApp.DAL.EF;
using AdApp.DAL.Entities;
using AdApp.DAL.Interfaces;

namespace AdApp.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        private readonly ApplicationContext _database;

        public ClientManager(ApplicationContext db)
        {
            _database = db;
        }

        public async Task Create(ClientProfile item)
        {
            _database.ClientProfiles.Add(item);
            await _database.SaveChangesAsync();
        }

        public async Task<List<ClientProfile>> GetAll()
        {
            return await _database.ClientProfiles.ToListAsync();
        }

        public async Task<ClientProfile> Get(string id)
        {
            return await _database.ClientProfiles.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}