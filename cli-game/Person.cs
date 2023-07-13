public class Person : IFinance
{
    public string name{get;}
    public int sleepyness{get;set;}
    public int dayCount{get;set;}

    public Person(string name)
    {
        this.name = name;
        this.sleepyness = 100;
        dayCount = 0;
    }

    public void newDay()
    {
        dayCount += 1;
        sleepyness = 100;
    }
}