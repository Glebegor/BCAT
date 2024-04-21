using BCAT.Entities.Commons.Clients;

namespace BCAT.Bootstrap;

public class App
{
    public int choise;
    public Client client;

    public void SetClient()
    {
        Console.WriteLine("Starting of the Client...");
        Console.WriteLine("1. Node");
        Console.WriteLine("2. Node-Mining");
        Console.WriteLine("3. Mining");
        Console.WriteLine("4. Wallet");
        choise = Convert.ToInt32(Console.ReadLine());
        switch (choise)
        {
            case 1:
                Console.WriteLine("Node");
                client = new NodeCL();
                break;
            case 2:
                Console.WriteLine("Node-Mining");
                client = new NodeCL();
                break;
            case 3:
                Console.WriteLine("Mining");
                client = new NodeCL();
                break;
            case 4:
                Console.WriteLine("Wallet");
                client = new NodeCL();
                break;
            default:
                Console.WriteLine("Invalid choise");
                break;
        }
    }
}