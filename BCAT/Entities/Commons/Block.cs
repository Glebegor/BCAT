namespace BCAT.Entities.Commons;

public class Block
{
    public string hash;
    public string prevHash;
    public Transaction transaction;
    public int index;
    
    public Block(string hash, string prevHash, Transaction transaction, int index)
    {
        this.hash = hash;
        this.prevHash = prevHash;
        this.transaction = transaction;
        this.index = index;
    }
}