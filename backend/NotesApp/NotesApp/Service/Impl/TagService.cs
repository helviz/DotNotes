using NotesApp.Models;
using NotesApp.Repository;
using NotesApp.Repository.Impl;

namespace NotesApp.Service.Impl;

public class TagService : GenericService<Tag>, ITagService
{
    public TagService(TagRepository repository) : base(repository)
    {
        
    }
}