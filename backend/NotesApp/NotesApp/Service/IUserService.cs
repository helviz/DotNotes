using NotesApp.Models; 
namespace NotesApp.Service;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<User> GetByIdAsync(int id);
    Task<User> UpdateAsync(User user);
    Task<User> AuthenticateAsync(string email, string password);
    
}