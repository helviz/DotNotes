namespace NotesApp.Models;

public class Attachment : BaseEntity
{
    public int NoteId { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set;  }
    
    public Note Note { get; set; }
}