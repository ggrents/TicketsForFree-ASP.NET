using TicketsForFree.Models;

namespace TicketsForFree.Services
{
    public interface IUserServices
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User?> Get(int id);
        public Task<User> CreateUser(User user);
        public Task<User?> UpdateUser(int id, User updatedUser);
        public Task<bool> DeleteUser(int id);
    }
}
