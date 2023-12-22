public class Vehicle : Asset
{
    public int countWheels{get;set;}
    public int countSeats{get;set;}
    public bool isCar{get;set;}

    public Vehicle(
        Money valueFull, 
        float status,
        bool isCar,
        int countWheels = 4,
        int countSeats
        ) : base(
            valueFull, 
            status
        )
    {
        base.valueFull = valueFull;
        base.status = status;
        this.isCar = isCar;
        this.countWheels = countWheels;
        this.countSeats = countSeats;
    }
}