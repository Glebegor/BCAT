using BCAT.API.Controllers;

namespace BCAT.Entities.Commons.Clients;

public class NodeMining : Client
{
    public override void Run()
    {
        Server server = new Server();
        server.Start("node-mining", this);
    }

}