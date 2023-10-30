namespace gameTest;

public class AssetManagerTest
{
    [Fact]
    public void AssetManagerAddHome()
    {
        AssetManager assetManager = new AssetManager();
        Home home = new Home(
            new Money(200000),
            100f,
            true,
            3
        );

        assetManager.addAsset(home);

        Assert.Equal(1,assetManager.getAssetListCount());
    }
}