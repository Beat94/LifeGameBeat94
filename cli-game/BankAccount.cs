using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BankAccount : IFinance
{
    public string accountName {get; set;}
    public float percentage { get; set; }
    public Money amount { get; set; }

    public BankAccount(string accountName, float percentage, Money? amount)
    {
        this.accountName = accountName;
        this.percentage = percentage;
        this.amount = amount;
    }

    public void newDay()
    {
        amount.addValue((decimal)(amount.getValueFloat() * percentage)*1000);
    }
}
