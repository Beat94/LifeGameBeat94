public class Bank : IFinance
{
    public string nameBank {get;}
    public decimal positiveInterestBelow200k;
    public decimal positiveInterestOver200k;
    public decimal negativeInterestCredit;
    public decimal negativeInterestMortgage;
    public List<BankAccount> BankAccountList = new List<BankAccount>();

    public Bank (
        string nameBank,
        decimal positiveInterestBelow200k,
        decimal positiveInterestOver200k,
        decimal negativeInterestCredit,
        decimal negativeInterestMortgage)
    {
        this.nameBank = nameBank;
        this.positiveInterestBelow200k = positiveInterestBelow200k;
        this.positiveInterestOver200k = positiveInterestOver200k;
        this.negativeInterestCredit = negativeInterestCredit;
        this.negativeInterestMortgage = negativeInterestMortgage;
    }

    public decimal getMaxCreditValue(decimal savingValue) => savingValue * 30;

    public decimal getMaxMortgageValue(decimal income, decimal savings)
    {
        return 0;
    }
        
    public void newDay()
    {
        throw new NotImplementedException();
    }
}