using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Repository.Impl;

public class NoteRepository : GenericRepository<Note>, INoteRepository
{
    public NoteRepository(NotesContext context) : base( context )
    {
        
    }
}