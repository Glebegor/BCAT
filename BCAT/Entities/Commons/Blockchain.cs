using BCAT.Entities.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System;

namespace BCAT.Entities.Commons;

public class Blockchain : IBlockchainInterface
{
    public int amount;
    
    static public List<Block> chain = new List<Block>();
    static public int countBlocks = 0;



    public (Block, string) CreateBlock(Transaction transaction)
    {
        if (countBlocks == 0)
        {
            (string hash, string error) = CalculateHash(transaction, "", 0);
            if (error != "")
            {
                return (null, error);
            }
            countBlocks++;
            
            Block block = new Block(hash, "", transaction, 1);
            chain.Add(block);
            
            return (block, "");
        }
        else
        {
            (string hash, string error) = CalculateHash(transaction, chain[-1].hash, countBlocks);
            if (error != "")
            {
                return (null, error);
            }
            countBlocks++;

            Block block = new Block(hash, chain[-1].hash, transaction, countBlocks);
            chain.Add(block);
            return (block, "");
        }
        
    }

    public (string, string) CalculateHash(Transaction transaction, string prevHash, int index)
    {
        SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes( index.ToString() + prevHash);
        byte[] hash = sha256.ComputeHash(bytes);
        return (Convert.ToBase64String(hash), "");
    }
}