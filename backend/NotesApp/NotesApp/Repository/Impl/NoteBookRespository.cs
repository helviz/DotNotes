using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Repository.Impl;

public class NoteBookRespository: GenericRepository<NoteBook>, INoteBookRepository
{
    public NoteBookRespository(NotesContext context) : base(context)
    {
        
    }
}