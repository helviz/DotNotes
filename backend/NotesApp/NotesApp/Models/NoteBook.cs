namespace NotesApp.Models;

public class NoteBook : BaseEntity
{
    
    public int UserId { get; set; }
    public string Title { get; set; }
    
    public User User { get; set; }
    public ICollection<Note> Notes { get; } = new List<Note>();

}