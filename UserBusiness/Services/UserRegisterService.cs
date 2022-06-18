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

            ICollection<TelephoneNumberEntity> tels = userVM.telefones
                .Select(x => new TelephoneNumberEntity()
                {
                    Alias = x.nome,
                    Number = x.numero
                }).ToArray();

            ICollection<AddressEntity> ends = userVM.enderecos
                .Select(x => new AddressEntity()
                {
                    Alias = x.nome,
                    Address = $"{x.endereco}, {x.cidade}",
                    Number = x.numero,
                    Complemento = x.comp,
                }).ToArray();

            UserEntity user = new()
            {
                Id = new Guid(userVM.informacoes.id),
                Name = $"{userVM.informacoes.nome} {userVM.informacoes.sobrenome}",
                RG = userVM.informacoes.rg,
                CPF = userVM.informacoes.cpf,
                Birthdate = DateTime.Parse(userVM.informacoes.nascimento),
                Facebook = userVM.informacoes.facebook,
                Instagram = userVM.informacoes.instagram,
                Twitter = userVM.informacoes.twitter,
                LinkedIn = userVM.informacoes.linkedIn,

                telephoneNumbers = tels,
                addresses = ends
            };


            await _repository.InsertNewUser(user);

            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<UserViewModel>> FetchAllUsers()
        {
            ICollection<UserEntity> users = await _repository.SelectAllUsers();

            ICollection<UserViewModel> usersVM = users.Select(x => new UserViewModel()
            {

            }).ToArray();

            return usersVM;
        }

        public async Task ModifyUser(UserViewModel userVM)
        {
            await _repository.SelectUser(id);



            await _repository.SaveChangesAsync();
        }
    }
}
