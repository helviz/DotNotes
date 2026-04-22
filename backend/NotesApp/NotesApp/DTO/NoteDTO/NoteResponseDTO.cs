namespace NotesApp.DTO.NoteDTO;

public class NoteResponseDTO
{
    public int Id { get; set; }
    public int NotebookId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsArchived { get; set; }
    public bool IsFavorite { get; set; }

    public List<string> Tags { get; set; }
    public List<string> Attachments { get; set; }
}