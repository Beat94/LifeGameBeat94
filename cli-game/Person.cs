public class Person : IFinance
{
    public string name{get;}
    public int sleepyness{get;set;}
    public int dayCount{get;set;}
    public Money money{get;}

    public Person(string name)
    {
        this.name = name;
        this.sleepyness = 100;
        this.dayCount = 0;
        this.money = new Money(0);
    }

    public void newDay()
    {
        dayCount += 1;
        sleepyness = 100;
    }
}