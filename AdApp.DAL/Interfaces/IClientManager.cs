using System.Collections.Generic;
using System.Threading.Tasks;
using AdApp.DAL.Entities;

namespace AdApp.DAL.Interfaces
{
    public interface IClientManager
    {
        Task Create(ClientProfile item);

        Task<List<ClientProfile>> GetAll();

        Task<ClientProfile> Get(string id);
    }
}