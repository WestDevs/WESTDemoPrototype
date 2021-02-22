using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(UsersContext context) : base(context) { }

        public override async Task<List<Users>> GetAll()
        {
            return await Db.Users.AsNoTracking()
                .OrderBy(b => b.FirstName)
                .ToListAsync();
        }

        public override async Task<Users> GetById(int id)
        {
            return await Db.Users.AsNoTracking()
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Users>> SearchUsers(string searchedValue)
        {
            return await Db.Users.AsNoTracking()
                .Where(b => b.FirstName.Contains(searchedValue) ||
                            b.LastName.Contains(searchedValue))
                .ToListAsync();
        }
    }
}
