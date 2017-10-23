using System;
using System.Threading.Tasks;
using AdApp.DAL.EF;
using AdApp.DAL.Entities;
using AdApp.DAL.Entities.Identity;
using AdApp.DAL.Identify;
using AdApp.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;

        private bool _disposed;

        public UnitOfWork(string connectionString)
        {
            _db = new ApplicationContext(connectionString);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            ClientManager = new ClientManager(_db);
            AdvertRepository = new AdvertRepository(_db);
        }

        public ApplicationUserManager UserManager { get; }

        public IClientManager ClientManager { get; }

        public ApplicationRoleManager RoleManager { get; }

        public IRepository<Advert> AdvertRepository { get; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                UserManager.Dispose();
                RoleManager.Dispose();
            }

            _disposed = true;
        }
    }
}