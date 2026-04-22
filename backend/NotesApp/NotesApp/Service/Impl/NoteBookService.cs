using NotesApp.Models;
using NotesApp.Repository;

namespace NotesApp.Service.Impl;

public class NoteBookService : GenericService<NoteBook>
{
    public NoteBookService(INotebookRepository repository) : base(repository)
    {
        
    }
}