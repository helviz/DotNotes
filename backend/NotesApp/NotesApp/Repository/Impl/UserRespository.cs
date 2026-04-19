using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Repository.Impl;

public class UserRespository : GenericRepository<User>, IUserRepository
{
    public UserRespository(NotesContext context) : base (context) {}
}