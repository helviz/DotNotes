using Microsoft.AspNetCore.Identity;
using NotesApp.Models;
using NotesApp.Repository;
using NotesApp.Utils;

namespace NotesApp.Service.Impl;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository; 
    }

    public async Task<User> CreateAsync(User user)
    {
        var existing = await _userRepository.FindAsync(u => u.Email == user.Email);

        if (existing != null)
            throw new NoteException("User already exists");

        user.Password = HashPassword(user.Password);

        await _userRepository.AddAsync(user);
        return user; 

    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new NoteException("user not found");
        return user; 
    }

    public async Task<User> UpdateAsync(User user)
    {
        var existing = await GetByIdAsync(user.Id);

        existing.UserName = user.UserName;
        existing.Email = user.Email;

        await _userRepository.UpdateAsync(existing);
        return existing;
    }

    public async Task<User> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.FindAsync(u => u.Email == email);

        if (user == null || !VerifyPassword(password, user.Password))
            throw new NoteException("Invalid credentials");

        return user;
    }
    
    private string HashPassword(string password)
    {
        return Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(password)
            );
    }

    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }
}