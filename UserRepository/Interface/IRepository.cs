using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Entities;

namespace UserRepository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task SaveChangesAsync();
        void UpdateUser(T entity);
    }
}
