using BCAT.Entities.Commons;

namespace BCAT.Internal.Validators;

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
}