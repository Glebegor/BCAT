using System.Net.Http;
using BCAT.API.Controllers;


namespace BCAT.Entities.Commons.Clients;

public class NodeCL : Client
{
    public string myIp = "";
    public List<string> nodesInNetwork;
    public List<string> nodesMiningInNetwork;
    public List<string> miningsInNetwork;
    public List<string> walletsInNetwork;
    public Blockchain blockchain;
    
    // Initializing of Node blockchain part
    public NodeCL()
    {
        myIp = "127.0.0.1:8080";
        nodesInNetwork = new List<string>();
        nodesInNetwork.Add(myIp);
        nodesMiningInNetwork = new List<string>();
        miningsInNetwork = new List<string>();
        walletsInNetwork = new List<string>();
        blockchain = new Blockchain();
    }
    
    static async void pingIpOfNode(HttpClient client, string ip)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync(ip);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        
    }

    // Update data from the network of blockchain
    public async void UpdateData()
    {
        HttpClient client = new HttpClient();
        while (true)
        {
            Console.WriteLine(DateTime.Now + "; " + "Updating data...");
            await Task.Delay(5000);
            
            foreach (var nodeIp in nodesInNetwork)
            {
                if (nodeIp != myIp)
                {
                    pingIpOfNode(client, "http://" + nodeIp + "/ping");
                }
            }
        }
    }
    public override void Run()
    {
        Server server = new Server();
        myIp = server.host + ":" + server.port.ToString();
        UpdateData();
        server.Start("node");
    }
}
