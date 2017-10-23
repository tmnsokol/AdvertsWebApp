using System.Collections.Generic;
using System.Linq;
using AdApp.BLL.DTO;
using AdApp.DAL.Entities;

namespace AdApp.BLL.Converters
{
    public static class ToDtoConverter
    {
        public static AdvertDto ToDto(this Advert advert)
        {
            return new AdvertDto
            {
                Id = advert.Id,
                Title = advert.Title,
                Content = advert.Content,
                UserId = advert.ApplicationUser.Id
            };
        }

        public static List<AdvertDto> ToDtoEntities(this IEnumerable<Advert> adverts)
        {
            return adverts.Any() ? adverts.Select(advert => advert.ToDto()).ToList() : Enumerable.Empty<AdvertDto>().ToList();
        }

        public static ClientProfileDto ToDto(this ClientProfile clientProfile)
        {
            return new ClientProfileDto
            {
                Id = clientProfile.Id,
                Name = clientProfile.Name,
                Email = clientProfile.ApplicationUser.Email
            };
        }
    }
}