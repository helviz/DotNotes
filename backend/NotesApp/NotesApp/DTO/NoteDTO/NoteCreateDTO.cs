namespace NotesApp.DTO.NoteDTO;

public class NoteCreateDTO
{
    public int NotebookId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}