public class AssetManager:IFinance
{
    // Buyable Assets - lets do 10 per home and vehicle each day
    private List<Asset> assetList = new List<Asset>();

    public bool isManaged {get; set;}

    public AssetManager(bool isManaged)
    {
        this.isManaged = isManaged;
    }


    public void newDay()
    {
        foreach(Asset asset in assetList)
        {
            asset.newDay();
        }
        if(isManaged)
        {
            createRandom();
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

    public List<(string, string)> getAssetList(AssetType? assetType)
    {
        List<(string,string)> AssetListOut = new();

        for(int i = 0; i < assetList.Count; i++)
        {
            if(assetList[i].GetType().ToString().Equals(assetType.ToString()))
            {
                AssetListOut.Add((assetList[i].GetType().ToString(), i.ToString()));
            }
            else
            {
                AssetListOut.Add((assetList[i].GetType().ToString(), i.ToString()));
            }
            //if home then home+roomcount if vehicle then something else. 
        }

        return AssetListOut;
    }

    private void cleanArray()
    {
        int assetCount = getAssetListCount();

        while(assetCount > 0)
        {
            assetList.RemoveAt(0);
            assetCount = getAssetListCount();
        }
    }

    private void createRandom()
    {
        Random random = new Random();
        cleanArray();

        for(int i = 0; i < 10; i++)
        {
            int decision = random.Next(0,1);
            bool isHouse = false;
            if(decision >= 1)
            {
                isHouse = true;
            }

            Home house = new Home(
                new Money(random.Next(50000000,2000000000)),
                random.Next(50,100),
                isHouse,
                random.Next(1,10)
            );

            assetList.Add(house);
        }
    }

}