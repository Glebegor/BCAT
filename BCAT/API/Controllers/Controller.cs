using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using BCAT.Entities.Interfaces.Controllers;
using BCAT.Entities.Responses;

namespace BCAT.API.Controllers;

public abstract class Controller : IHeadController
{
    
    public void PingHandler(HttpListenerContext context)
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
        Console.WriteLine(json);

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
    public override void HandelRequest(HttpListenerContext context)
    {
        PingHandler(context);
    }
    
}

public class NodeMiningController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
        PingHandler(context);

    }

}

public class MinerController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
        PingHandler(context);
    }
}