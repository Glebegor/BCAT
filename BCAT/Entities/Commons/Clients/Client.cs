namespace BCAT.Entities.Commons.Clients;

public class Client
{
    public int choise;
    enum typeOfClient
    {
        Node,
        MiningNode,
        Miner,
        Wallet
    }
    public Client()
    {
        string choiseStr;

        Console.WriteLine("Initializing Client...");
        Console.WriteLine("1-Node \n2-Mining Node \n3-Miner \n4-Wallet");
        Console.WriteLine("Choise your client type: ");
        while (true) 
        { 
           choiseStr = Console.ReadLine();
           this.choise = int.Parse(choiseStr)-1;
           if (choise < 5 && choise >= 0)
           {
               Console.WriteLine("You are " + (typeOfClient)this.choise);
               break;
           }
        }
    }
}