public class Asset : IFinance
{
    public Money valueFull {get; set;}
    public float status {get; set;}

    public Asset(Money valueFull, float status)
    {
        this.valueFull = valueFull;
        this.status = status;
    }

    public (Money valueFull, Money valueNow) getValue()
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

    public Money repairPrice()
    {
        (Money vFull, Money vNow) = getValue();
        decimal valueMax = valueFull.getValueDecimal();
        decimal valueNow = vNow.getValueDecimal();
        decimal valueToPay = 0;

        // to evaluate how high the price of repair is. 
        if(status < 80)
        {
            valueToPay = ((valueMax / 100) * 90) - valueNow;
        }
        else
        {
            valueToPay = valueMax - valueNow;
        }

        return new Money(valueToPay);
    }

    public void repair(Money price)
    {
        Money repairValue = repairPrice();
        if(repairValue.getValueFloat() <= price.getValueFloat() && (repairValue.getValueFloat()+1) >= price.getValueFloat())
        {
            status = 100f;
        }
    }
}