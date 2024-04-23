using System.Net;
using BCAT.Entities.Interfaces.Controllers;

namespace BCAT.API.Controllers;

public abstract class Controller : IHeadController
{
    public abstract void HandelRequest(HttpListenerContext context);
    public abstract void SendRespunse(HttpListenerResponse response, string responseBody, HttpStatusCode statusCode);
    
}

public class NodeController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
    }

    public override void SendRespunse(HttpListenerResponse response, string responseBody, HttpStatusCode statusCode)
    {
        
    }
}

public class NodeMiningController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {

    }
    
    public override void SendRespunse(HttpListenerResponse response, string responseBody, HttpStatusCode statusCode)
    {
        
    }
}

public class MinerController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
    }
    
    public override void SendRespunse(HttpListenerResponse response, string responseBody, HttpStatusCode statusCode)
    {
        
    }
}