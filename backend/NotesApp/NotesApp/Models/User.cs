namespace NotesApp.Models;

public class User : BaseEntity
{
    
    public string UserName { get; set; }
    public string Email { get; set;  }
    public string PasswordHash { get; set; }
    

    public ICollection<NoteBook> NoteBooks { get; } = new List<NoteBook>();
    public ICollection<Note> Notes { get; } = new List<Note>();
}