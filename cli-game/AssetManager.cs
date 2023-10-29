internal class AssetManager:IFinance
{
    // Buyable Assets - lets do 10 per home and vehicle each day
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