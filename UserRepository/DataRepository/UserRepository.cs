using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Entities;
using UserRepository.DBContext;
using UserRepository.Interface;

namespace DataRepository.UserRepository
{
    internal class UserRepository : IUserRepository
    {
        protected readonly UsersDBContext _db;
        protected readonly DbSet<UserEntity> _dbSet;

        public UserRepository(UsersDBContext context) : base()
        {
            if (context is null) throw new ArgumentNullException("Null Database context");

            _db = context;
            _dbSet = _db.Set<UserEntity>(); 
        }

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
