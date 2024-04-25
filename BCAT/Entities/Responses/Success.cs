using BCAT.Entities.Interfaces;

namespace BCAT.Entities.Responses;

public class Success<T> 
{
    public string message { get; set; }
    public int code;
    public T data { get; set; }

    public Success(string message, int code, T data)
    {
        this.message = message;
        this.code = code;
        this.data = data;
    }
}