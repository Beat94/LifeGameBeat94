public class Person : IFinance
{
    public string name{get;}
    public int sleepyness{get;set;}
    public int DayCount{get;set;}
    public Money money{get;}

    public Person(string name)
    {
        this.name = name;
        this.sleepyness = 100;
        this.DayCount = 0;
        this.money = new Money(0);
    }

    public void newDay()
    {
        DayCount += 1;
        sleepyness = 100;
    }

    public string getDayMonthYear()
    {
        int day = 0;
        int month = 0;
        int year = (DayCount / 360) - ((DayCount % 360)/100);
        return day.ToString() + "." + month.ToString() + "." + year.ToString();
    }

    public void addMoney(Money Income)
    {
        money.addValue(Income.getValueDecimal());
    }

    public List<(string,string)> getPersonStats()
    {
        List<(string, string)> personStats = new List<(string, string)>
        {
            ("Name", this.name),
            ("Sleepyness", this.sleepyness.ToString()),
            ("Day", DayCount.ToString()),
            ("Money", money.getValueFloat().ToString())
        };

        return personStats;
    }
}