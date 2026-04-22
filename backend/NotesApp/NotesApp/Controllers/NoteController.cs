using Microsoft.AspNetCore.Mvc;
using NotesApp.Repository;
using NotesApp.Service;

namespace NotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }
    
    
}