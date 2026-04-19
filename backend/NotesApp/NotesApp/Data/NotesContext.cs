using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.Data;

public class NotesContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteBook> NoteBooks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;database=Notesdb;user=root;password=;",
            ServerVersion.AutoDetect("server=localhost;database=Notesdb;user=root;password=;")
        );


    }
    
    


}