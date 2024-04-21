using BCAT.Entities.Enums;

namespace BCAT.Entities.Commons.Clients;

public abstract class Client
{
    public string host;
    public string port;

    public abstract void Run();
}