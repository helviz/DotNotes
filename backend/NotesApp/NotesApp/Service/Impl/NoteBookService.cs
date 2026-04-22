using NotesApp.Models;
using NotesApp.Repository;

namespace NotesApp.Service.Impl;

public class NoteBookService : GenericService<NoteBook> , INoteBookService
{
    public NoteBookService(IGenericRepository<NoteBook> repository) : base(repository)
    {
        
    }
}