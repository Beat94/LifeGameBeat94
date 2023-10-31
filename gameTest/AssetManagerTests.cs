namespace gameTest;

public class AssetManagerTests
{
    [Theory]
    [InlineData(false,false)]
    [InlineData(true,true)]
    public void AssetManagerConstructor(bool constructor, bool result)
    {
        AssetManager assetManager = new AssetManager(constructor);
        Assert.Equal(result, assetManager.isManaged);
    }


    [Fact]
    public void AssetManagerAddHome()
    {
        AssetManager assetManager = new AssetManager(false);
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