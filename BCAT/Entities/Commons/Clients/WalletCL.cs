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
        }

        public void CreateWallet()
        {
            List<string> randomWords = GenerateRandomWords();

            Console.WriteLine("Your secret phrases: " + string.Join(" ", randomWords));
            Console.WriteLine("Please save your secret phrases in a safe place. You will need them to recover your wallet.");

            string password = GetPassword();

            // Convert the random words and password to bytes
            string wordsString = string.Join(" ", randomWords);
            byte[] wordsBytes = Encoding.UTF8.GetBytes(wordsString);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] wordAndPass = wordsBytes.Concat(passwordBytes).ToArray();

            // Derive the private key using a hash function
            byte[] privateKeyBytes = DerivePrivateKey(wordAndPass);

            // Store or use the private key
            // For example:
            // wallet.PrivateKey = privateKeyBytes;

            Console.WriteLine("Wallet created successfully.");
        }

        public List<string> GenerateRandomWords()
        {
            List<string> randomWords = new List<string>();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

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

        public byte[] DerivePrivateKey(byte[] data)
        {
            // Derive the private key using a hash function
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }

        public void LoadWallet()
        {
            // Implementation for loading a wallet
        }
    }
}
