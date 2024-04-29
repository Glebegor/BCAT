using System.Net;
using BCAT.Entities.Commons.Clients;

namespace BCAT.Entities.Interfaces.Controllers;

public interface IHeadController
{
    public abstract void HandelRequest(HttpListenerContext context);
    public void SendResponse<T>(HttpListenerContext context, T responseBody, HttpStatusCode statusCode);
}