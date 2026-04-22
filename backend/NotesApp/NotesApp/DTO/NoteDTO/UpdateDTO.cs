namespace NotesApp.DTO.NoteDTO;

public class UpdateDTO
{
    public int Id { get; set; }
    public int NotebookId { get; set; }
    public string Title { get; set; }
    public string content { get; set; }
}