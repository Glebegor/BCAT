

namespace BCAT.Entities.Commons;

public class Wallet
{
    public string username;
    public string email;
    
    public string password;
    public string[] secretPhrases; // 12 words
    public string publicKey;
    public string privateKey;
    public int balance;
    public int id;
    
    public string SendTransaction(string receiver, int amount, Blockchain blockchain)
    {
        // Create a transaction
        Transaction transaction = new Transaction();
        transaction.CreateTransaction(this.publicKey, receiver, amount, this.privateKey);
        
        // Create a block
        (Block block, string err) = blockchain.CreateBlock(transaction);
        if (err != "")
        {
            return err;
        }

        return "";
    }

}