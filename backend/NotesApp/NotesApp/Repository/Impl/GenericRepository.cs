using Microsoft.EntityFrameworkCore;
using NotesApp.Models;
using NotesApp.DbContext;

namespace NotesApp.Repository.Impl;

public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
{
    protected readonly NotesContext _context;

    public GenericRepository(NotesContext context)
    {
        _context = context; 
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    public void Update(T entity)
        => _context.Set<T>().Update(entity);

    public void Delete(T entity)
        => _context.Set<T>().Remove(entity);
    

}