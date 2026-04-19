using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Repository.Impl;

public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
{
    public AttachmentRepository(NotesContext context) : base(context)
    {
        
    }
}