public class StandardJobs
{
    public string Name {get;}
    // Monthly salary
    public Money Salary {get;}
    public bool Hired {get;set;}

    public StandardJobs(string Name, Money Salary)
    {
        this.Name = Name;
        this.Salary = Salary;
        this.Hired = false;
    }
}