using Microsoft.AspNetCore.Mvc;
using NotesApp.DTO.NoteDTO;
using NotesApp.Models;
using NotesApp.Service;

namespace NotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(NoteCreateDTO dto)
    {
        var note = new Note
        {
            NotebookId = dto.NotebookId,
            Title = dto.Title,
            Content = dto.Content
        };
        
        await _noteService.InsertAsync(note);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
            return BadRequest("invalid Id");
        var note = await _noteService.GetById(id);
        return Ok(ToDto(note));

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var notes = await  _noteService.GetAllAync();
        return Ok(notes.Select(ToDto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateDTO dto)
    {
        var note = new Note
        {
            Id = dto.Id,
            NotebookId = dto.NotebookId,
            Content = dto.content,
            Title = dto.Title
        };

        var updated = await _noteService.Update(note);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _noteService.DeleteById(id);
        return NoContent();
    }

    [HttpPatch("{id}/archive")]
    public async Task<IActionResult> Archive(int id)
    {
        await _noteService.ArchiveAsync(id);
        return NoContent();
    }
    
    [HttpPatch("{id}/unarchive")]
    public async Task<IActionResult> Unarchive(int id)
    {
        await _noteService.UnarchiveAsync(id);
        return NoContent();
    }
    
    [HttpPatch("{id}/favorite")]
    public async Task<IActionResult> ToggleFavorite(int id)
    {
        await _noteService.ToggleFavoriteAsync(id);
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string query)
    {
        var results = await _noteService.SearchAsync(query);
        return  Ok(results.Select(ToDto));
    }

    [HttpGet("archived")]
    public async Task<IActionResult> GetArchived()
    {
        var archived = await _noteService.GetArchivedAsync();
        return Ok(archived.Select(ToDto));
    }

    [HttpPost("{id}/tags/{tagId}")]
    public async Task<IActionResult> AddTag(int id, int tagId)
    {
        await _noteService.AddTagAsync(id, tagId);
        return NoContent();
    }
    
    [HttpDelete("{id}/tags/{tagId}")]
    public async Task<IActionResult> RemoveTag(int id, int tagId)
    {
        await _noteService.RemoveTagAsync(id, tagId);
        return NoContent();
    }
    
    [HttpPost("{id}/attachments")]
    public async Task<IActionResult> AddAttachment(int id, [FromBody] string filePath)
    {
        var attachment = new Attachment
        {
            FilePath = filePath
        };

        await _noteService.AddAttachmentAsync(id, attachment);
        return NoContent();
    }

    
    [HttpDelete("{id}/attachments/{attachmentId}")]
    public async Task<IActionResult> RemoveAttachment(int id, int attachmentId)
    {
        await _noteService.RemoveAttachmentAsync(id, attachmentId);
        return NoContent();
    }


    
    // MAPPER
    private static NoteResponseDTO ToDto(Note note)
    {
        return new NoteResponseDTO
        {
            Id = note.Id,
            NotebookId = note.NotebookId,
            Title = note.Title,
            Content = note.Content,
            IsArchived = note.IsArchived,
            IsFavorite = note.IsFavorite,
            Tags = note.Tags.Select(t => t.Name).ToList(),
            Attachments = note.Attachments.Select(a => a.FilePath).ToList()
        };
    }
    
}