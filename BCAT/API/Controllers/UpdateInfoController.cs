using System.Net;
using System.Text;
using BCAT.Entities.Commons.Clients;
using BCAT.Entities.Interfaces.Controllers;
using BCAT.Entities.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BCAT.API.Controllers;

public class UpdateInfoController : IUpdateInfoController
{
    public void SendResponse<T>(HttpListenerContext context, T responseBody, HttpStatusCode statusCode)
    {
        string json = JsonConvert.SerializeObject(responseBody);
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
    public void HandelRequest(HttpListenerContext context, NodeCL client)
    {

        NodesUpdateHandler(context, client);
        
    }

    public void NodesUpdateHandler(HttpListenerContext context, NodeCL client)
    {

        if (context.Request.Url.AbsolutePath == "/update/nodes" && context.Request.HttpMethod == "POST")
        {
            Console.WriteLine(context.Request.Url.AbsolutePath);

            string nodesInput;
            string[] nodesInputs;
            string requestBody;
            
            using (StreamReader reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
            {
                requestBody = reader.ReadToEnd();
            }
            
            dynamic jsonObject = JsonConvert.DeserializeObject(requestBody);
            if (jsonObject.data.GetType() == typeof(string))
            {
                nodesInput = jsonObject.data;
                if (!client.nodesInNetwork.Contains(nodesInput))
                {
                    client.nodesInNetwork.Add(nodesInput);
                }
            }
            else if (jsonObject.data.GetType() == typeof(JArray))
            {
                nodesInputs = jsonObject.data.ToObject<string[]>();
                foreach (string node in nodesInputs)
                {
                    if (!client.nodesInNetwork.Contains(node))
                    {
                        client.nodesInNetwork.Add(node);
                    }
                }
            }

            Success<string> data = new Success<string>("Node updated", 200, "");
            SendResponse<Success<string>>(context, data, HttpStatusCode.OK);
        }
    }
}