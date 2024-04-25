using System.Net;

namespace BCAT.Entities.Interfaces.Controllers;

public interface IHeadController
{
    void HandelRequest(HttpListenerContext context);
    public void SendResponse<T>(HttpListenerResponse response, T responseBody, HttpStatusCode statusCode);
}