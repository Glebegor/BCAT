using System.Net;

namespace BCAT.Entities.Interfaces.Controllers;

public interface IHeadController
{
    void HandelRequest(HttpListenerContext context);
    void SendRespunse(HttpListenerResponse response, string responseBody, HttpStatusCode statusCode);
}