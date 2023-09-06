
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
        
    public void addBankAccount(string accountName, 
    Money? money, 
    BankAccountType bankAccountType)
    {
        float percentage = 0;
        if(money == null)
        {
            money = new Money(0);
        }

        // Logic to add specific percentage
        if(bankAccountType == BankAccountType.account)
        {
            if(money.getValueFloat() > 200000)
            {
                percentage =  (float)(positiveInterestOver200k / 100);
            }
            else
            {
                percentage =  (float)(positiveInterestBelow200k / 100);
            }
        }
        else if(bankAccountType == BankAccountType.credit)
        {
            percentage = (float)(negativeInterestCredit / 100);
        }
        else if(bankAccountType == BankAccountType.mortage)
        {
            percentage = (float)(negativeInterestMortgage / 100);
        }

        BankAccountList.Add(new BankAccount(accountName, percentage, money, bankAccountType));
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

    public List<(string,string)>? getBankAccountListMenuByType(BankAccountType? bankAccountType)
    {
        List<(string,string)> outputList = new List<(string, string)>();

        for(int i = 0; i < BankAccountList.Count; i++)
        {
            if(BankAccountList[i].bankAccountType == bankAccountType)
            {
                outputList.Add((BankAccountList[i].accountName, i.ToString()));
            }
            else
            {
                outputList.Add((BankAccountList[i].accountName, i.ToString()));
            }
        }

        return outputList;
    }

    public List<(string,string)>? getBankAccountSaldoListByType(BankAccountType? bankAccountType)
    {
        List<(string,string)> outputList = new List<(string, string)>();

        for(int i = 0; i < BankAccountList.Count; i++)
        {
            if(BankAccountList[i].bankAccountType == bankAccountType)
            {
                outputList.Add((BankAccountList[i].accountName, BankAccountList[i].amount.getValueFloat().ToString()));
            }
            else if(bankAccountType == null)
            {
                outputList.Add((BankAccountList[i].accountName, BankAccountList[i].amount.getValueFloat().ToString()));
            }
        }

        return outputList;
    }

    public float getMoneySumFloatByType(BankAccountType? bankAccountType)
    {
        float output = 0;

        for(int i = 0; i < BankAccountList.Count; i++)
        {
            if(BankAccountList[i].bankAccountType == bankAccountType)
            {
                output += BankAccountList[i].amount.getValueFloat();
            }
            else if(bankAccountType == null)
            {
                output += BankAccountList[i].amount.getValueFloat();
            }
        }

        return output;
    }

    public Money delBankAccount(int index)
    {
        Money money = new Money(0);
        if (BankAccountList[index].amount.getValueFloat() > 0)
        {
            money = BankAccountList[index].amount;
        }

        BankAccountList.RemoveAt(index);
        return money;
    }

    public void newDay()
    {
        for(int i = 0; i < BankAccountList.Count; i++)
        {
            // Add checking of percentage and amount of value
            if(BankAccountList[i].amount.getValueFloat() > 0)
            {
                if(BankAccountList[i].amount.getValueFloat() < 200000 && BankAccountList[i].percentage == (float)(positiveInterestBelow200k/100))
                {
                    BankAccountList[i].percentage = (float)(positiveInterestOver200k/100);
                }

                if(BankAccountList[i].amount.getValueFloat() > 200000 && BankAccountList[i].percentage == (float)(positiveInterestOver200k/100))
                {
                    BankAccountList[i].percentage = (float)(positiveInterestBelow200k/100);
                }
            }
            
            BankAccountList[i].newDay();
        }
    }
}