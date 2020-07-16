using RT.Base;
using RT.Mat;

namespace RT.Hit
{
  public class Hitable
  {
    public virtual bool Hit(Ray ray, double tMin, double tMax, ref HitRecord record)
    {
      return false;
    }
  }

  public class HitRecord
  {
    private double       _t;
    private Vector       _p;
    private Vector       _normal;
    private Mat.Material _material;

    public double       T        { get => _t;        set => _t = value; }
    public Vector       P        { get => _p;        set => _p = value; }
    public Vector       Normal   { get => _normal;   set => _normal = value; }
    public Mat.Material Material { get => _material; set => _material = value; }
  }
}