using System.Security.Cryptography;
using BCAT.Bootstrap;
using BCAT.Entities.Interfaces;
using BCAT.Entities.Commons;
using BCAT.Entities.Commons.Clients;
using BCAT.Internal.Validators;

namespace BCAT;

public class Program
{
    public static void Main()
    {
        
        // Client initialization
        App app = new App();
        App.SetClient();
        App.client.Run();

    }
}

