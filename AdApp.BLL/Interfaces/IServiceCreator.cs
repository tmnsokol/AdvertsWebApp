using AdApp.BLL.Services;

namespace AdApp.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IBllServices Create(string connection);
    }
}
