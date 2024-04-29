using System.Net;

namespace BCAT.Entities.Interfaces.Controllers;

public interface IUpdateInfoController
{
    public void SendResponse<T>(HttpListenerContext context, T responseBody, HttpStatusCode statusCode);
}