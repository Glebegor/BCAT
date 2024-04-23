using BCAT.Entities.Enums;

namespace BCAT.Entities.Commons.Clients;

// Client class to work with the server
public abstract class Client
{
    public string host;
    public string port;

    public abstract void Run();
}