using System.Net;
using System.Net.Sockets;
using BCAT.API.Controllers;

namespace BCAT.Entities.Commons.Clients;

public class Server
{
    public HttpListener httpListener;
    public string host;
    public int port;

    // Initializing of the server onn machine
    public Server()
    {
        this.httpListener = new HttpListener();
        this.host = "127.0.0.1";
        this.port = 8080;
        while (true)
        {
            if (!CheckPort(port))
            {
                httpListener.Prefixes.Add("http://" + host + ":" + port.ToString() + "/");
                break; 
            }
            else
            {
                port += 1;
            }
        }
    }

    // Check if the port is available to run more servers on one machine
    public bool CheckPort(int port)
    {
        try
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("localhost", port);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    // Start of the server
    public void Start(NodeCL client)
    {
        httpListener.Start();
        Console.WriteLine("Started server on http://" + host + ":" + port.ToString() + "/");
        Console.WriteLine("________________________________________________________");

        ThreadPool.QueueUserWorkItem((o) =>
        {
            while (httpListener.IsListening)
            {
                HttpListenerContext context = httpListener.GetContext();
                Console.WriteLine(DateTime.Now + "; " + "Request received: " + context.Request.Url + "; " + context.Request.Url.AbsolutePath + " - " + context.Request.HttpMethod);
                NodeController controller = new NodeController();
                controller.HandelRequest(context, client);
            }
        });
        Console.ReadKey();
        
        httpListener.Stop();
    }
    public void Start(MinerCL client)
    {
        httpListener.Start();
        Console.WriteLine("Started server on http://" + host + ":" + port.ToString() + "/");
        Console.WriteLine("________________________________________________________");
        ThreadPool.QueueUserWorkItem((o) =>
        {
            while (httpListener.IsListening)
            {
                HttpListenerContext context = httpListener.GetContext();
                Console.WriteLine(DateTime.Now + "; " + "Request received: " + context.Request.Url + "; " + context.Request.Url.AbsolutePath + " - " + context.Request.HttpMethod);
                NodeMiningController controller = new NodeMiningController();
                // controller.HandelRequest(context);
            }
        });
        Console.ReadKey();
        
        httpListener.Stop();
    }
    public void Start(NodeMiningCL client)
    {
        httpListener.Start();
        Console.WriteLine("Started server on http://" + host + ":" + port.ToString() + "/");
        Console.WriteLine("________________________________________________________");
        ThreadPool.QueueUserWorkItem((o) =>
        {
            while (httpListener.IsListening)
            {
                HttpListenerContext context = httpListener.GetContext();
                Console.WriteLine(DateTime.Now + "; " + "Request received: " + context.Request.Url + "; " + context.Request.Url.AbsolutePath + " - " + context.Request.HttpMethod);
                NodeMiningController controller = new NodeMiningController();
                // controller.Ha(context);
            }
        });
        Console.ReadKey();
        
        httpListener.Stop();
    }
    
}