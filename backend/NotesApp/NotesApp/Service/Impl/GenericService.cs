using NotesApp.Models;
using NotesApp.Repository.Impl;
using NotesApp.Repository;
using NotesApp.Utils;

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
        var entity =  await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new NoteException(
                $"{typeof(T).Name} with id {id} not found",
                ErrorCode.NotFound
            );
        }
        return entity; 
    }

    public async Task InsertAsync(T entity)
    {
        if (entity == null)
        {
            throw new NoteException(
                $"{typeof(T).Name} cannot be null",
                ErrorCode.NullEntity
            );
        }
        
        
    }

    public async Task DeleteById(int id)
    {
        var  entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new NoteException(
                $"typeof(T).Name with id{id} not found",
                ErrorCode.NotFound
            );
        }
        await _repository.DeleteAsync(entity);
    }

    public async Task<T> Update(T entity)
    {
        if (entity == null)
        {
            throw new NoteException(
                $"{typeof(T).Name} cannot be null",
                ErrorCode.NullEntity);
        }

        var existing = await _repository.GetByIdAsync(entity.Id);

        if (existing == null)
        {
            throw new NoteException(
                $"{typeof(T).Name} not found",
                ErrorCode.NullEntity);
        }

        await _repository.UpdateAsync(entity);

        return entity;
    }
}