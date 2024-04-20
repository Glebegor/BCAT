namespace BCAT.Entities.Interfaces;

public interface ITransaction
{
    public string createTransaction(string sender, string receiver, int amount, string signature, string hash)
}