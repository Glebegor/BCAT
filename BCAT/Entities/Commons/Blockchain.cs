using BCAT.Entities.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System;

namespace BCAT.Entities.Commons;

public class Blockchain : IBlockchain
{
    public int amount;
    public List<Block> chain = new List<Block>();
    public List<Wallet> wallets = new List<Wallet>();
    public int countBlocks = 0;


    // Creating of the block in blockchain, and calculating hash
    public (Block, string) CreateBlock(Transaction transaction)
    {
        if (countBlocks == 0)
        {
            // If first block

            (string hash, string err) = CalculateHash(transaction, "", 0);
            if (err != "")
            {
                return (null, err);
            }
            countBlocks++;
            amount += transaction.amount;
            
            Block block = new Block(hash, "", transaction, 1);
            chain.Add(block);
            
            return (block, "");
        }
        else
        {
            // If not first block
            (string hash, string err) = CalculateHash(transaction, chain[chain.Count()-1].hash, countBlocks);
            if (err != "")
            {
                return (null, err);
            }
            countBlocks++;
            amount += transaction.amount;

            Block block = new Block(hash, chain[chain.Count()-1].hash, transaction, countBlocks);
            chain.Add(block);
            return (block, "");
        }
        
    }

    // Using SHA256 to calculate hash
    public (string, string) CalculateHash(Transaction transaction, string prevHash, int index)
    {
        SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes( index.ToString() + prevHash);
        byte[] hash = sha256.ComputeHash(bytes);
        return (Convert.ToBase64String(hash), "");
    }
}