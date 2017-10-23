using AdApp.BLL.Interfaces;
using AdApp.DAL.Interfaces;

namespace AdApp.BLL.Services
{
    public class BllServices : IBllServices
    {
        private readonly IUnitOfWork _database;

        public BllServices(IUnitOfWork uow)
        {
            _database = uow;
            UserService = new UserService(uow);
            AdvertService = new AdvertService(uow);
        }

        public IUserService UserService { get; }

        public IAdvertService AdvertService { get; }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}