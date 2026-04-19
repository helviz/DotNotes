using NotesApp.Models;

namespace NotesApp.Repository;

public interface IGenericRepository<T> where T: BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);

}