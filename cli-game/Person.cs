public class Person : IFinance
{
    public string name{get;}
    public int sleepyness{get;set;}
    public int DayCount{get;set;}
    public Money money{get;}
    public List<Money> income30Days = new();

    public Person(string name)
    {
        this.name = name;
        this.sleepyness = 100;
        this.DayCount = 0;
        this.money = new Money(0);
        income30Days.Add(new Money(0));
    }

    public void newDay()
    {
        DayCount += 1;
        sleepyness = 100;

        //algorithm for income30Days
        if(income30Days.Count < 30)
        {
            income30Days.Add(new Money(0));
        }
        else
        {
            for(int i = 0; i < (income30Days.Count - 1); i++)
            {
                income30Days[i] = income30Days[i + 1];
            }
            income30Days.RemoveAt(30);
            income30Days.Add(new Money(0));
        }
    }

    public string getDayMonthYear()
    {
        int day = 0;
        int month = 0;
        int year = (DayCount / 360) - ((DayCount % 360)/100);
        return day.ToString() + "." + month.ToString() + "." + year.ToString();
    }

    public float getLast30DaysFloat()
    {
        float output = 0;

        if(income30Days.Count == 30 || DayCount >= 30)
        {
            for(int i = 0; i < income30Days.Count; i++)
            {
                output += income30Days[i].getValueFloat();
            }
            output = output / 30;
        }

        return output;
    }

    public void addMoney(Money Income)
    {
        money.addValue(Income.getValueDecimal());
        income30Days[income30Days.Count-1].addValue(Income.getValueDecimal());
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