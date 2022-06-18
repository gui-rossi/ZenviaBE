using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBusiness.Interfaces;
using UserDomain.Entities;
using UserDomain.ViewModels;
using UserRepository.Interface;

namespace UserBusiness.Services
{
    internal class UserRegisterService : IUserRegisterService
    {
        private readonly IUsersRepository _repository;

        public UserRegisterService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task AddNewUser(UserViewModel userVM)
        {
            //validate user and map to entity

            UserEntity user = new();
            await _repository.InsertNewUser(user);

            await _repository.SaveChangesAsync();
        }
    }
}
