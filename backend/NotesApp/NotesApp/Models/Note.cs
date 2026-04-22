namespace NotesApp.Models;

public class Note : BaseEntity
{
    
    public int NotebookId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public bool IsArchived { get; set; } = false;
    public bool IsFavorite { get; set; } = false; 

    public ICollection<Attachment> Attachments { get;  }= new List<Attachment>();
    public ICollection<Tag> Tags { get;  } = new List<Tag>();
}