public class Vehicle : Asset
{
    public int countWheels{get;set;}
    public int countSeats{get;set;}

    public Vehicle(
        Money valueFull, 
        float status,
        int countWheels = 4,
        int countSeats
        ) : base(
            valueFull, 
            status
        )
    {
        base.valueFull = valueFull;
        base.status = status;
        this.countWheels = countWheels;
        this.countSeats = countSeats;
    }
}