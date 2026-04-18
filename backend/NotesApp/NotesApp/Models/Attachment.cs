namespace NotesApp.Models;

public class Attachment
{
    public int AttachmentId { get; set; }
    public int NoteId { get; set; }
    public IFormFile File { get; set; }
}