namespace BCAT.Entities.Responses;

public class Error<T>
{
    public string message { get; set; }
    public int code;
    public T error { get; set; }

    public Error(string message, int code, T error)
    {
        this.message = message;
        this.code = code;
        this.error = error;
    }
}