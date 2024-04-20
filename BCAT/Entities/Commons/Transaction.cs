namespace BCAT.Entities.Commons;

public class Transaction : ITransaction
{
    public string sender;
    public string receiver;
    public int amount;
    public string signature;
    public string hash;
    
    public string createTransaction(string sender, string receiver, int amount, string signature, string hash)
    {
        this.sender = sender;
        this.receiver = receiver;
        this.amount = amount;
        this.signature = signature;
        this.hash = hash;
    }
    
}