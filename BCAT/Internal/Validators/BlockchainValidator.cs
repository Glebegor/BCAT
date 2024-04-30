using BCAT.Entities.Commons;
using System.Security.Cryptography;
using System.Text;

namespace BCAT.Internal.Validators;

// BLocal blockchain validator
public class BlockchainValidator
{
    public static bool ValidateBlockchain(Blockchain blockchain)
    {
        
        for (int i = 1; i < blockchain.chain.Count(); i++)
        {
            if (blockchain.chain[i].prevHash != blockchain.chain[i - 1].hash)
            {
                return false;
            }
        }
        return true;
    }


    private string PreviousHash;
    public string Hash;
    private string Transaction;
    private int Index;

    
    public BlockchainValidator(string previousHash, string hash, string transaction)
    {
        previousHash = PreviousHash;
        transaction = Transaction;
        Index = 0;
        Hash = HashValidator();
    }

    public string HashValidator()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes($"{Index}-{PreviousHash ?? ""} - {Transaction}");
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("X2"));
            }

            return builder.ToString();
        }
    }

    public bool ValidateBlock(Block block)
    {
        if (block.hash != HashValidator())
            return false;
        
        if (block.prevHash != PreviousHash)
            return false;
        
        return true;
    }
}