using System;
using System.Threading.Tasks;
using AdApp.DAL.Entities;
using AdApp.DAL.Identify;

namespace AdApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }

        IRepository<Advert> AdvertRepository { get; }

        Task SaveAsync();
    }
}