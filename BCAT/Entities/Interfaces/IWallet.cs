namespace BCAT.Entities.Interfaces;

public interface IWallet
{
    public string SerializerToJsonString();
    public string SendTransaction(string receiver, int amount);
}