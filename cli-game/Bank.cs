public class Bank : IFinance
{
    public string NameBank {get;set;}
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
        this.NameBank = nameBank;
        this.positiveInterestBelow200k = positiveInterestBelow200k;
        this.positiveInterestOver200k = positiveInterestOver200k;
        this.negativeInterestCredit = negativeInterestCredit;
        this.negativeInterestMortgage = negativeInterestMortgage;
    }

    public decimal getMaxCreditValue(decimal savingValue) => savingValue * 30;

    public (decimal, bool) getMaxMortgageValue(float income, float valueMoney)
    {
        bool outputbool = false;
        float maxMortgage = valueMoney / 0.8f;
        
        if (maxMortgage / (float)negativeInterestMortgage * 100 < income)
        {
            outputbool = true;
        }

        decimal maxMortgageDecimal = (decimal)(maxMortgage * 1000);
        return (maxMortgageDecimal, outputbool);
    }
        
    public void addBankAccount(BankAccount bankAccount)
    {
        BankAccountList.Add(bankAccount);
    }

    public List<(string, string)> getBankAccountListMenu()
    {
        List<(string, string)> outputList = new List<(string,string)>();
        
        for(int i = 0; i < BankAccountList.Count; i++)
        {
            outputList.Add((BankAccountList[i].accountName, i.ToString()));
        }

        return outputList;
    }

    public void delBankAccount(int index)
    {
        BankAccountList.RemoveAt(index);
    }

    public void newDay()
    {
        throw new NotImplementedException();

        for(int i = 0; i < BankAccountList.Count; i++)
        {
            BankAccountList[i].newDay();
        }

    }
}