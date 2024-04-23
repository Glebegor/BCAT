using System.Net.Http;


namespace BCAT.Entities.Commons.Clients;

public class NodeCL : Client
{
    public List<string> nodesInNetwork;
    public List<string> nodesMiningInNetwork;
    public List<string> miningsInNetwork;
    public List<string> walletsInNetwork;
    public Blockchain blockchain;
    
    public NodeCL()
    {
        nodesInNetwork = new List<string>();
        nodesMiningInNetwork = new List<string>();
        miningsInNetwork = new List<string>();
        walletsInNetwork = new List<string>();
        blockchain = new Blockchain();
    }

    public void UpdateData()
    {
        foreach (var nodeIp in nodesInNetwork)
        {
            
        }
    }
    public override void Run()
    {
        Server server = new Server();
        server.Start();
    }
}
