using System.Net;
using System.Net.Sockets;
using BCAT.API.Controllers;

namespace BCAT.Entities.Commons.Clients;

public class Server
{
    public HttpListener httpListener;
    public string host;
    public int port;
    private Controller controller;

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
    public void Start(string controllerName)
    {
        
        httpListener.Start();
        Console.WriteLine("Started server on http://" + host + ":" + port.ToString() + "/");
        ThreadPool.QueueUserWorkItem((o) =>
        {
            while (httpListener.IsListening)
            {
                HttpListenerContext context = httpListener.GetContext();
                Console.WriteLine(DateTime.Now + "; " + "Request received: " + context.Request.Url + "; " + context.Request.Url.AbsolutePath + " - " + context.Request.HttpMethod);
                switch (controllerName)
                {
                    case "node":
                        controller = new NodeController();
                        break;
                    case "node-mining":
                        controller = new NodeMiningController();
                        break;
                    case "miner":
                        controller = new MinerController();
                        break;
                    case "wallet":
                        break;
                }
                controller.HandelRequest(context);
            }
        });
        Console.WriteLine("Press something to stop the server...");
        Console.ReadKey();
        
        httpListener.Stop();
    }
    
}