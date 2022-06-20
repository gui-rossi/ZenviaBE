using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBusiness.Interfaces;
using UserBusiness.Validations;
using UserDomain.Entities;
using UserDomain.UserProperties;
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
            if (!ValidaCPF.IsCpf(userVM.informacoes.cpf)) throw new Exception("Cpf invalido");
            if (!ValidaRG.isRg(userVM.informacoes.rg)) throw new Exception("RG invalido");

            //validar outros campos

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
                    Address = x.endereco,
                    City = x.cidade,
                    Number = x.numero,
                    Complemento = x.comp,
                }).ToArray();

            UserEntity user = new()
            {
                Id = new Guid(userVM.informacoes.id),
                Name = userVM.informacoes.nome,
                LastName = userVM.informacoes.sobrenome,
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
                informacoes = new Informacoes()
                {
                    id = x.Id.ToString(),
                    nome = x.Name,
                    sobrenome = x.LastName,
                    cpf = x.CPF,
                    rg = x.RG,
                    nascimento = x.Birthdate?.ToString(),
                    facebook = x.Facebook,
                    instagram = x.Instagram,
                    twitter = x.Twitter,
                    linkedIn = x.LinkedIn
                },
                telefones = x.telephoneNumbers.Select(tel => new Telefone()
                {
                    nome = tel.Alias,
                    numero = tel.Number
                }).ToList(),
                enderecos = x.addresses.Select(address => new Endereco()
                {
                    nome = address.Alias,
                    endereco = address.Address,
                    numero = address.Number,
                    comp = address.Complemento,
                    cidade = address.City
                }).ToList()
            }).ToArray();

            return usersVM;
        }

        public async Task ModifyUser(UserViewModel userVM)
        {
            UserEntity userE = await _repository.SelectUser(new Guid(userVM.informacoes.id));

            if (userE == null) throw new NullReferenceException("User does not exist");

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
                    Address = x.endereco,
                    City = x.cidade,
                    Number = x.numero,
                    Complemento = x.comp,
                }).ToArray();

            userE.Name = userVM.informacoes.nome;
            userE.LastName = userVM.informacoes.sobrenome;
            userE.RG = userVM.informacoes.rg;
            userE.CPF = userVM.informacoes.cpf;
            userE.Birthdate = string.IsNullOrEmpty(userVM.informacoes.nascimento) ? null : DateTime.Parse(userVM.informacoes.nascimento);
            userE.Facebook = userVM.informacoes.facebook;
            userE.Instagram = userVM.informacoes.instagram;
            userE.Twitter = userVM.informacoes.twitter;
            userE.LinkedIn = userVM.informacoes.linkedIn;
            userE.telephoneNumbers = tels;
            userE.addresses = ends;

            _repository.UpdateUser(userE);

            await _repository.SaveChangesAsync();
        }
    }
}
