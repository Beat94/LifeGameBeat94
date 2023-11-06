namespace gameTest;

public class HomeTests
{
    [Fact]
    public void HomeTestEqual()
    {
        Home home = new Home(new Money(3000000), 100, true, 3);

        Assert.Equal(3000f, home.valueFull.getValueFloat());
    }

    [Fact]
    public void HomeTestNotEqual()
    {
        Home home = new Home(new Money(3000000), 100, true, 3);

        Assert.NotEqual(3f, home.valueFull.getValueFloat());
    }
}