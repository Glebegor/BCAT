using System.Net;
using BCAT.Entities.Interfaces.Controllers;

namespace BCAT.api.Controllers;

public abstract class Controller : IHeadController
{
    public abstract void HandelRequest(HttpListenerContext context);
}

public class NodeController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
    }
}

public class NodeMiningController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {

    }
}

public class MinerController : Controller
{
    public override void HandelRequest(HttpListenerContext context)
    {
    }
}