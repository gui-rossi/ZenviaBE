using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<UserEntity>> SelectAllUsers()
        {
            return await _db.User
                .Include(a => a.addresses)
                .Include(t => t.telephoneNumbers)
                .AsNoTracking()
                .ToArrayAsync();
        }

        public void UpdateUser(UserEntity userE)
        {
            _dbSet.Update(userE);
        }

        public async Task<UserEntity> SelectUser(Guid id)
        {
            return await _dbSet
                .FindAsync(id);
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
