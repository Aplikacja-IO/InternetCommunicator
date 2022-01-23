using InternetCommunicator.Api.Services;
using InternetCommunicator.Domain.Models;
using InternetCommunicator.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetCommunicator.Api.Controllers
{
    public class UserServices
    {
        private CommunicatorDbContext _context;

        public UserServices(CommunicatorDbContext context)
        {
            _context = context;
        }
        public async Task<RegisterUser> CreateNewUser(string login, string password)
        {
            UserFactoryService userFactory = new RegisterUserFactoryService(_context);

            RegisterUser user = userFactory.Create(login, password);

            _context.RegisterUsers.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<RegisterUser> GetUserById(int id)
        {
            var user = await _context.RegisterUsers.FindAsync(id);

            if (user == null) return null;
            return user;
        }
    }
}