using System.Net;

namespace BCAT.Entities.Commons.Clients;

public class Server
{
    public HttpListener httpListener;
    public string host;
    public string port;

    public Server()
    {
        this.httpListener = new HttpListener();
        this.host = "localhost";
        this.port = "8080";
        
        httpListener.Prefixes.Add("http://" + host + ":" + port + "/");
    }
    
    public void Start()
    {
        httpListener.Start();
        Console.WriteLine("Started server on http://" + host + ":" + port + "/");
        ThreadPool.QueueUserWorkItem((o) =>
        {
            while (httpListener.IsListening)
            {
                HttpListenerContext ocntext = httpListener.GetContext();
                
                Console.WriteLine(DateTime.Now + "; " + "Request received: " + ocntext.Request.Url);
            }
        });
        Console.WriteLine("Press something to stop the server...");
        Console.ReadKey();
        
        httpListener.Stop();
    }
}