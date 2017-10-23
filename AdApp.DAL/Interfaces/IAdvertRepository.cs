using System.Collections.Generic;
using AdApp.DAL.Entities;

namespace AdApp.DAL.Interfaces
{
    public interface IAdvertRepository
    {
        void Add(Advert advert);

        void Update(Advert advert);

        List<Advert> GetByUserId(string userId);
        List<Advert> GetAll();
        Advert GetById(int advertId);
    }
}