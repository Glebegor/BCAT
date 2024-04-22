using System.Net;

namespace BCAT.Bootstrap;

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
        
        httpListener.Prefixes.Add("http://" + host + ":" + port);
    }
    
    public void Start()
    {
        httpListener.
        httpListener.Start();
        
        
    }
}