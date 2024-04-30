namespace BCAT.Entities.Commons.Clients;

public class WalletCL : Client
{
    Wallet wallet;
    public override void Run()
    {
        Console.WriteLine("1. Create wallet");
        Console.WriteLine("2. Load wallet");
        int choise = int.Parse(Console.ReadLine());
        switch (choise)
        {
            case 1:
                CreateWallet();
                break;
            case 2:
                LoadWallet();
                break;
            default:
                Console.WriteLine("Invalid choise");
                break;
        }
    }

    public void CreateWallet()
    {
        
    }

    public void LoadWallet()
    {
        
    }
}