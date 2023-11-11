namespace gameTest;

public class BankTests
{
    static string bankName = "Public Bank";
    static decimal positiveInterestBelow200k = 105;
    static decimal positiveInterestOver200k = 102;
    static decimal negativeInterestCredit = 116;
    static decimal negativeInterestMortgage = 110;
    
    Bank bank = new Bank(bankName, 
        positiveInterestBelow200k,
        positiveInterestOver200k,
        negativeInterestCredit,
        negativeInterestMortgage);

    [Theory]
    [InlineData(30000, 1000)]
    [InlineData(0, 0)]
    [InlineData(0, -1000)]
    public void getMaxCreditValueTest(float maxCreditValue, float savingValue)
    {
        float creditValue = bank.getMaxCreditValue(savingValue);
        Assert.Equal(maxCreditValue, creditValue);
    }

    [Theory]
    [InlineData(1000000f, 1000000f, 100000, false)]
    public void getMaxMortgageValueTest(float income, float valueMoney, decimal maxMorgageGoal, bool outputboolGoal)
    {
        (decimal maxMortage, bool outputbool) = bank.getMaxMortgageValue(income, valueMoney);
        Assert.Equal((maxMortage, outputbool) ,(maxMorgageGoal, outputboolGoal));
    }
}