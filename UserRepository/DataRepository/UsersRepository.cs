using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Entities;
using UserRepository.DBContext;
using UserRepository.Interface;

namespace UserRepository.DataRepository
{
    internal class UsersRepository : Repository<UserEntity>, IUsersRepository
    {
        public UsersRepository(UsersDBContext context) : base(context) { }

        public async Task InsertNewUser(UserEntity userE)
        {
            await _dbSet.AddAsync(userE);
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
