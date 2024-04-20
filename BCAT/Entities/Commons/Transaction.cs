using BCAT.Entities.Interfaces;
namespace BCAT.Entities.Commons;

public class Transaction : ITransaction
{
    public string sender;
    public string receiver;
    public int amount;
    public string signature;
    public string hash;
    
    public string CreateTransaction(string sender, string receiver, int amount, string signature, string hash)
    {
        this.sender = sender;
        this.receiver = receiver;
        this.amount = amount;
        this.signature = signature;
        this.hash = hash;
        return "";
    }

    public (string, string) SerializerToJsonString()
    {
        string jsonString = $"{{ \"sender\": \"{sender}\", \"receiver\": \"{receiver}\", \"amount\": {amount}, \"signature\": \"{signature}\", \"hash\": \"{hash}\" }}";
        return (jsonString, "");
    }
    
}