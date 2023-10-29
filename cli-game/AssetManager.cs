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

    public List<(string, string)> getAssetList()
    {
        List<(string,string)> AssetListOut = new();

        for(int i = 0; i < assetList.Count; i++)
        {
            AssetListOut.Add((assetList[i].GetType().ToString(), i.ToString()));
        }

        return AssetListOut;
    }

}