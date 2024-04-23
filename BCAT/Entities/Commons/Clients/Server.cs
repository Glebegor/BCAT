using System.Net;
using System.Net.Sockets;

namespace BCAT.Entities.Commons.Clients;

public class Server
{
    public HttpListener httpListener;
    public string host;
    public int port;

    public Server()
    {
        this.httpListener = new HttpListener();
        this.host = "localhost";
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
    public void Start()
    {
        httpListener.Start();
        Console.WriteLine("Started server on http://" + host + ":" + port.ToString() + "/");
        ThreadPool.QueueUserWorkItem((o) =>
        {
            while (httpListener.IsListening)
            {
                HttpListenerContext context = httpListener.GetContext();
                
                Console.WriteLine(DateTime.Now + "; " + "Request received: " + context.Request.Url);
            }
        });
        Console.WriteLine("Press something to stop the server...");
        Console.ReadKey();
        
        httpListener.Stop();
    }
}