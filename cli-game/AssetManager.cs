internal class AssetManager:IFinance
{
    private List<Asset> assetList = new List<Asset>();

    public void newDay()
    {
        foreach(Asset asset in assetList)
        {
            asset.newDay();
        }
    }
    
    public void addAsset(Asset asset)
    {
        assetList.Add(asset);
    }

}