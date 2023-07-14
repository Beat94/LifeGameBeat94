public class Money
{
    private decimal amount;
    public Money(decimal amount)
    {
        this.amount = amount;
    }

    public float getValueFloat() => (float) Math.Round((amount / 1000),2);

    public decimal getValueDeciaml() => amount;

    public void addValue(decimal value)
    {
        amount += value;
    }

    public Money giveMoney(decimal value)
    {
        amount -= value;
        return new Money(value);
    }
}