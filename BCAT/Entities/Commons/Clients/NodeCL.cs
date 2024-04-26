using System.Net.Http;
using System.Text;
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
    
    async void pingIpOfNode(HttpClient client, string ip)
    {
        try
        {
            HttpContent content = new StringContent(" {\"ip\":" + "\"" + ip + "\"" + " } ", Encoding.UTF8, "text/plain");
            
            HttpResponseMessage response = await client.PostAsync(ip.Split("/")[2], content);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.WriteLine(DateTime.Now + "; Node " + ip + " is not available.");
            nodesInNetwork.Remove(ip.Split("/")[2]);
        }
    }

    // Update data from the network of blockchain
    public async void UpdateData()
    {
        HttpClient client = new HttpClient();
        while (true)
        {
            await Task.Delay(5000);
            Console.WriteLine(DateTime.Now + "; " + "Updating data...");

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
        Server server = new Server(this);
        myIp = server.host + ":" + server.port.ToString();
        UpdateData();
        server.Start("node");
    }
}
