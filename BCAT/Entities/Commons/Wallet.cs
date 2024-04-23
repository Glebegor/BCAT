

using BCAT.Entities.Interfaces;

namespace BCAT.Entities.Commons;

public class Wallet : IWallet
{
    public string username;
    public string email;
    
    public string password;
    public List<string> secretPhrases; // 12 words
    public string publicKey;
    public string privateKey;
    public int balance;
    public int id;
    
    public Blockchain blockchain;
    
    // Creating of the wallet
    public Wallet(string username, string email, string password, List<string> secretPhrases, string publicKey, string privateKey, int balance, in Blockchain blockchain)
    {
        this.username = username;
        this.email = email;
        this.password = password;
        this.secretPhrases = secretPhrases;
        this.publicKey = publicKey;
        this.privateKey = privateKey;
        this.balance = balance;
        this.blockchain = blockchain;

        this.id = this.blockchain.wallets.Count+1;
        this.blockchain.wallets.Add(this);
        
    }
    
    // Sending transaction to the network
    public string SendTransaction(string receiver, int amount)
    {
        // Create a transaction
        Transaction transaction = new Transaction();
        transaction.CreateTransaction(this.publicKey, receiver, amount, this.privateKey);
        
        // Create a block
        (Block block, string err) = this.blockchain.CreateBlock(transaction);
        if (err != "")
        {
            return err;
        }
        
        return "";
    }
    
    // Serializing wallet to json string
    public string SerializerToJsonString()
    {
        string jsonString = $"{{ \"username\": \"{username}\", \"email\": \"{email}\", \"publicKey\": \"{publicKey}\", \"privateKey\": \"{privateKey}\", \"balance\": {balance}, \"id\": {id} }}";
        return jsonString;
    }

}