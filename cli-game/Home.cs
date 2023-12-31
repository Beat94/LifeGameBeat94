public class Home : Asset
{

    public bool isHouse{get;set;}
    public int roomCount {get;set;}

    public Home(
        Money valueFull, 
        float status, 
        bool isHouse, 
        int roomCount
        ) : base(
            valueFull, 
            status
        )
    {
        base.valueFull = valueFull;
        base.status = status;
        this.isHouse = isHouse;
        this.roomCount = roomCount;
    }
}