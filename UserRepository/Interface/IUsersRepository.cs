using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Entities;

namespace UserRepository.Interface
{
    public interface IUsersRepository
    {
        Task InsertNewUser(UserEntity userE);
        Task<ICollection<UserEntity>> SelectAllUsers();
        void UpdateUser(UserEntity userE);
        Task<UserEntity> SelectUser(Guid id);
        Task SaveChangesAsync();
    }
}
