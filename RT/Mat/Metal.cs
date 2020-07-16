using RT.Base;
using RT.Hit;
using RT.Util;

namespace RT.Mat
{
  public class Metal : Mat.Material
  {
    // 漫反射率
    private Vector _albedo;
    // 模糊程度
    private double _fuzz;

    public Vector Albedo { get => _albedo; set => _albedo = value; }
    public double Fuzz   { get => _fuzz;   set => _fuzz = value; }

    public Metal(Vector albedo, double fuzz)
    {
      _albedo = albedo;
      _fuzz = fuzz;
    }

    public override bool Scatter(Ray rayIn, HitRecord record, ref Vector attenuation, ref Ray scattered)
    {
      Vector reflected = RtUtils.Reflect(Vector.UnitVector(rayIn.Direction), record.Normal);
      scattered = new Ray(new Vector(record.P), reflected + Fuzz * RtUtils.RandomInUnitSphere());
      attenuation = Albedo;
      return Vector.DotProduct(scattered.Direction, record.Normal) > 0;
    }
  }
}