using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Repository.Impl;

public class TagRepository: GenericRepository<Tag>, ITagRepository
{
    public TagRepository(NotesContext context) : base(context) {}
}