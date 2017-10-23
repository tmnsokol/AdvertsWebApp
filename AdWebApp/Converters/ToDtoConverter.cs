using AdApp.BLL.DTO;
using AdWebApp.Models;
using AutoMapper;

namespace AdWebApp.Converters
{
    public static class ToDtoConverter
    {
        public static ClientProfileDto ToDto(this ClientProfileModel clientProfile)
        {
            return Mapper.Map<ClientProfileModel, ClientProfileDto>(clientProfile);
        }
    }
}