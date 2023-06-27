using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll(); 
        Task<User?> GetUserById(int id);
        Task<User?> AddUser(UserDTO userDTO);
        Task<User?> DeleteUser(int id);
        Task<User?> UpdateUser(UserDTO request, int id);
    }
}
