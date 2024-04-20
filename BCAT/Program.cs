using System.Security.Cryptography;
using BCAT.Entities.Interfaces;
using BCAT.Entities.Commons;

namespace BCAT;

public class Program
{
    public static void Main()
    {
        InitTest();
    }

    static public void InitTest()
    {
        Blockchain blockchain = new Blockchain();
        
        Console.WriteLine("Creating Transaction 1...");
        Transaction transaction1 = new Transaction();
        transaction1.CreateTransaction("Alice_public", "Bob_public", 100, "PrivateKey_alice", "AliceHash");
        
        (_, string err) = blockchain.CreateBlock(transaction1);
        if (err != "") 
        {
            Console.WriteLine(err);
            return;
        }

        (string jsonTransaction, err) = blockchain.chain[0].transaction.SerializerToJsonString();
        if (err != "") 
        {
            Console.WriteLine(err);
            return;
        }
        
        Console.WriteLine(jsonTransaction);
        Console.WriteLine(blockchain.chain[0].hash);
        Console.WriteLine(blockchain.chain[0].index);
        Console.WriteLine(blockchain.chain[0].prevHash);
        
        Console.WriteLine("Creating Transaction 2...");
        Transaction transaction2 = new Transaction();
        transaction2.CreateTransaction("Bob_public", "Alice_public", 200, "PrivateKey_bob", "BobHash");
        
        (_, err) = blockchain.CreateBlock(transaction2);
        if (err != "") 
        {
            Console.WriteLine(err);
            return;
        }

        (jsonTransaction, err) = blockchain.chain[1].transaction.SerializerToJsonString();
        if (err != "") 
        {
            Console.WriteLine(err);
            return;
        }
        
        Console.WriteLine(jsonTransaction);
        Console.WriteLine(blockchain.chain[1].hash);
        Console.WriteLine(blockchain.chain[1].index);
        Console.WriteLine(blockchain.chain[1].prevHash);
    }
}

