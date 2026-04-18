namespace NotesApp.Models;

public class NoteBook
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set;  }
    
    public User User { get; set; }
    public ICollection<Note> Notes { get; } = new List<Note>();

}