using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdApp.BLL.Converters;
using AdApp.BLL.DTO;
using AdApp.BLL.Infrastructure;
using AdApp.BLL.Interfaces;
using AdApp.DAL.Entities;
using AdApp.DAL.Entities.Identity;
using AdApp.DAL.Interfaces;
using Microsoft.AspNet.Identity;

namespace AdApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _database;

        public UserService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public async Task<OperationDetails> Delete(ClientProfileDto clientProfileDto)
        {
            var user = await _database.UserManager.Users.FirstOrDefaultAsync(x=>x.Id == clientProfileDto.Id);
            if (user == null)
            {
                return new OperationDetails(false, "User not found.", "User");
            }

            await _database.UserManager.DeleteAsync(user);
            await _database.SaveAsync();
            return new OperationDetails(false, "User succesfully removed.", "");
        }

        public async Task<OperationDetails> Create(UserDto userDto)
        {
            var user = await _database.UserManager.FindByEmailAsync(userDto.Email);
            if (user != null)
            {
                return new OperationDetails(false, "User with the email ia already exist.", "Email");
            }

            user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
            var result = await _database.UserManager.CreateAsync(user, userDto.Password);
            if (result.Errors.Any())
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
            }

            foreach (var role in userDto.Roles)
            {
                await _database.UserManager.AddToRoleAsync(user.Id, role);
            }

            var clientProfile = new ClientProfile { Id = user.Id, Name = userDto.Name };
            await _database.ClientManager.Create(clientProfile);
           // await _database.SaveAsync();
            return new OperationDetails(true, "Succesfully registered.", "");
        }

        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            var user = await _database.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
            {
                return await _database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            return null;
        }
        
        public async Task<List<ClientProfileDto>> GetClientProfiles()
        {
            var clientProfiles = await _database.ClientManager.GetAll();
            var clientProfileDtos = new List<ClientProfileDto>();
            foreach (var clientProfile in clientProfiles)
            {
                var profileDto = new ClientProfileDto
                {
                    Id = clientProfile.Id,
                    Email = clientProfile.ApplicationUser.Email,
                    Name = clientProfile.Name
                };

                clientProfileDtos.Add(profileDto);
            }

            return clientProfileDtos;
        }

        public async Task<ClientProfileDto> GetClientProfileById(string id)
        {
            var clientProfile = await _database.ClientManager.Get(id);
            return clientProfile.ToDto();

        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}