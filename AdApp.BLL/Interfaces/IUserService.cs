using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AdApp.BLL.DTO;
using AdApp.BLL.Infrastructure;

namespace AdApp.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDto userDto);
        Task<ClaimsIdentity> Authenticate(UserDto userDto);
        Task<List<ClientProfileDto>> GetClientProfiles();

        Task<ClientProfileDto> GetClientProfileById(string id);

        Task<OperationDetails> Delete(ClientProfileDto clientProfileDto);
        //Task SetInitialData(UserDto userDto, List<string> roles);
    }
}