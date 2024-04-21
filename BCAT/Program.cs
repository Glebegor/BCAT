using System.Security.Cryptography;
using BCAT.Entities.Interfaces;
using BCAT.Entities.Commons;
using BCAT.Entities.Commons.Clients;
using BCAT.Internal.Validators;

namespace BCAT;

public class Program
{
    public static void Main()
    {
        // VERY BIG TEST
        Blockchain blockchain = new Blockchain();

        InitTest(blockchain);
        
        Console.WriteLine("Starting of the client.");
        Console.WriteLine("Starting of the client.");
        // END OF VERY BIG TEST
        
        
        // Client initialization
        Client client = new Client();
        

    }
    

    static public void InitTest(Blockchain blockchain)
    {
        // Wallet tests
        Console.WriteLine("Creating Wallets...");

        Console.WriteLine("Created wallet alice.");
        Wallet alice_wallet = new Wallet("", "", "", new List<string>() {}, "123kjbepkj2h1po312", "213pjdopwq0u01y3213", 100, blockchain);
        Console.WriteLine("Created wallet bob.");
        Wallet bob_wallet = new Wallet("", "", "", new List<string>() { }, "qweqewef132f1peo[j[0efjw", "qwek1o2h3pduiwh1", 400, blockchain);

        Console.WriteLine("Blockchain wallets:");
        blockchain.wallets.ForEach(wallet => Console.WriteLine(wallet.SerializerToJsonString()));
        
        // Transaction tests
        Console.WriteLine("\n" + "Transaction 1.");
        alice_wallet.SendTransaction(bob_wallet.publicKey, 50);
        Console.WriteLine("Transaction 2.");
        bob_wallet.SendTransaction(alice_wallet.publicKey, 150);
        
        
        Console.WriteLine("Blockchain after transactions:");
        blockchain.chain.ForEach(block => Console.WriteLine(block.SerializerToJsonString()));
        Console.WriteLine("Blockchain wallets after transactions:");
        blockchain.wallets.ForEach(wallet => Console.WriteLine(wallet.SerializerToJsonString()));
        
        // Validate tests
        BlockchainValidator blockchainValidator = new BlockchainValidator();
        
        Console.WriteLine("Validating Blockchain...");
        Console.WriteLine("Without changes->");
        Console.WriteLine(BlockchainValidator.ValidateBlockchain(blockchain) ? "BLOCKCHAIN IS VALID" : "BLOCKCHAIN IS NOT VALID");
        
        Console.WriteLine("With changes->");
        blockchain.chain[1].prevHash = "123";        
        Console.WriteLine(BlockchainValidator.ValidateBlockchain(blockchain) ? "BLOCKCHAIN IS VALID" : "BLOCKCHAIN IS NOT VALID");
    }
}

