using NotesApp.Models;
namespace NotesApp.Service;

public interface INoteService : IGenericService<Note>
{
    // State management
    Task ArchiveAsync(int id);
    Task UnarchiveAsync(int id);
    Task ToggleFavoriteAsync(int id);

    // Filtering
    Task<List<Note>> GetByNotebookAsync(int notebookId);
    Task<List<Note>> GetArchivedAsync();
    Task<List<Note>> GetFavoritesAsync();

    // Search
    Task<List<Note>> SearchAsync(string query);

    // Tags
    Task AddTagAsync(int noteId, int tagId);
    Task RemoveTagAsync(int noteId, int tagId);

    // Attachments
    Task AddAttachmentAsync(int noteId, Attachment attachment);
    Task RemoveAttachmentAsync(int noteId, int attachmentId);
}