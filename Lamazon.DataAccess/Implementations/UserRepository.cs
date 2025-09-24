using Lamazon.DataAccess.DataContext;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.Implementations
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public User GetByEmail(string email)
        {
            return _applicationDbContext.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public User GetById(int id)
        {
            return _applicationDbContext.Users
                   .Include(x => x.Role)
                   .FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User user)
        {
            _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
            return user.Id;
        }
    }
}
