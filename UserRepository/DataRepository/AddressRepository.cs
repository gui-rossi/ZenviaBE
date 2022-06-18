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
    internal class AddressRepository : Repository<AddressEntity>, IAddressRepository
    {
        public AddressRepository(UsersDBContext context) : base(context) { }


    }
}
