using System.Collections.Generic;
using System.Threading.Tasks;
using AdApp.BLL.DTO;

namespace AdApp.BLL.Interfaces
{
    public interface IAdvertService
    {
        Task AddAdvert(AdvertDto advertDto);

        Task UpdateAdvert(AdvertDto advertDto);

        Task<List<AdvertDto>> GetAdvertsByUserId(string userId);

        Task<List<AdvertDto>> GetAllAdverts();

        Task<AdvertDto> GetAdvertById(int advertId);

        Task DeleteAdvert(int advertId);
    }
}