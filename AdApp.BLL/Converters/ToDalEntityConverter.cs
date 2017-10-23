using System.Collections.Generic;
using AdApp.BLL.DTO;
using AdApp.DAL.Entities;
using AdApp.DAL.Entities.Identity;

namespace AdApp.BLL.Converters
{
    public static class ToDalEntityConverter
    {
        public static Advert ToDalEntity(this AdvertDto advertDto, ApplicationUser applicationUser)
        {
            return new Advert
            {
                Id = advertDto.Id,
                Title = advertDto.Title,
                Content = advertDto.Content,
                ApplicationUser = applicationUser
            };
        }

        public static List<Advert> ToDalEntities(this IEnumerable<AdvertDto> advertDtos, ApplicationUser applicationUser)
        {
            var adverts = new List<Advert>();
            foreach (var advertDto in advertDtos)
            {
                var advert = advertDto.ToDalEntity(applicationUser);
                adverts.Add(advert);
            }

            return adverts;
        }
    }
}
