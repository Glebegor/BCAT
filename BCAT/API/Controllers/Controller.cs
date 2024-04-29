using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using BCAT.Entities.Commons.Clients;
using BCAT.Entities.Interfaces.Controllers;
using BCAT.Entities.Responses;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BCAT.API.Controllers;

public abstract class Controller : IHeadController
{
    public void PingHandler(HttpListenerContext context, NodeMiningCL client)
    {
       
    }
    public void PingHandler(HttpListenerContext context, MinerCL client)
    {
       
    }
    public void PingHandler(HttpListenerContext context, NodeCL client)
    {
        if (context.Request.HttpMethod == "POST" && context.Request.Url.AbsolutePath == "/ping")
        {
            string requestIp;
            string requestBody;
            
            using (StreamReader reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
            {
                requestBody = reader.ReadToEnd();
            }
            
        
            dynamic jsonObject = JsonConvert.DeserializeObject(requestBody);
            requestIp = jsonObject.ip;
            Console.WriteLine("Request ip: " + requestIp);
            foreach (string node in client.nodesInNetwork)
            {
                Console.WriteLine(node);
            }
            if (!client.nodesInNetwork.Contains(requestIp))
            {
                client.nodesInNetwork.Add(requestIp);
                
            }
            Success<string> data = new Success<string>("Pong", 200, "Pong");
            SendResponse<Success<string>>(context, data, HttpStatusCode.OK);
            
        }
    }


    public void SendResponse<T>(HttpListenerContext context, T responseBody, HttpStatusCode statusCode)
    {
        string json = JsonSerializer.Serialize(responseBody);
        
        // Set the content type header
        context.Response.ContentType = "application/json";
        
        // Set the status code
        context.Response.StatusCode = (int)statusCode;
        
        // Write the JSON data to the response stream
        byte[] buffer = Encoding.UTF8.GetBytes(json);
         context.Response.ContentLength64 = buffer.Length;
         context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        
        // Close the response stream
         context.Response.Close();
    }
}

public class NodeController : Controller
{
    // public Client client;
    // public NodeController()
    // {
    //     this.client = client;
    // }
    public void HandelRequest(HttpListenerContext context, NodeCL client)
    {
        PingHandler(context, client);
    }
    
}

public class NodeMiningController : Controller
{
    // public Client client;
    // public NodeMiningController()
    // {
    //     this.client = client;
    // }
    public void HandelRequest(HttpListenerContext context, NodeMiningCL client)
    {
        PingHandler(context, client);
    }

}

public class MinerController : Controller
{
    // public Client client;
    // public MinerController()
    // {
    //     this.client = client;
    // }
    public void HandelRequest(HttpListenerContext context, MinerCL client)
    {
        PingHandler(context, client);
    }
}