namespace gameTest;

public class BankTests
{
    Bank bank = new Bank("Public Bank", 105,102,116,110);

    [Theory]
    [InlineData(30000, 1000)]
    [InlineData(0, 0)]
    [InlineData(0, -1000)]
    public void getMaxCreditValueTest(float maxCreditValue, float savingValue)
    {
        float creditValue = bank.getMaxCreditValue(savingValue);
        Assert.Equal(maxCreditValue, creditValue);
    }
}