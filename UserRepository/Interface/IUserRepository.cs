﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Entities;

namespace UserRepository.Interface
{
    public interface IUserRepository
    {
        Task InsertNewUser(UserEntity userE);
        Task SaveChangesAsync();
    }
}