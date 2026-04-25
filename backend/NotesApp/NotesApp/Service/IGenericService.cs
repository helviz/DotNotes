using NotesApp.Models;

namespace NotesApp.Service;

public interface IGenericService<T> where T: BaseEntity
{
    Task<List<T>> GetAllAync();
    Task<T> GetById(int id);
    Task InsertAsync(T entity);
    Task DeleteById(int id);
    Task <T>Update(T entity);

}