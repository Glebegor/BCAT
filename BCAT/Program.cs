using System.Security.Cryptography;
using BCAT.Entities.Interfaces;
using BCAT.Entities.Commons;
using BCAT.Internal.Validators;

namespace BCAT;

public class Program
{
    public static void Main()
    {
        // VERY BIG TEST
        Blockchain blockchain = new Blockchain();

        InitTest(blockchain);
        BlockchainValidator blockchainValidator = new BlockchainValidator();
        
        Console.WriteLine("Validating Blockchain...");
        Console.WriteLine("Without changes->");
        Console.WriteLine(BlockchainValidator.ValidateBlockchain(blockchain) ? "BLOCKCHAIN IS VALID" : "BLOCKCHAIN IS NOT VALID");
        
        Console.WriteLine("With changes->");
        blockchain.chain[1].prevHash = "123";        
        Console.WriteLine(BlockchainValidator.ValidateBlockchain(blockchain) ? "BLOCKCHAIN IS VALID" : "BLOCKCHAIN IS NOT VALID");
        // END OF VERY BIG TEST


    }

    static public void InitTest(Blockchain blockchain)
    {
        
        Console.WriteLine("Creating Transaction 1...");
        Transaction transaction1 = new Transaction();
        transaction1.CreateTransaction("Alice_public", "Bob_public", 100, "PrivateKey_alice", "AliceHash");
        
        (_, string err) = blockchain.CreateBlock(transaction1);
        if (err != "") 
        {
            Console.WriteLine(err);
            return;
        }

        string jsonBlock = blockchain.chain[0].SerializerToJsonString();
 
        
        Console.WriteLine(jsonBlock);
        
        Console.WriteLine("Creating Transaction 2...");
        Transaction transaction2 = new Transaction();
        transaction2.CreateTransaction("Bob_public", "Alice_public", 200, "PrivateKey_bob", "BobHash");
        
        (_, err) = blockchain.CreateBlock(transaction2);
        if (err != "") 
        {
            Console.WriteLine(err);
            return;
        }

        jsonBlock = blockchain.chain[1].SerializerToJsonString();

        
        Console.WriteLine(jsonBlock + "\n");

    }
}

