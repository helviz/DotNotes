using Microsoft.EntityFrameworkCore;
using NotesApp.Models;
using NotesApp.Data;

namespace NotesApp.Repository.Impl;

public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
{
    protected readonly NotesContext _context;

    public GenericRepository(NotesContext context)
    {
        _context = context; 
    }

    public async Task<T?> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);
    

    public async Task<List<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
         _context.Set<T>().Update(entity);
         await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        entity.IsDelete = true;
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        

    }


}