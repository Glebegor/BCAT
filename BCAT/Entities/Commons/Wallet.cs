

using BCAT.Entities.Interfaces;

namespace BCAT.Entities.Commons;

public class Wallet : IWallet
{
    
    public string password;
    public List<string> secretPhrases; // 12 words
    public string publicKey;
    public string privateKey;
    public int balance;

    
    // Creating of the wallet
    public Wallet(string password, List<string> secretPhrases, string publicKey, string privateKey, int balance)
    {

        this.password = password;
        this.secretPhrases = secretPhrases;
        this.publicKey = publicKey;
        this.privateKey = privateKey;
        this.balance = balance;

        
    }
    
    
    
    // Serializing wallet to json string
    public string SerializerToJsonString()
    {
        string jsonString = $"{{\"publicKey\": \"{publicKey}\"}}";
        return jsonString;
    }

}