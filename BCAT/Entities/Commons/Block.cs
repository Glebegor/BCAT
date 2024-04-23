using BCAT.Entities.Interfaces;

namespace BCAT.Entities.Commons;

public class Block : IBlock 
{
    public string hash;
    public string prevHash;
    public Transaction transaction;
    public int index;
    
    // Creating of the block
    public Block(string hash, string prevHash, Transaction transaction, int index)
    {
        this.hash = hash;
        this.prevHash = prevHash;
        this.transaction = transaction;
        this.index = index;
    }

    // Serializing block to json string
    public string SerializerToJsonString()
    {
        string jsonString = $"{{ \"hash\": \"{hash}\", \"prevHash\": \"{prevHash}\", \"index\": {index}, \"transaction\": {transaction.SerializerToJsonString()}, }}";
        return jsonString;
    }
}