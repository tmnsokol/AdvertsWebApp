using AdApp.BLL.Interfaces;
using AdApp.DAL.Repositories;

namespace AdApp.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IBllServices Create(string connection)
        {
            return new BllServices(new UnitOfWork(connection));
        }
    }
}