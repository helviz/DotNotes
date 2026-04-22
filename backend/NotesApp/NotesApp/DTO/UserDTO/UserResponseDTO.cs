namespace NotesApp.DTO.UserDTO;

public class UserResponseDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}