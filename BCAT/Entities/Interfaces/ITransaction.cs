namespace BCAT.Entities.Interfaces;

public interface ITransaction
{
    public string CreateTransaction(string sender, string receiver, int amount, string signature);
    public string SerializerToJsonString();
}