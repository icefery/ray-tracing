using RT.Base;
using RT.Hit;
using RT.Util;

namespace RT.Mat
{
  public class Lambert : Mat.Material
  {
    // 漫反射系数
    private Vector _albedo;

    public Vector Albedo { get => _albedo; set => _albedo = value; }

    public Lambert(Vector albedo)
    {
      _albedo = albedo;
    }

    public override bool Scatter(Ray rayIn, HitRecord record, ref Vector attenuation, ref Ray scattered)
    {
      Vector target = record.P + record.Normal + RtUtils.RandomInUnitSphere();
      scattered = new Ray(new Vector(record.P), target - record.P);
      attenuation = Albedo;
      return true;
    }
  }
}