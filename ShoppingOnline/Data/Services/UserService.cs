using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ShoppingOnline.Data.Repositories;
using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;
using System.Diagnostics;

namespace ShoppingOnline.Data.Services
{
    public class UserService : IUserRepository
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> AddUser(UserDTO request)
        {
            // Convert UserDTO to User
            var user = _mapper.Map<User>(request);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            // Try to find the User
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<User?> DeleteUser(int id)
        {
            // Try to find the User
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;
            _context.Users.Remove(user);
            // Save changes
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUser(UserDTO request, int id)
        {
            // Try to find the User
            var user = _context.Users.Find(id);
            // If no User is found return null, else update it
            if (user == null) return null;
            user.Genre = request.Genre;
            user.Name = request.Name;
            // Save changes
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
