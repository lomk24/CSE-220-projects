using System;
public class MakeFraction
{
    private int _topNumber;
    private int _bottomNumber;

    public MakeFraction()
    {
        _topNumber = 1;
        _bottomNumber = 1;
    }

    public MakeFraction(int wholeNumber)
    {
        _topNumber = wholeNumber;
        _bottomNumber = 1;
    }

    public MakeFraction(int top, int bottom)
    {
        _topNumber = top;
        _bottomNumber = bottom;

    }

    public string GetFractionString()
    {
        string write = ($"{_topNumber}/{_bottomNumber}");
        return write;
    } 

    public double GetDecimalValue()
    {
        return (double)_topNumber/(double)_bottomNumber;
    }
}
