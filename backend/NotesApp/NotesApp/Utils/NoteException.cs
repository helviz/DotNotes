namespace NotesApp.Utils;

public class NoteException : Exception
{
    public string ErrorCode { get;  }
    
    
    public NoteException(){}
    public NoteException(String message) : base(message) {}
    public NoteException(String message, Exception innerException) : base(message, innerException) {}

    public NoteException(String message, string errorcode) : base(message)
    {
        ErrorCode = errorcode; 
    }
}