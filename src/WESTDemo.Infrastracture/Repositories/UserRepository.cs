﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WESTDemo.Domain.Interfaces;
using WESTDemo.Domain.Models;
using WESTDemo.Infrastracture.Context;

namespace WESTDemo.Infrastracture.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UsersContext context) : base(context) { }

        public override async Task<List<User>> GetAll()
        {
            return await DbSet.AsNoTracking()
                .OrderBy(b => b.FirstName)
                .ToListAsync();
        }

        public override async Task<User> GetById(int id)
        {
            return await DbSet.AsNoTracking()
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByOrganisation(int organisationId)
        {
            return await DbSet.AsNoTracking()
                .Where(u => u.OrganisationId == organisationId)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByUserType(int userTypeId)
        {
            return await DbSet.AsNoTracking()
                .Where(u => u.TypeId == userTypeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchUsers(string searchedValue)
        {
            return await DbSet.AsNoTracking()
                .Where(b => b.Username.Contains(searchedValue))
                .ToListAsync();
        }
    }
}
