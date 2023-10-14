using Azure.Core;
using Microsoft.EntityFrameworkCore;
using TicketsForFree.Data;
using TicketsForFree.Models;


namespace TicketsForFree.Services
{
    public class UserService : IUserService

    {

        private readonly TicketsDbContext _db;
        public UserService(TicketsDbContext db)
        {

            _db = db;
        }
        public async Task<User> CreateUser(User user)
        {
           
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
           
        }

        public async Task <bool> DeleteUser(int id)
        {
            
                var user = await _db.Users.FindAsync(id);

                if (user == null)
                    return false;

                _db.Users.Remove(user);
                await _db.SaveChangesAsync();  

                return true;
            }

            public async Task<User?> Get(int id)
        {

            var us = await _db.Users.FindAsync(id);
            if (us!=null)
            {
                return us;

            }
            return null;
           
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _db.Users.ToListAsync();
            return users;
        }

        public async  Task<User?> UpdateUser(int id, User updatedUser)
        {
            var user = await _db.Users.FindAsync(id);
            if (user is null)
                return null;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.PasswordHash = updatedUser.PasswordHash;

            await _db.SaveChangesAsync();

            return user;
        }
    }
}
