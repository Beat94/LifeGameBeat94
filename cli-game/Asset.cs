internal class Asset : IFinance
{
    private Money valueFull {get; set;}
    internal float status {get; set;}

    internal Asset(Money valueFull, float status)
    {
        this.valueFull = valueFull;
        this.status = status;
    }

    internal (Money valueFull, Money valueNow) getValue()
    {
        float value = valueFull.getValueFloat() / 100 * status;
        value = value * 1000;
        decimal valueDecimal = (decimal) value;
        return (this.valueFull, new Money(valueDecimal));
    }

    public void newDay()
    {
        status = status * 0.99f;
    }
}