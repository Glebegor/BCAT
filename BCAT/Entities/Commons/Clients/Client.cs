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
    
    // Initializing of Node blockchain part
    public Client()
    {
        myIp = "127.0.0.1:8080";
        nodesInNetwork = new List<string>();
        nodesInNetwork.Add(myIp);
        nodesMiningInNetwork = new List<string>();
        miningsInNetwork = new List<string>();
        walletsInNetwork = new List<string>();
        blockchain = new Blockchain();
    }

    public abstract void Run();
}