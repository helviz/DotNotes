using NotesApp.Models;
using NotesApp.Repository;
using NotesApp.Utils;

namespace NotesApp.Service.Impl;

public class NoteService : GenericService<Note> ,INoteService
{
    private readonly IGenericRepository<Note> _noteRepository;
    private readonly IGenericRepository<Tag> _tagRepository;
    private readonly IGenericRepository<Attachment> _attachmentRepository;

    public NoteService(
        IGenericRepository<Note> noteRepository,
        IGenericRepository<Tag> tagRepository,
        IGenericRepository<Attachment> attachmentRepository) 
    :base(noteRepository)
    {
        _noteRepository = noteRepository;
        _tagRepository = tagRepository;
        _attachmentRepository = attachmentRepository;
    }

    public async Task<Note> CreateAsync(Note note)
    {
        if (string.IsNullOrWhiteSpace(note.Title))
            throw new NoteException("Title is required");

        await _noteRepository.AddAsync(note);
        return note;
    }
    
    public async Task<Note> GetByIdAsync(int id)
    {
        var note = await _noteRepository.GetByIdAsync(id);

        if (note == null)
            throw new NoteException("Note not found");

        return note;
    }

    
    public async Task<List<Note>> GetAllAsync()
    {
        return await _noteRepository.GetAllAsync();
    }

    
    public async Task<Note> UpdateAsync(Note note)
    {
        var existing = await GetByIdAsync(note.Id);

        existing.Title = note.Title;
        existing.Content = note.Content;
        existing.NotebookId = note.NotebookId;

        await _noteRepository.UpdateAsync(existing);
        return existing;
    }

    
    public async Task DeleteAsync(int id)
    {
        var note = await GetByIdAsync(id);
        await _noteRepository.DeleteAsync(note);
    }

    
    public async Task ArchiveAsync(int id)
    {
        var note = await GetByIdAsync(id);
        note.IsArchived = true;

        await _noteRepository.UpdateAsync(note);
    }

    public async Task UnarchiveAsync(int id)
    {
        var note = await GetByIdAsync(id);
        note.IsArchived = false;

        await _noteRepository.UpdateAsync(note);
    }

    
    public async Task ToggleFavoriteAsync(int id)
    {
        var note = await GetByIdAsync(id);
        note.IsFavorite = !note.IsFavorite;

        await _noteRepository.UpdateAsync(note);
    }

    
    public async Task<List<Note>> GetByNotebookAsync(int notebookId)
    {
        return await _noteRepository.FindAllAsync(n => n.NotebookId == notebookId);
    }

    public async Task<List<Note>> GetArchivedAsync()
    {
        return await _noteRepository.FindAllAsync(n => n.IsArchived);
    }

    public async Task<List<Note>> GetFavoritesAsync()
    {
        return await _noteRepository.FindAllAsync(n => n.IsFavorite);
    }

    
    public async Task<List<Note>> SearchAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return new List<Note>();

        query = query.ToLower();

        return await _noteRepository.FindAllAsync(n =>
            n.Title.ToLower().Contains(query) ||
            n.Content.ToLower().Contains(query));
    }

    
    public async Task AddTagAsync(int noteId, int tagId)
    {
        var note = await GetByIdAsync(noteId);
        var tag = await _tagRepository.GetByIdAsync(tagId);

        if (tag == null)
            throw new NoteException("Tag not found");

        if (!note.Tags.Any(t => t.Id == tagId))
            note.Tags.Add(tag);

        await _noteRepository.UpdateAsync(note);
    }

    public async Task RemoveTagAsync(int noteId, int tagId)
    {
        var note = await GetByIdAsync(noteId);

        var tag = note.Tags.FirstOrDefault(t => t.Id == tagId);
        if (tag != null)
            note.Tags.Remove(tag);

        await _noteRepository.UpdateAsync(note);
    }

    
    public async Task AddAttachmentAsync(int noteId, Attachment attachment)
    {
        var note = await GetByIdAsync(noteId);

        await _attachmentRepository.AddAsync(attachment);
        note.Attachments.Add(attachment);

        await _noteRepository.UpdateAsync(note);
    }

    public async Task RemoveAttachmentAsync(int noteId, int attachmentId)
    {
        var note = await GetByIdAsync(noteId);

        var attachment = note.Attachments.FirstOrDefault(a => a.Id == attachmentId);

        if (attachment != null)
        {
            note.Attachments.Remove(attachment);
            await _attachmentRepository.DeleteAsync(attachment);
        }

        await _noteRepository.UpdateAsync(note);
    }
    
    
}