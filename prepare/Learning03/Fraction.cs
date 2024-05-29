public class Fraction
{
    // Constructors
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Attributes
    private int _numerator;
    private int _denominator;

    // Methods
    public int GetNumerator()
    {
        return _numerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public void SetDenominator(int denominator)
    {
        _denominator = denominator;
    }

    public string GetFractionString()
    {
        string fraction = $"{_numerator}/{_denominator}";
        return fraction;
    }

    public double GetDecimalValue()
    {
        double dec = (double)_numerator / (double)_denominator;
        return dec;
    }
}