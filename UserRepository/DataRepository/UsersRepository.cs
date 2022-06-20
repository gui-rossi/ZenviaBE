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

        public async Task<UserEntity> SelectUser(Guid id)
        {
            return await _dbSet
                .Include(a => a.addresses)
                .Include(t => t.telephoneNumbers)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
