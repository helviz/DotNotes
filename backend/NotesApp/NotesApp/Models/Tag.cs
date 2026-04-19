namespace NotesApp.Models;

public class Tag : BaseEntity
{
   
    public string Name { get; set; }
    public int UserId { get; set; }

    
    public User User { get; set; }
    public ICollection<Tag> Tags { get;  }= new List<Tag>();

}