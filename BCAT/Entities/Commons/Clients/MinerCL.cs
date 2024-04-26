using BCAT.API.Controllers;

namespace BCAT.Entities.Commons.Clients;

public class MinerCL : Client
{
    public override void Run()
    {
        Server server = new Server(this);
        server.Start("mining");
    }
    
}   