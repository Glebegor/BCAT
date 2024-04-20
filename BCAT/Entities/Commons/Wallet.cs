

namespace BCAT.Entities.Commons;

public class Wallet
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

}