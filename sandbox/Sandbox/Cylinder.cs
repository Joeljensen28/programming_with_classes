using System.Security.Cryptography.X509Certificates;

class Cylinder : Circle
{
    private double _height;

    public Cylinder(double r, double height) : base(r)
    {
        _height = height;
    }

    public override double Area()
    {
        return 2.0 * base.Area() + 2.0 * Math.PI * _radius * _height;
    }
}