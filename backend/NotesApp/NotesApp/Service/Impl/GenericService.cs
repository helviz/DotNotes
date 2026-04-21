using NotesApp.Models;
using NotesApp.Repository.Impl;
using NotesApp.Repository;

namespace NotesApp.Service.Impl;

public class GenericService<T> : IGenericService<T> where T : BaseEntity
{
    private readonly IGenericRepository<T> _repository; 
    
    public GenericService (IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<List<T>> GetAllAync()
        => await _repository.GetAllAsync();

    public async Task<T> GetById(int id)
    {
        var result =  await _repository.GetByIdAsync(id);
        if (result == null)
        {
            throw new Exception("Result not found");
        }
        return result; 
    }

    public async Task InsertAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        await _repository.AddAsync(entity);
    }

    public async Task DeleteById(int id)
    {
        var  entity = await _repository.GetByIdAsync(id);
        if (entity != null)
        {
            await _repository.DeleteAsync(entity);
            return; 
        }
        throw new Exception( "Entity not found");
    }

    public async Task UpdateById(T entity)
    {
        await _repository.UpdateAsync(entity);
        
    }
}