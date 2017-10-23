using System;

namespace AdApp.BLL.Interfaces
{
    public interface IBllServices : IDisposable
    {
        IUserService UserService { get; }
        IAdvertService AdvertService { get; }
    }
}