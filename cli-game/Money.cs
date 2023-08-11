public class Money
{
    private decimal amount;

    // value x1000
    public Money(decimal amount)
    {
        this.amount = amount;
    }

    public float getValueFloat() => (float) Math.Round((amount / 1000),2);

    public decimal getValueDecimal() => amount;

    public void addValue(decimal value)
    {
        amount = value + amount;
    }

    public Money giveMoney(decimal value)
    {
        amount -= value;
        return new Money(value);
    }
}