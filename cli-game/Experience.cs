public class Experience
{
    public string name{get;set;}
    public int level{get;set;}
    public Experience(string name)
    {
        this.name = name;
        this.level = 0;
    }
}