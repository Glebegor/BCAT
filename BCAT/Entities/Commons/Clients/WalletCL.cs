using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BCAT.Entities.Commons.Clients
{
    public class WalletCL : Client
    {
        Wallet wallet;

        public WalletCL()
        {
            nodesInNetwork = new List<string>();
            // nodesMiningInNetwork = new List<string>();
            // miningsInNetwork = new List<string>();
            // blockchain = new Blockchain();
        }
        public override void Run()
        {
            Console.WriteLine("1. Create wallet");
            Console.WriteLine("2. Load wallet");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }

            switch (choice)
            {
                case 1:
                    CreateWallet();
                    break;
                case 2:
                    LoadWallet();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine("Wallet created successfully.");
            Console.WriteLine("Enter commands to interact with the wallet. Type 'help' for a list of commands.");
            while (true)
            {
                string command;
                command = Console.ReadLine();
                switch (command)
                {
                    case "help":
                        Console.WriteLine("Commands:");
                        break;
                    case "-getWallet":
                        Console.WriteLine("Public key: " + wallet.publicKey);
                        Console.WriteLine("Balance: " + wallet.balance);
                        break;
                    case "-getPrivateKey":
                        Console.WriteLine("Private key: " + wallet.privateKey);
                        break;
                    case "-getPassword":
                        Console.WriteLine("Password: " + wallet.password);
                        break;
                    default:
                        Console.WriteLine("Invalid command. Type 'help' for a list of commands.");
                        break;
                }
                

            }
        }

        public void LoadWallet()
        {
            Console.WriteLine("Enter your 12 words separated by spaces: ");
            List<string> secretPhrases = Console.ReadLine().Split(' ').ToList();
            
            Console.WriteLine("Enter your password: ");
            string password = GetPassword();
            
            // Generate private key
            byte[] privateKeyBytes;
            using (ECDsa ecdsa = ECDsa.Create())
            {
                privateKeyBytes = ecdsa.ExportPkcs8PrivateKey();
            }
            string privateKeyString = Convert.ToBase64String(privateKeyBytes);

            // Generate public key from private key
            string publicKeyString = GeneratePublicKeyFromPrivateKey(privateKeyBytes);

            if (!IsRealWallet(password, secretPhrases, publicKeyString, privateKeyString))
            {
                Console.WriteLine("Invalid wallet. Please check your password and secret phrases.");
            }
            
            // Create Wallet object
            Wallet wallet = new Wallet(password, secretPhrases, publicKeyString, privateKeyString, 0);
            this.wallet = wallet;
        }
        public void CreateWallet()
        {
            List<string> randomWords = GenerateRandomWords();
            string publicKeyString, privateKeyString;

            Console.WriteLine("Your secret phrases: " + string.Join(" ", randomWords));
            Console.WriteLine("Please save your secret phrases in a safe place. You will need them to recover your wallet.");

            string password = GetPassword();

            // Generate private key
            byte[] privateKeyBytes;
            using (ECDsa ecdsa = ECDsa.Create())
            {
                privateKeyBytes = ecdsa.ExportPkcs8PrivateKey();
            }
            privateKeyString = Convert.ToBase64String(privateKeyBytes);

            // Generate public key from private key
            publicKeyString = GeneratePublicKeyFromPrivateKey(privateKeyBytes);

            // Create Wallet object
            Wallet wallet = new Wallet(password, randomWords, publicKeyString, privateKeyString, 0);
            this.wallet = wallet;
        }


        public string GeneratePublicKeyFromPrivateKey(byte[] privateKeyBytes)
        {
            using (ECDsa ecdsa = ECDsa.Create())
            {
                ecdsa.ImportPkcs8PrivateKey(privateKeyBytes, out _);

                byte[] publicKeyBytes = ecdsa.ExportSubjectPublicKeyInfo();
                return Convert.ToBase64String(publicKeyBytes);
            }
        }

        public List<string> GenerateRandomWords()
        {
            List<string> randomWords = new List<string>();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            // Generate 12 random words
            for (int i = 0; i < 12; i++)
            {
                int wordLength = random.Next(5, 11);
                string word = new string(Enumerable.Range(0, wordLength)
                    .Select(_ => chars[random.Next(chars.Length)]).ToArray());

                randomWords.Add(word);
            }

            return randomWords;
        }

        public string GetPassword()
        {
            string password = "";
            Console.Write("Enter your password: ");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true); // Read key without displaying it
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine(); // Move to the next line after user presses Enter
                    break; // Break the loop when Enter is pressed
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Handle backspace to delete the last character
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b"); // Erase the character from the console
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    // Append the entered character to the password
                    password += key.KeyChar;
                    Console.Write("*"); // Display asterisk (*) instead of the actual character
                }
            }

            return password;
        }

        public bool IsRealWallet(string password, List<string> secretPhrases, string publicKey, string privateKey)
        {
            bool res = true;
            
            // Check if the wallet is real
            
            return res;
        }
    }
}
