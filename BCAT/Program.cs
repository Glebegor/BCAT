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
        Console.WriteLine("Creating Wallets...");

        Console.WriteLine("Created wallet alice.");
        Wallet alice_wallet = new Wallet("", "", "", new List<string>() {}, "123kjbepkj2h1po312", "213pjdopwq0u01y3213", 100, blockchain);
        Console.WriteLine("Created wallet bob.");
        Wallet bob_wallet = new Wallet("", "", "", new List<string>() { }, "qweqewef132f1peo[j[0efjw", "qwek1o2h3pduiwh1", 400, blockchain);

        Console.WriteLine("Blockchain wallets:");
        blockchain.wallets.ForEach(wallet => Console.WriteLine(wallet.SerializerToJsonString()));
        
        Console.WriteLine("\n" + "Transaction 1.");
        alice_wallet.SendTransaction(bob_wallet.publicKey, 50);
        Console.WriteLine("Transaction 2.");
        bob_wallet.SendTransaction(alice_wallet.publicKey, 150);
        
        
        Console.WriteLine("Blockchain after transactions:");
        blockchain.chain.ForEach(block => Console.WriteLine(block.SerializerToJsonString()));
        Console.WriteLine("Blockchain wallets after transactions:");
        blockchain.wallets.ForEach(wallet => Console.WriteLine(wallet.SerializerToJsonString()));
        

        // Console.WriteLine("Creating Transaction 1...");
        // Transaction transaction1 = new Transaction();
        // transaction1.CreateTransaction("Alice_public", "Bob_public", 100, "PrivateKey_alice");
        //
        // (_, string err) = blockchain.CreateBlock(transaction1);
        // if (err != "") 
        // {
        //     Console.WriteLine(err);
        //     return;
        // }
        //
        // string jsonBlock = blockchain.chain[0].SerializerToJsonString();
        //
        //
        // Console.WriteLine(jsonBlock);
        //
        // Console.WriteLine("Creating Transaction 2...");
        // Transaction transaction2 = new Transaction();
        // transaction2.CreateTransaction("Bob_public", "Alice_public", 200, "PrivateKey_bob");
        //
        // (_, err) = blockchain.CreateBlock(transaction2);
        // if (err != "") 
        // {
        //     Console.WriteLine(err);
        //     return;
        // }
        //
        // jsonBlock = blockchain.chain[1].SerializerToJsonString();
        //
        //
        // Console.WriteLine(jsonBlock + "\n");

    }
}

