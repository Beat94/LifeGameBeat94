public class AssetManager:IFinance
{
    private List<Asset> assetList = new List<Asset>();

    public bool isManaged {get; set;}

    public AssetManager(bool? isManaged = false)
    {
        this.isManaged = (bool) isManaged;
    }


    public void newDay()
    {
        foreach(Asset asset in assetList)
        {
            asset.newDay();
        }
    }
    
    public int getAssetListCount()
    {
        return assetList.Count();
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
            //if home then home+roomcount if vehicle then something else. 
            AssetListOut.Add((assetList[i].GetType().ToString(), i.ToString()));
        }

        return AssetListOut;
    }

    public void createRandom()
    {

    }

}