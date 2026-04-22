using NotesApp.Models;
using NotesApp.Repository;

namespace NotesApp.Service.Impl;

public class AttachmentService : GenericService<Attachment>, IAttachmentService
{
    public AttachmentService(IAttachmentRepository repository):
        base (repository){}
}