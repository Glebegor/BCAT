using BCAT.Entities.Commons;
using System.Security.Cryptography;
using System.Text;

namespace BCAT.Internal.Validators;

// BLocal blockchain validator
public class BlockchainValidator
{
    public static bool ValidateBlockchain(Blockchain blockchain)
    {
        
        for (int i = 1; i < blockchain.chain.Count(); i++)
        {
            if (blockchain.chain[i].prevHash != blockchain.chain[i - 1].hash)
            {
                return false;
            }
        }
        return true;
    }


    private string PreviousHash { get; set; }
    public string Hash { get; set; }
    private string Transaction { get; set; }
    private int Index { get; set; }
    public string Signature { get; set; }
    
    public BlockchainValidator(string previousHash, string hash, string transaction, string signature)
    {
        previousHash = PreviousHash;
        transaction = Transaction;
        Index = 0;
        Signature = signature;
        Hash = HashValidator();
    }

    public string HashValidator()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string rawData = $"{Index}-{PreviousHash ?? ""} - {Transaction}-{Signature}";
            byte[] inputBytes = Encoding.UTF8.GetBytes(rawData);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("X2"));
            }

            return builder.ToString();
        }
    }

    public bool ValidateBlock(Block block)
    {
        using (var rsa = RSA.Create())
        {
            try
            {
                rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(Signature), out _);

                byte[] blockBytes = Encoding.UTF8.GetBytes($"{Index}-{PreviousHash ?? ""}-{Transaction}");
                bool isSignatureValid = rsa.VerifyData(blockBytes, Convert.FromBase64String(Signature),
                    HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                return isSignatureValid;
            }
            catch (CryptographicException)
            {
                return false;
            }
        }
        
        if (block.hash != HashValidator())
            return false;
        
        if (block.prevHash != PreviousHash)
            return false;
        
        return true;
    }


}