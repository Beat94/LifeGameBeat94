public class Bank : IFinance
{
    public string name {get;}
    public decimal positiveInterestBelow200k;
    public decimal positiveInterestOver200k;
    public decimal negativeInterestCredit;
    public decimal negativeInterestMortgage;

    public Bank (
        string name,
        decimal positiveInterestBelow200k,
        decimal positiveInterestOver200k,
        decimal negativeInterestCredit,
        decimal negativeInterestMortgage)
    {
        this.name = name;
        this.positiveInterestBelow200k = positiveInterestBelow200k;
        this.positiveInterestOver200k = positiveInterestOver200k;
        this.negativeInterestCredit = negativeInterestCredit;
        this.negativeInterestMortgage = negativeInterestMortgage;
    }

    public void newDay()
    {
        throw new NotImplementedException();
    }
}