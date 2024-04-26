using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using BCAT.Entities.Commons.Clients;
using BCAT.Entities.Interfaces.Controllers;
using BCAT.Entities.Responses;

namespace BCAT.API.Controllers;

public abstract class Controller : IHeadController
{
    public Server server; 
    public Controller(in Server server)
    {
        this.server = server;
    }
    public void PingHandler(HttpListenerContext context, in Server server)
    {
        if (context.Request.HttpMethod == "GET" && context.Request.Url.AbsolutePath == "/ping")
        {
            Success<string> data = new Success<string>("Pong", 200, "Pong");
            SendResponse(context.Response, data, HttpStatusCode.OK);
        }
    }
    public abstract void HandelRequest(HttpListenerContext context);

    public void SendResponse<T>(HttpListenerResponse response, T responseBody, HttpStatusCode statusCode)
    {
        string json = JsonSerializer.Serialize(responseBody);

        // Set the content type header
        response.ContentType = "application/json";

        // Set the status code
        response.StatusCode = (int)statusCode;

        // Write the JSON data to the response stream
        byte[] buffer = Encoding.UTF8.GetBytes(json);
        response.ContentLength64 = buffer.Length;
        response.OutputStream.Write(buffer, 0, buffer.Length);

        // Close the response stream
        response.Close();
    }
    
}

public class NodeController : Controller
{
    public Server server;
    public NodeController(in Server server) : base(server)
    {
        this.server = server;
    }
    public override void HandelRequest(HttpListenerContext context)
    {
        PingHandler(context, server);
    }
    
}

public class NodeMiningController : Controller
{
    public Server server;
    public NodeMiningController(in Server server) : base(server)
    {
        this.server = server;
    }
    public override void HandelRequest(HttpListenerContext context)
    {
        PingHandler(context, server);

    }

}

public class MinerController : Controller
{
    public Server server;
    public MinerController(in Server server) : base(server)
    {
        this.server = server;
    }
    public override void HandelRequest(HttpListenerContext context)
    {
        PingHandler(context, server);
    }
}