using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AdApp.BLL.Converters;
using AdApp.BLL.DTO;
using AdApp.BLL.Interfaces;
using AdApp.DAL.Interfaces;

namespace AdApp.BLL.Services
{
   public class AdvertService : IAdvertService
   {
        private readonly IUnitOfWork _database;

        public AdvertService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public async Task AddAdvert(AdvertDto advertDto)
        {
            var appUser = await _database.UserManager.Users.FirstOrDefaultAsync(x=>x.Id == advertDto.UserId);
            var dal = advertDto.ToDalEntity(appUser);
            await _database.AdvertRepository.Create(dal);
        }

       public async Task UpdateAdvert(AdvertDto advertDto)
       {
           var advert = await _database.AdvertRepository.Get(advertDto.Id);
           advert.Title = advertDto.Title;
           advert.Content = advertDto.Content;
           await _database.AdvertRepository.Update(advert);
       }

       public async Task<List<AdvertDto>> GetAdvertsByUserId(string userId)
       {
           var adverts = await _database.AdvertRepository.Find(x => x.ApplicationUser.Id == userId);
           return adverts.ToDtoEntities();
       }

       public async Task<List<AdvertDto>> GetAllAdverts()
       {
           var adverts = await _database.AdvertRepository.GetAll();
           return adverts.ToDtoEntities();
       }

       public async Task<AdvertDto> GetAdvertById(int advertId)
        {
            var advert = await _database.AdvertRepository.Get(advertId);
            return advert?.ToDto();
        }

       public async Task DeleteAdvert(int advertId)
       {
           await _database.AdvertRepository.Delete(advertId);
       }
    }
}