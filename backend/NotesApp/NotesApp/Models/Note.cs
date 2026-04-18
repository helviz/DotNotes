namespace NotesApp.Models;

public class Note
{
    public int NoteId { get; set; }
    public int NotebookId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string CreatedAt { get; set; }
    public bool IsArchived { get; set; }
    public bool IsFavorite { get; set; }

    public ICollection<Attachment> Attachments { get;  }= new List<Attachment>();
    public ICollection<Tag> Tags { get;  } = new List<Tag>();
}