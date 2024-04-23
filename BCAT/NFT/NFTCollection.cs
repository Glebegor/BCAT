namespace BCAT.NFT;

public class NFTCollection : NFT
{
    private List<NFT> nfts = new List<NFT>();

    public void AddNFT(NFT nft)
    {
        nfts.Add(nft);
    }
    
    //search NFT by ID

    public NFT GetNFTById(int tokenId)
    {
        return nfts.Find(nft => nft.TokenId == tokenId);
    }
    
    //search NFT by Owner
    
    public List<NFT> GetNFTByOwner(string owner)
    {
        return nfts.FindAll(nft => nft.Owner == owner);
    }
}