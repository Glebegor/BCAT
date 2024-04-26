using BCAT.Entities.Enums;

namespace BCAT.Entities.Commons.Clients;

// Client class to work with the server
public abstract class Client
{
    public string host;
    public string port;
    public string myIp = "";
    public List<string> nodesInNetwork;
    public List<string> nodesMiningInNetwork;
    public List<string> miningsInNetwork;
    public List<string> walletsInNetwork;
    public Blockchain blockchain;

    public abstract void Run();
}