using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Entities;

namespace UserRepository.Interface
{
    public interface IUsersRepository : IRepository<UserEntity>
    {
        Task InsertNewUser(UserEntity userE);
        Task<ICollection<UserEntity>> SelectAllUsers();
        Task<UserEntity> SelectUser(Guid id);
        Task<UserEntity> SelectUserByCpf(string cpf);
        Task<UserEntity> SelectUserByRg(string rg);
    }
}
