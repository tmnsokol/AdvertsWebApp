using System.Collections.Generic;
using System.Linq;
using AdApp.BLL.DTO;
using AdWebApp.Models;
using AutoMapper;

namespace AdWebApp.Converters
{
    public static class ToViewModelConverter
    {
        public static AdvertViewModel ToViewModel(this AdvertDto advertDto)
        {
            return Mapper.Map<AdvertDto, AdvertViewModel>(advertDto);
        }

        public static List<AdvertViewModel> ToViewModel(this IEnumerable<AdvertDto> advertDtos)
        {
            return advertDtos.Select(advertDto => advertDto.ToViewModel()).ToList();
        }

        public static ClientProfileModel ToViewModel(this ClientProfileDto clientProfileDto)
        {
            return Mapper.Map<ClientProfileDto, ClientProfileModel>(clientProfileDto);
        }

        public static List<ClientProfileModel> ToViewModel(this IEnumerable<ClientProfileDto> clientProfileDtos)
        {
            return clientProfileDtos.Select(advertDto => advertDto.ToViewModel()).ToList();
        }
    }
}