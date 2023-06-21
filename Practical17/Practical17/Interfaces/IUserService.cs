using Practical17.Models;

namespace Practical17.Interfaces
{
    public interface IUserService
    {
        Users GetUserById(int id);
        void AddUser(Users users);
        IEnumerable<Users> GetAllUsers();
    }
}
