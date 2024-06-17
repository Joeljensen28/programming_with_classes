using System.Security.Cryptography.X509Certificates;

class Sphere : Circle
{
    public Sphere(double r) : base(r)
    {

    }

    public override double Area()
    {
        return 4.0 * base.Area();
    }
}