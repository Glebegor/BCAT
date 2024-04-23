using System.Net;

namespace BCAT.api.Controllers;

public abstract class Controller
{
    public abstract void HandelRequest(HttpListenerContext context);
}

public class NodeController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
        // Get the request object
        HttpListenerRequest request = context.Request;

        // Get the response object
        HttpListenerResponse response = context.Response;
    }
}

public class NodeMiningController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
        // Get the request object
        HttpListenerRequest request = context.Request;

        // Get the response object
        HttpListenerResponse response = context.Response;
    }
}

public class MinerController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
        // Get the request object
        HttpListenerRequest request = context.Request;

        // Get the response object
        HttpListenerResponse response = context.Response;
    }
}