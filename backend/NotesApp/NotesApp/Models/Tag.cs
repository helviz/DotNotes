namespace NotesApp.Models;

public class Tag
{
   public int TagId { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }

    public ICollection<Note> Notes { get;  }= new List<Note>();

}