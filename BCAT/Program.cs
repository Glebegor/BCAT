using System.Security.Cryptography;
using BCAT.Entities.Interfaces;
using BCAT.Entities.Commons;

namespace BCAT;

public class Program
{
    public static void Main()
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
    }
}

