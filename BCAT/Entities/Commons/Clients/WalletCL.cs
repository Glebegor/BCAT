using RandomString4Net;
namespace BCAT.Entities.Commons.Clients;

public class WalletCL : Client
{
    Wallet wallet;
    public override void Run()
    {
        Console.WriteLine("1. Create wallet");
        Console.WriteLine("2. Load wallet");
        int choise = int.Parse(Console.ReadLine());
        switch (choise)
        {
            case 1:
                CreateWallet();
                break;
            case 2:
                LoadWallet();
                break;
            default:
                Console.WriteLine("Invalid choise");
                break;
        }
    }

    public void CreateWallet()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        
        Random random = new Random();
        List<string> randomWords = new List<string>();

        for (int i = 0; i < 12; i++)
        {
            // Generate a word of random length between 5 and 10 characters
            int wordLength = random.Next(5, 11);
            string word = new string(Enumerable.Range(0, wordLength)
                .Select(_ => chars[random.Next(chars.Length)]).ToArray());

            randomWords.Add(word);
        }

        Console.WriteLine("Your secret phrases: " + string.Join(" ", randomWords));
        Console.WriteLine("Please save your secret phrases in a safe place. You will need them to recover your wallet.");

        string password = GetPassword();
        
        
        
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
    public void LoadWallet()
    {
        
    }
}