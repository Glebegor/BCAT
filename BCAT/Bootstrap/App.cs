using BCAT.Entities.Commons.Clients;

namespace BCAT.Bootstrap;

public class App
{
    public static Client client;

    public static void SetClient()
    {
        int choise;
        Console.WriteLine("Starting of the Client...");
        Console.WriteLine("1. Node");
        Console.WriteLine("2. Mining Node");
        Console.WriteLine("3. Miner");
        Console.WriteLine("4. Wallet");
        choise = Convert.ToInt32(Console.ReadLine());
        switch (choise)
        {
            case 1:
                Console.WriteLine("You are Node");
                client = new NodeCL();
                break;
            case 2:
                Console.WriteLine("You are Mining Node");
                client = new NodeMiningCL();
                break;
            case 3:
                Console.WriteLine("You are Miner");
                client = new MinerCL();
                break;
            case 4:
                Console.WriteLine("You are Wallet");
                client = new WalletCL();
                break;
            default:
                Console.WriteLine("Invalid choise");
                break;
        }
    }
}