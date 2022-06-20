using Microsoft.EntityFrameworkCore;
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
    internal class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly UsersDBContext _db;
        protected readonly DbSet<T> _dbSet;

        public Repository(UsersDBContext context)
        {
            if (context is null) throw new ArgumentNullException("Null Database context");

            _db = context;
            _dbSet = _db.Set<T>();
        }

        public void UpdateUser(T entity)
        {
            _dbSet.Update(entity);
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
