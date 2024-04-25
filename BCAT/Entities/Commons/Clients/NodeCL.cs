using System.Net.Http;
using BCAT.API.Controllers;


namespace BCAT.Entities.Commons.Clients;

public class NodeCL : Client
{
    public List<string> nodesInNetwork;
    public List<string> nodesMiningInNetwork;
    public List<string> miningsInNetwork;
    public List<string> walletsInNetwork;
    public Blockchain blockchain;
    
    // Initializing of Node blockchain part
    public NodeCL()
    {
        nodesInNetwork = new List<string>();
        nodesMiningInNetwork = new List<string>();
        miningsInNetwork = new List<string>();
        walletsInNetwork = new List<string>();
        blockchain = new Blockchain();
    }

    // Update data from the network of blockchain
    public void UpdateData()
    {
        foreach (var nodeIp in nodesInNetwork)
        {
            
        }
    }
    public override void Run()
    {
        NodeController nodeController = new NodeController();
        Server server = new Server();
        server.Start(NodeController);
    }
}
