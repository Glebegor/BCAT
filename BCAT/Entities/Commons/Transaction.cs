using BCAT.Entities.Interfaces;
namespace BCAT.Entities.Commons;

public class Transaction : ITransaction
{
    public string sender;
    public string receiver;
    public int amount;
    public string signature;
    
    public string CreateTransaction(string sender, string receiver, int amount, string signature)
    {
        this.sender = sender;
        this.receiver = receiver;
        this.amount = amount;
        this.signature = signature;
        return "";
    }

    public string SerializerToJsonString()
    {
        string jsonString = $"{{ \"sender\": \"{sender}\", \"receiver\": \"{receiver}\", \"amount\": {amount}, \"signature\": \"{signature}\" }}";
        return jsonString;
    }
    
}