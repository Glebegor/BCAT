using BCAT.Entities.Commons;
namespace BCAT.Entities.Interfaces;

public interface IBlockchain
{
    public (string, string) CalculateHash(Transaction transaction, string prevHash, int index);
    public (Block, string) CreateBlock(Transaction transaction);
}