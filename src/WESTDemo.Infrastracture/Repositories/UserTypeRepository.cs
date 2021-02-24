using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;
using WESTDemo.Infrastracture.Context;
using WESTDemo.Infrastracture.Repositories;

namespace WESTDemo.Infrastracture.Repositories
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(UsersContext context) : base(context) {}

    }
}